public class SmallSphere : Enemy, ISphere
{
    protected override void OnEnable() 
    {
        base.OnEnable();
        OnDamageTaken += SpeedBoost;
    }

    private void OnDisable() 
    {
        OnDamageTaken -= SpeedBoost;
    }

    private void SpeedBoost()
    {
        foreach (Enemy enemy in enemyController.SpawnedEnemies)
        {
            if (enemy is SmallSphere)
            {
                enemy.ModifySpeed(10);
            }
        }
    }
}
