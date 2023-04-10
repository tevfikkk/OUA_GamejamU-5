using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void MainMenu() => SceneManager.LoadScene("MainMenu");

    public void Credits() => SceneManager.LoadScene("Credits");
}
