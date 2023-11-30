using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    public T prefab;

    private PoolController<T> poolController;

    private Queue<T> objects = new Queue<T>();

    public T Get()
    {
        if(objects.Count == 0)
        {
            AddObject();
        }

        return objects.Dequeue();
    }

    private void AddObject()
    {
        var newObject = Instantiate(prefab);
        newObject.transform.SetParent(this.transform);
        newObject.gameObject.SetActive(false);
        poolController.AddObjectToSpawnedObjects(newObject);
        objects.Enqueue(newObject);
    }

    public void ReturnToPool(T objectToReturn)
    {
        objectToReturn.gameObject.SetActive(false);
        objects.Enqueue(objectToReturn);
    }

    public void ClearPool()
    {
        objects.Clear();
    }

    public void SetPoolController(PoolController<T> controller)
    {
        poolController = controller;
    }
}
