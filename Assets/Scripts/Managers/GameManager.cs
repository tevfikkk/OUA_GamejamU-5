using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Manager Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPoint;

    // [Space(10)]


    private void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        if (player != null)
        {
            Instantiate(player, playerSpawnPoint.position, Quaternion.identity);
        }
    }
}
