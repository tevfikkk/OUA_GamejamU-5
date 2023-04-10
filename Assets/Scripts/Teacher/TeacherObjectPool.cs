using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;

    private Queue<GameObject> objectPool;

    private void Start()
    {
        objectPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (objectPool.Count == 0)
        {
            // Pool'da obje yoksa yeni bir obje olustur
            GameObject obj = Instantiate(objectPrefab);
            objectPool.Enqueue(obj);

            print("Pool is empty, creating new object");
        }

        GameObject pooledObject = objectPool.Dequeue();
        pooledObject.SetActive(true);

        return pooledObject;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }
}
