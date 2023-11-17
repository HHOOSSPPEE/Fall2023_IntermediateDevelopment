using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

public class PaperContainer : MonoBehaviour
{
    // Start is called before the first frame update
    private int amountOfObject = 0;
    public string nameOfObject;
    public int amountOfObjectNeeded = 4;

    public bool doneCollecting = false;
    
   // public Sprite normalSprite;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(amountOfObject);
        if (amountOfObject == amountOfObjectNeeded)
        {
            //Debug.Log("work");
            doneCollecting = true;
            //the paper clean is complete 
        }
    }

    
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("H");
        if (collider.gameObject.tag == nameOfObject)
        {
            amountOfObject++;
            //Debug.Log(amountOfPaper);
           
        }
    }

    


    void OnTriggerExit2D(Collider2D collider)
    {
       // Debug.Log("H");
        if (collider.gameObject.tag == nameOfObject)
        {
            amountOfObject--;
        }
    }
}
