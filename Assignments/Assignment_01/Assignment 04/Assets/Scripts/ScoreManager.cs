using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public Text highscoreText;
    public AudioClip theClip;
    public int score = 0;
    int highscore = 0;


    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
        //highscoreText.text = "HIGHSCORE:" + highscore.ToString() + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        instance = this;
    }

    public void AddPoint()
    {
        score += 1;

        AudioSource.PlayClipAtPoint(theClip, Vector3.zero);
       
        scoreText.text = score.ToString() + " POINTS";
    }
}
