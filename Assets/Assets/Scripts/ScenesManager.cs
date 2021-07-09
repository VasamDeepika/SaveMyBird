using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
