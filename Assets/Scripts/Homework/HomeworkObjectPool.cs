using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkObjectPool : MonoBehaviour
{
    public static HomeworkObjectPool Instance;

    private Queue<GameObject> pooledObjects = new Queue<GameObject>(); // Sira yapisi
    private int amountToPool = 10; // Pool'da kac tane obje olacak

    [SerializeField] private GameObject homeworkPrefab; // Pool'da olusturulacak obje
    private GameObject poolParent; // Pool'daki objelerin parent'i

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Yeni bir GameObject olustur
        poolParent = new GameObject("Homework Pool");

        // Parent'i bu script'e bagla
        poolParent.transform.parent = transform;

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(homeworkPrefab, poolParent.transform);
            obj.SetActive(false);
            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetObject()
    {
        if (pooledObjects.Count == 0)
        {
            // Pool'da obje yoksa yeni bir obje olustur
            GameObject obj = Instantiate(homeworkPrefab);
            pooledObjects.Enqueue(obj);

            print("Pool is empty, creating new object");
        }

        GameObject pooledObject = pooledObjects.Dequeue();
        pooledObject.SetActive(true);

        return pooledObject;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pooledObjects.Enqueue(obj);
    }
}
