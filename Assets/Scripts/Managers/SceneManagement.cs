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
            case "Street":
                SceneManager.LoadScene(0);
                break;
            case "Level1":
                SceneManager.LoadScene(1);
                break;
            case "Level2":
                SceneManager.LoadScene(2);
                break;
            default:
                break;
        }
    }
}
