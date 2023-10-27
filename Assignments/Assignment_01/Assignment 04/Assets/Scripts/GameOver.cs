using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public GameObject canvas2;
    
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " points";
        canvas2 = GameObject.Find("Canvas");
        canvas2.SetActive(false);
        
    }
}
