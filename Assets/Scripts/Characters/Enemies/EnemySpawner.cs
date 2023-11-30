using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameStateController gameStateController;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private MapSettings mapSettings;

    [Space]

    [SerializeField] private float spawnCooldown;

    [Space]

    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private List<EnemyPool> enemyPools;
    
    private Dictionary<Enemy, EnemyPool> enemyPoolsDictionary = new Dictionary<Enemy, EnemyPool>();

    private void OnEnable() 
    {
        gameStateController.OnGameStart += OnGameStart;
        gameStateController.OnGameEnd += OnGameEnd;
    }

    private void OnDisable() 
    {
        gameStateController.OnGameStart -= OnGameStart;
        gameStateController.OnGameEnd -= OnGameEnd;
    }

    private void Start() 
    {
        PopulateDictionary();
    }

    private void OnGameStart()
    {
        InvokeRepeating("SpawnNextEnemy", spawnCooldown, spawnCooldown);
    }

    private void OnGameEnd()
    {
        CancelInvoke();
    }

    private void SpawnNextEnemy()
    {
        SpawnEnemy(DrawEnemy());
    }

    private void SpawnEnemy(Enemy enemy)
    {
        float randomXPos = Random.Range(-mapSettings.MapWide, mapSettings.MapWide);

        var spawnedEnemy = enemyPoolsDictionary[enemy].Get();

        spawnedEnemy.transform.position = new Vector3(randomXPos, enemy.transform.position.y, mapSettings.StartZPosition);
        spawnedEnemy.transform.rotation = transform.rotation;

        Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        spawnedEnemy.GetComponent<MeshRenderer>().material.color = randomColor;

        spawnedEnemy.SetEnemyPool(enemyPoolsDictionary[enemy]);

        enemyController.AddEnemy(spawnedEnemy);

        spawnedEnemy.gameObject.SetActive(true);
    }

    private Enemy DrawEnemy()
    {
        float spawnChance = Random.Range(0f, 1f);
        float totalPercentage = 0;
        float addToTotal = 0;

        for (int i = 0; i < enemies.Count; i++)
        {
            totalPercentage += enemies[i].Stats.SpawnChance;
        }

        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy enemy = enemies[i];
            float enemySpawnChance = enemies[i].Stats.SpawnChance;

            if (enemySpawnChance / totalPercentage + addToTotal >= spawnChance)
            {
                return enemy;
            }
            else
            {
                addToTotal += enemySpawnChance / totalPercentage;
            }
        }
        return enemies[0];
    }

    private void PopulateDictionary()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            enemyPoolsDictionary.Add(enemies[i], enemyPools[i]);
        }
    }
}
