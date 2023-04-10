using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Level1":
                SceneManager.LoadScene("Level1Design");
                break;
            case "Level2":
                SceneManager.LoadScene("Level2Design");
                break;
            case "FinishDialog":
                SceneManager.LoadScene("FinishDialogue");
                break;
            default:
                break;
        }
    }
}
