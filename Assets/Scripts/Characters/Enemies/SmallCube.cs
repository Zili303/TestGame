public class SmallCube : Enemy, ICube
{
    protected override void OnEnable() 
    {
        base.OnEnable();
        OnRedLineReached += RedLineReached;
    }

    private void OnDisable() 
    {
        OnRedLineReached -= RedLineReached;
    }

    private void RedLineReached()
    {
        foreach (Enemy enemy in enemyController.SpawnedEnemies)
        {
            if (enemy is ICube)
            {
                enemy.ModifyMaxHealth(10);
            }
        }
    }
}
