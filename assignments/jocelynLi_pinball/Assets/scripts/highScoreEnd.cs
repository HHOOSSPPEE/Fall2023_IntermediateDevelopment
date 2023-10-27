using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class highScoreEnd : MonoBehaviour
{

    [SerializeField]
    TMP_Text highScoreText;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = " " + PlayerPrefs.GetInt("highScore", 0);
        highScoreText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
