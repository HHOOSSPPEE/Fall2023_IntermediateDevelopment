using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore",0);
        }
    }


    [SerializeField]
    Rigidbody2D leftBot, rightBot;

    [SerializeField]
    TMP_Text highScoreText,scoreText;

    int score, highScore;

    [SerializeField]
    Vector3 startPos;

  

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScoreText.text = " " + highScore;
        highScoreText.enabled = true;
        Debug.Log(gameObject.name);
        Debug.Log(scoreText);
        scoreText.enabled = true;

        
    }

    internal void UpdateScore(int v, object p)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            leftBot.AddTorque(50f);
        }
        else
        {
            leftBot.AddTorque(-30f);
        }

        if (Input.GetKey(KeyCode.L))
        {
            rightBot.AddTorque(-50f);
        }
        else
        {
            rightBot.AddTorque(30f);
        }
    }

    void OnDestroy()
    {
        savePrefs();
    }

    void savePrefs()
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("highScore", highScore);
        PlayerPrefs.Save();

    }


    public void UpdateScore (int point, int multiply)
    {
        Debug.Log(gameObject.name + "updatescore");
        score = score * multiply;
        score = score + point;
        scoreText.text = " " + score;

        if(score > highScore)
        {
            highScore = score;
            savePrefs();
        }
       
    }

  

}


