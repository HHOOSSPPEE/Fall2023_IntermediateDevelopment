using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public BoxCollider2D colbox;

    private void Start()
    {
        bool isittrigger = colbox.isTrigger;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Skitty")
            Debug.Log("Ouch!");

        if (collision.gameObject.layer == 1)
            Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DoDamage();
        if (collision.gameObject.tag == "Skitty")
            Debug.Log("Ouch!");

    }

    private void DoDamage()
    {

    }
}
