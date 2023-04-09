using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : Singleton<SceneManagement>
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Level1":
                print("Level 1");
                GameManager.Instance.SpawnPlayerToLevel2();
                break;
            case "Level2":
                print("Level 2");
                GameManager.Instance.SpawnPlayerToLevel1();
                break;
            case "Level3":
                //SceneManager.LoadScene(2);
                break;
            default:
                break;
        }
    }
}
