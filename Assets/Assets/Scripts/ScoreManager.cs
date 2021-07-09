using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.instance.score.ToString();
        timerText.text = PlayerMovement.instance.t.ToString();
    }

}
