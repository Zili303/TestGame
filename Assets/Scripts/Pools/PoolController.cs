using System.Collections.Generic;
using UnityEngine;

public abstract class PoolController<T> : MonoBehaviour where T : Component
{
    [SerializeField] private GameStateController gameStateController;

    private ObjectPool<T>[] pools;
    protected List<T> spawnedObjects = new List<T>();

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

    protected void Start() 
    {
        GetPools();
        SetupPoolsControllers();
    }

    protected virtual void OnGameStart()
    {
        
    }

    protected virtual void OnGameEnd()
    {
        
    }

    protected virtual void GetPools()
    {
        pools = GetComponentsInChildren<ObjectPool<T>>();
        Debug.Log("POOLS: " + pools.Length);
    }

    private void SetupPoolsControllers()
    {
        foreach (ObjectPool<T> pool in pools)
        {
            pool.SetPoolController(this);
        }
    }

    public void ReturnAllObjectsToPool()
    {
        foreach (T obj in spawnedObjects)
        {
            foreach (ObjectPool<T> pool in pools)
            {
                if (obj.GetType() == pool.GetType())
                {
                    pool.ReturnToPool(obj);
                }
            }
        }
    }

    public void AddObjectToSpawnedObjects(T obj)
    {
        spawnedObjects.Add(obj);
    }

    public void DestroyAllSpawnedObjects()
    {
        foreach (T obj in spawnedObjects)
        {
            Destroy(obj.gameObject);
        }

        ClearSpawnedObjectsList();
        ClearPools();
    }

    public void ClearSpawnedObjectsList()
    {
        spawnedObjects.Clear();
    }

    public void ClearPools()
    {
        foreach (ObjectPool<T> pool in pools)
        {
            pool.ClearPool();
        }
    }
}
