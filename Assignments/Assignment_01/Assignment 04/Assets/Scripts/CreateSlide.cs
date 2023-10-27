using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSlide : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject marblePiece;

    public GameObject sampleObject;
    private int amtObj = 0;
    public bool objAdd = true;
    private GameObject objNew;
    float minX = -10, maxX = 10;
    float minY = -10, maxY = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sampleObject.transform.position.x < 0 || sampleObject.transform.position.x > Screen.width ||
         sampleObject.transform.position.y < 0 || sampleObject.transform.position.y > Screen.height)
        {
            //Destroy(sampleObject);
            Debug.Log(sampleObject.transform.position.y);
        }

        if (amtObj >= 5)
        {
            objAdd = false;
        }
        if (objNew == null)
        {
            objAdd = true;
            amtObj = 0;
        }

    }

  

    public void AddObject()
    {
        if (objAdd == true)
        {
            var myVector = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            objNew = Instantiate(sampleObject, Vector3.zero, Quaternion.identity);
            //Debug.Log(marblePiece.transform.position.y);
            amtObj += 1;
            Debug.Log(Screen.height);
        }
        
        
    }
}

