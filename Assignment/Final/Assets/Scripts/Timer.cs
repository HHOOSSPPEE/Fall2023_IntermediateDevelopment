using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainingTime;
    public int score;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(remainingTime >0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0)
        {
            remainingTime = 0;

            score = 0;
            scoreText.text = " " + score;
            StateController.currentState = FishingState.Exit;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }
}
