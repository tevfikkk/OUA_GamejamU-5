using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeworkSpawnManager : MonoBehaviour
{
    [Header("Homework Spawn Settings")]
    [SerializeField] private GameObject homeworkPrefab; // Homework prefab
    [SerializeField] private float spawnSpeedDelay = 2f; // Homeworkun spawn hizi

    [Header("Spawner Movement Settings")]
    [SerializeField] private float movingSpeed = 5f; // Homeworkun spawn konumunu hareket ettirme hizi
    [SerializeField] private float spawnDistance = 1f; // Homeworkun spawn mesafesi

    private Vector3 spawnPos; // Homeworkun spawn konumu

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

            Instantiate(homeworkPrefab, transform.position, Quaternion.identity);
        }
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
