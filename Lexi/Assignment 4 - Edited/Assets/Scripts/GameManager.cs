using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score;

    public string scoretext;
    public TextMeshProUGUI mainScoreText;

    public GameObject canvas;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
    }

    public void ResetRoom()
    {
        SceneManager.LoadScene("SampleScene");
        
    }


    public void IncreaseScore(int number)
    {

        score += number;

    }

    public void ResetScore()
    {
        score = 0;
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.score = 0;
    }

}
