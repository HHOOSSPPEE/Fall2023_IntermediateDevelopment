using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Skitty")
            Debug.Log("Ouch!");
        if (collision.gameObject.layer == 1)
            Debug.Log("Ouch!");
    }
}
