using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Manager Settings")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform nextSceneSpawnPoint;

    private float waitToLoadTime = 1f;

    private Player _player;


    private void Start()
    {
        SpawnPlayer();

        // _player = FindObjectOfType<Player>();
    }

    public void SpawnPlayer()
    {
        if (player != null)
        {
            Instantiate(player, playerSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Player is null!!");
        }
    }

    public void SpawnPlayerToLevel2()
    {
        if (_player == null)
        {
            // Find the Player component in the scene
            _player = FindObjectOfType<Player>();
        }

        if (_player != null)
        {
            print($"Player is at {playerSpawnPoint.position}");
            StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
            _player.transform.position = nextSceneSpawnPoint.position;
        }
        else
        {
            Debug.LogError("Player is null!!");
        }
    }

    public void SpawnPlayerToLevel1()
    {
        if (_player == null)
        {
            // Find the Player component in the scene
            _player = FindObjectOfType<Player>();
        }

        if (_player != null)
        {
            print($"Player is at {playerSpawnPoint.position}");
            StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex - 1));
            _player.transform.position = playerSpawnPoint.position;
        }
        else
        {
            Debug.LogError("Player is null!!");
        }
    }

    public IEnumerator LoadNextLevel(int levelIndex)
    {
        UIFade.Instance.FadeToBlack();
        yield return new WaitForSeconds(waitToLoadTime);
        SceneManager.LoadScene(levelIndex);
        UIFade.Instance.FadeToClear();
    }
}
