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
                SceneManager.LoadScene("Level1Design beyza son");
                break;
            case "Level2":
                SceneManager.LoadScene("SampleScene");
                break;
            case "Level3":
                //SceneManager.LoadScene(3);
                break;
            default:
                break;
        }
    }
}
