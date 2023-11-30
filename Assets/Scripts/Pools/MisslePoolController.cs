public class MisslePoolController : PoolController<Missle>
{
    protected override void OnGameStart()
    {
        TurnOfMissles();
    }

    private void TurnOfMissles()
    {
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            spawnedObjects[i].GetComponent<Missle>().Destroy();
        }
    }
}
