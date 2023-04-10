using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void MainMenu() => SceneManager.LoadScene("EntranceScene01");

    public void DialogScene() => SceneManager.LoadScene("DıalogueScene");

    public void Credits() => SceneManager.LoadScene("CreditScene");

    public void Level1() => SceneManager.LoadScene("Level1Design");

    public void Exit() => Application.Quit();
}
