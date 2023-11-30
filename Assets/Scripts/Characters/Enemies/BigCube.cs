public class BigCube : Enemy, ICube
{
    protected override void OnEnable() 
    {
        base.OnEnable();
        OnDie += RestoreHealth;
    }

    private void OnDisable() 
    {
        OnDie -= RestoreHealth;
    }

    private void RestoreHealth()
    {
        foreach (Enemy enemy in enemyController.SpawnedEnemies)
        {
            if (enemy.CurrentHealth < enemy.MaxHealth / 2)
            {
                enemy.ModifyHealth(enemy.MaxHealth);
            }
        }
    }
}
