using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Manager Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private Transform spawnPoint3;

    public Vector3 playerSpawnPointPos { get; set; }
    public Vector3 spawnPoint1Pos { get; set; }
    public Vector3 spawnPoint2Pos { get; set; }
    public Vector3 spawnPoint3Pos { get; set; }

    private Cinemachine.CinemachineVirtualCamera vcam;

    private float waitToLoadTime = 1f;

    protected override void Awake()
    {
        base.Awake();

        playerSpawnPointPos = playerSpawnPoint.position;
        spawnPoint1Pos = spawnPoint1.position;
        spawnPoint2Pos = spawnPoint2.position;
    }
}
