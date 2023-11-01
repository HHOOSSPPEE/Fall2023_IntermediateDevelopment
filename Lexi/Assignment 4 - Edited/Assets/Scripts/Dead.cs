using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    
    // Start is called before the first frame update
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
            if (gameManager != null)
            {
                /*
                gameManager.newScore = gameManager.score;
                gameManager.mainScoreText.text = "" + gameManager.newScore;
                Debug.Log(gameManager.newScore);
                */
                gameManager.ResetRoom();
                
            }
            
        } 
    }
       
    

}
