using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    //end game score
    public int scoreToReach;

    private int player1_Score = 0;
    private int player2_Score = 0;

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    public void Player1Goal()
    {
        player1_Score++;
        player1ScoreText.text = player1_Score.ToString();
        CheckScore();
    }

    public void Player2Goal()
    {
        player2_Score++;
        player2ScoreText.text = player2_Score.ToString();
        CheckScore();
    }

    private void CheckScore()
    {
        if(player1_Score >= scoreToReach)
        {
            SceneManager.LoadScene(2);
            Debug.Log("winner1");
        }

        if (player2_Score == scoreToReach)
        {
            SceneManager.LoadScene(3);
            Debug.Log("winner2");
        }
    }
}
