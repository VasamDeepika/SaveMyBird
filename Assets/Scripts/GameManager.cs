using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isGameOver = false;
    
    public Text ScoreText;
    public Text highScoreText;
    public Text timerText;
    
    public int score = 0;
    public int highscore=0;

    public float timeLeft = 5.0f;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } 
    }
    void Start()
    {
        string filePath = Application.persistentDataPath + "/PlayerScore.file";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryReader br = new BinaryReader(fs);

        highscore = (br.ReadInt32());
        fs.Close();
        br.Close();
        highScoreText.text = highscore.ToString();
        //highscore = PlayerPrefs.GetInt("highscore");
    }
    public void DecrementTimer()
    {
        if (isGameOver == false)
        {
            timerText.text = (timeLeft).ToString("0");

            if (timeLeft <= 0)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
    public void IncrementScore()
    {
        if(isGameOver == false)
        {
            score++;
        }
        ScoreText.text = score.ToString();
        if (score > highscore)
        {
            //PlayerPrefs.SetInt("highscore",score);
            string filePath = UnityEngine.Application.persistentDataPath + "/PlayerScore.file";
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(score); // Saving Highscore
            fs.Close();
            bw.Close();
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        DecrementTimer();        
    }
}
