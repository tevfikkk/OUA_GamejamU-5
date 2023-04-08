using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private float spawnRate = 1f;

    private UnityEvent onPlatformSpawned;

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     Spawn();
        // }
    }

    public void Spawn()
    {
        Instantiate(platformPrefab, transform.position, Quaternion.identity, transform.parent);
        onPlatformSpawned?.Invoke();
    }
}
