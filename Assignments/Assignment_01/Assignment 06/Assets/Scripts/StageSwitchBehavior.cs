using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSwitchBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int thisStage;
    public int nextStage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (thisStage == GameManager.currentStage)
            {
                GameManager.currentStage = nextStage;
                Destroy(gameObject);
            }
        }
        
            
    }
}
