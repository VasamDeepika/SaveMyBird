using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Newtonsoft.Json.Linq;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2;// Movement speed
    public float force = 300;

    Rigidbody2D rb;
    Animator anim;

    AudioSource Audio;
    public AudioClip foodClip;
    public AudioClip enemyClip;

    private int playerHealth = 0;

    public Text healthText;
    public int t = 0;

    public string gameName;
    private float timeleft;
    private int playerScore;
    private float playerSpeed;
    private float playerJumpForce;

    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Audio.clip = enemyClip;
            Audio.Play();
            playerHealth--;
            healthText.text = playerHealth.ToString();
            if (playerHealth < 0)
            {
                SavePlayerData();//saving data after player death
                GameManager.instance.isGameOver = true;
                anim.SetTrigger("Dead");
                GetPlayerData();//loading score and time in seconds after player death
                StartCoroutine(ChangeAfter2Seconds()); 
            }
        }
        if (collision.gameObject.tag == "Food")
        {
            GameManager.instance.IncrementScore();
            //anim.SetTrigger("Move");
            Audio.clip = foodClip;
            Audio.Play();
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Life")
        {
            playerHealth++;
            collision.gameObject.SetActive(false);
            healthText.text = playerHealth.ToString();
        }
    }

    IEnumerator ChangeAfter2Seconds()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("EndScene"); //EndScene will load after 2 seconds of player death
    }

    void SavePlayerData()
    {
        timeleft = GameManager.instance.timeLeft;
        playerScore = GameManager.instance.score;
        playerSpeed = speed;
        playerJumpForce = force;
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
        t = 60 - (int)timeleft;
        print("You have scored " + playerScore + " points in " + t + " seconds"); //to do - UI
    }
}