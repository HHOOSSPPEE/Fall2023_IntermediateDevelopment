using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkBehavior : MonoBehaviour
{
    // Start is called before the first frame update
   
    public SpriteRenderer visible;

    //public UnityEngine.UI.Image img;
    //public float timeDelay = 0.2f;
    void Start()
    {
        InvokeRepeating("TurnOff", 2.50f, 4.0f);
        InvokeRepeating("TurnOn", 3.0f, 4.0f);
        SpriteRenderer visible = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void TurnOff()
    {
        visible.enabled = true;
    }
    void TurnOn()
    {
        visible.enabled = false;
    }



}
