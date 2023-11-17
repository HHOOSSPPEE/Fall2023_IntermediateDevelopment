using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D waterCol;
    public Collider2D plotCol;

    public Collider2D plantCol;
    public Camera myCam;

    public bool pickUpCan = false;
    public bool waterInCan = false;
    public bool growUp = false;
    GameManager gm;
    //private Vector2 mousecoordinates;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 mousecoordinates = myCam.ScreenToWorldPoint(Input.mousePosition);
        //GameObject[] flowers = GameObject.FindGameObjectsWithTag("Flower");
        //foreach (GameObject f in flowers)
        //    if (f.GetComponent<Collider2D>().OverlapPoint(mousecoordinates) && Input.GetMouseButtonUp(0))
        //    {
        //        Debug.Log("canplantnow");
        //        f.GetComponent<PlantID>().Plant();
        //    }
        
    }
}

        //if (pickUpCan)
        //{
        //    Vector2 mousecoordinates = myCam.ScreenToWorldPoint(Input.mousePosition);
        //    if (Input.GetMouseButtonUp(0) && waterCol.OverlapPoint(mousecoordinates))
        //    {
        //        Debug.Log("collectedWater");
        //        waterInCan = true;
        //    }

        //    if (waterInCan)
        //    {
        //        if (Input.GetMouseButtonUp(0) && plotCol.OverlapPoint(mousecoordinates))
        //        {
        //            growUp = true;
        //            waterInCan = false;
                    
        //        }

               
        //    }
    //    }
        
           
    //}

    //private void OnMouseUp()
    //{
    //    pickUpCan = true;
    //}



