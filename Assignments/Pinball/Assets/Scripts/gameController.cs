using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gamecontroller : MonoBehaviour
{

    private int score = 0;
    public TextMeshProUGUI scoreText;
   

    public void trackScore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;
    }
}

