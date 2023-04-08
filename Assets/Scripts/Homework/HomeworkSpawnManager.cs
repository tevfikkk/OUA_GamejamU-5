using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkSpawnManager : MonoBehaviour
{
    [Header("Homework Spawn Settings")]
    [SerializeField] private GameObject homeworkPrefab; // Homework prefab
    [SerializeField] private float spawnSpeedDelay = 2f; // Homeworkun spawn hizi
    [SerializeField] private float destoyHomeworkDelay = 5f; // Homeworkun yok olma hizi

    [Header("Spawner Movement Settings")]
    [SerializeField] private float movingSpeed = 5f; // Homeworkun spawn konumunu hareket ettirme hizi
    [SerializeField] private float spawnDistance = 1f; // Homeworkun spawn mesafesi

    private Vector3 spawnPos; // Homeworkun spawn konumu
    private Homework homework;

    private Coroutine spawnHomeworkCoroutine; // Homeworkun spawn fonksiyonu

    private void Start()
    {
        spawnPos = transform.position; // Homeworkun spawn konumunu kaydet

        if (spawnHomeworkCoroutine == null)
            spawnHomeworkCoroutine = StartCoroutine(SpawnHomework()); // Homeworkun spawn fonksiyonunu calistir (Coroutine
    }

    private void Update()
    {
        StartCoroutine(MoveSpawnManager()); // Homeworkun spawn konumunu hareket ettir
    }

    private IEnumerator SpawnHomework()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnSpeedDelay);

            GameObject homework = HomeworkObjectPool.Instance.GetObject(); // Get the homework object from the object pool

            if (homework != null)
            {
                homework.transform.position = transform.position; // Set the position of the homework object
                homework.SetActive(true); // Activate the homework object
            }
        }

        // GameObject homework = HomeworkObjectPool.Instance.GetObject(); // Homework objesini pool'dan al

        // if (homework != null)
        // {
        //     while (true)
        //     {
        //         yield return new WaitForSeconds(spawnSpeedDelay);

        //         Instantiate(homework, transform.position, Quaternion.identity);
        //         homework.SetActive(true);
        //     }
        // }
    }

    private IEnumerator MoveSpawnManager()
    {
        while (true)
        {
            transform.position = Vector3.right * Mathf.Sin(Time.time * movingSpeed) * spawnDistance + spawnPos; // Homeworkun spawn konumunu hareket ettir
            yield return null;
        }
    }
}
