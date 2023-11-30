using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameStateController gameStateController;
    
    [HideInInspector] public List<Enemy> SpawnedEnemies = new List<Enemy>();

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

    private void OnGameStart()
    {
        ClearEnemies();
    }

    private void OnGameEnd()
    {
        // throw new NotImplementedException();
    }

    void Update()
    {
        UpdateEnemiesState();
    }

    private void ClearEnemies()
    {
        SpawnedEnemies.Clear();
    }

    private void UpdateEnemiesState()
    {
        foreach (Enemy enemy in SpawnedEnemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.UpdateState();
            }
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        if (!SpawnedEnemies.Contains(enemy))
        {
            SpawnedEnemies.Add(enemy);
            enemy.SetEnemyController(this);
        }
    }
}
