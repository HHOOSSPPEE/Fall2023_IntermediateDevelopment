using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCouter : MonoBehaviour
{
    TextMeshProUGUI tmp;
    
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            tmp.text = ""+ gameManager.score;
        }
    }
}
