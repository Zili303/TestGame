using System;
using UnityEngine;

public class Enemy : Character
{
    internal Rigidbody rb;
    protected Player player;
    protected EnemyController enemyController;
    protected float Damage;
    protected float Speed;
    protected int ScoreForKill;
    protected int ExperienceForKill;
    protected EnemyPool enemyPool;
    public EnemyStats Stats;
    public event Action OnRedLineReached;
    public event Action OnDie;

    protected virtual void OnEnable() 
    {
        SetStats(Stats);
    }

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collider) 
    {
        if (collider.GetComponent<Line>() != null)
        {
            OnRedLineReached?.Invoke();
            Die(false);
        }
    }

    public void UpdateState() 
    {
        Move();
        CheckForDeath();
    }

    private void Move()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }

    private void CheckForDeath()
    {
        if (CurrentHealth <= 0)
        {
            Die(true);
        }
    }

    public void Die(bool giveExp)
    {
        if (giveExp)
        {
            player.GainScore(ExperienceForKill);
            player.GainExperience(ExperienceForKill);
        }
        else
        {
            player.TakeDamage(Damage);
        }

        OnDie?.Invoke();
        
        enemyPool.ReturnToPool(this);
    }

    public virtual void ModifySpeed(float percent)
    {
        Speed *= 1 + percent/100;
    }

    public override void ModifyMaxHealth(float percent)
    {
        MaxHealth *= 1 + percent/100;
    }

    public void SetStats(EnemyStats enemyStats)
    {
        MaxHealth = enemyStats.MaxHealth;
        CurrentHealth = MaxHealth;
        Speed = enemyStats.Speed;
        Damage = enemyStats.Damage;
        ScoreForKill = enemyStats.ScoreForKill;
        ExperienceForKill = enemyStats.ExperienceForKill;
    }

    public void SetEnemyPool(EnemyPool pool)
    {
        enemyPool = pool;
    }

    public void SetEnemyController(EnemyController controller)
    {
        enemyController = controller;
    }
}
