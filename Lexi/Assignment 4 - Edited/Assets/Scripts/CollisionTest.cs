using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CollisionTest : MonoBehaviour
{
    public bool type;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if(gameManager != null)
            {
                if (type)
                {
                    gameManager.IncreaseScore(100);
                }
                else
                {
                    gameManager.IncreaseScore(10);
                }
            }
        }
    }
}
