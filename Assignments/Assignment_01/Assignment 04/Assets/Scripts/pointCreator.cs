using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pointCreator : MonoBehaviour
{
    // Start is called before the first frame update
    public int starAmount = 5;
    public GameObject sampleObject;
    public float minX, maxX, minY, maxY;
    Vector3 myVector;
    List<GameObject> starsList;
    

    void Start()
    {
        StarsMake();
    }

    // Update is called once per frame
    void Update()
    {
        //if (starsList.Count == 0)
        //{
        //    StarsMake();
        //}
        if (GameObject.FindGameObjectsWithTag("Point").Length == 0)
        {
            StarsMake();
        }
    }

    void StarsMake()
    {
        for (int i = 0; i < starAmount; i++)
        {
            var myVector = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0f);
            var newStar = Instantiate(sampleObject, myVector, Quaternion.identity);
            //starsList.Add(newStar);
        }
    }
}
