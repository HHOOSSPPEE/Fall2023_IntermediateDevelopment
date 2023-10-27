using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PointObject : MonoBehaviour
{
    //public bool pointCollect = false;
    public int addPoint = 0;
    // Start is called before the first frame update
    public float storevalue = 0;
    public AudioClip clips;
    void Start()
    {
        storevalue = GameObject.Find("gameManager").GetComponent<GameManager>().pointsDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Marble")
        {
            //pointCollect = true;
            addPoint += 1;
            storevalue += 500;
            AudioSource.PlayClipAtPoint(clips, transform.position);
            ScoreManager.instance.AddPoint();

            
            Destroy(gameObject);
        }
            
    }
}
