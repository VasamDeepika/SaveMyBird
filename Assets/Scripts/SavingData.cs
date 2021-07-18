using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json.Linq;

public class SavingData : MonoBehaviour
{
   /* public static SavingData instance;
    public string gameName;
    private float timeleft;
    private int playerScore;
    private int playerSpeed;
    private int playerJumpForce;

    private void Awake()
    {
        instance = this;
    }
    public void SavePlayerData()
    {
        timeleft = GameManager.instance.timeLeft;
        playerScore = GameManager.instance.score;
        playerSpeed = ((int)PlayerMovement.instance.speed);
        playerJumpForce = ((int)PlayerMovement.instance.force);
        string filePath = Application.persistentDataPath + "/PlayerData.file";

        JObject jName = new JObject();
        jName.Add("Name", this.gameName);
        
        JObject gameData = new JObject();
        jName.Add("GameData", gameData);
        gameData.Add("TimeLeft", this.timeleft);
        gameData.Add("PlayerScore", this.playerScore);
        JObject jdata = new JObject();
        gameData.Add("PalyerData", jdata);
        jdata.Add("PlayerSpeed", this.playerSpeed);
        jdata.Add("PlayerJumpSpeed", this.playerJumpForce);

        StreamWriter sw = new StreamWriter(filePath);
        sw.WriteLine(jName.ToString());
        sw.Close();   
    }

    public void GetPlayerData()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.file";

        StreamReader sr = new StreamReader(filePath);
        string data = sr.ReadToEnd();
        sr.Close();


        JObject dataDemo = JObject.Parse(data);
        timeleft = dataDemo["GameData"]["TimeLeft"].Value<int>();
        playerScore = dataDemo["GameData"]["PlayerScore"].Value<int>();
        int t = 60 - (int)timeleft;
        print("You have scored " + playerScore + " points in " + t + " seconds");

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SavePlayerData();

        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GetPlayerData();
        }
    }*/
}
