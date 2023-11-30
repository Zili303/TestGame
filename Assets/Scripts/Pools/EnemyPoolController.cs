public class EnemyPoolController : PoolController<Enemy>
{
    protected override void OnGameStart()
    {
        DestroyAllSpawnedObjects();
    }
}
