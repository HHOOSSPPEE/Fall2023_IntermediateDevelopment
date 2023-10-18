using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //for collisions not triggers
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ouch!");
        }
        //if (collision.gameObject.layer == 1)
        //{
        //    Debug.Log("Ouch!");
        //}


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //for collisions not triggers
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Ouch!");
        }
        //if (collision.gameObject.layer == 1)
        //{
        //    Debug.Log("Ouch!");
        //}


    }
}
