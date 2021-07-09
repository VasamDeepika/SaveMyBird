using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Start()
    {
        Invoke("Menu", 2.0f);
    }
    public void Menu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
