public class BigSphere : Enemy, ISphere
{
    protected  override void OnEnable() 
    {
        base.OnEnable();
        OnDamageTaken += SpeedDump;
    }

    private void OnDisable() 
    {
        OnDamageTaken -= SpeedDump;
    }

    private void SpeedDump()
    {
        foreach (Enemy enemy in enemyController.SpawnedEnemies)
        {
            if (enemy is ISphere)
            {
                enemy.ModifySpeed(-10);
            }
        }
    }
}
