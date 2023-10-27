using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreEnd : MonoBehaviour
{

    [SerializeField]
    TMP_Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("score", 0);
        scoreText.text = " " + PlayerPrefs.GetInt("score", 0);
        scoreText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
