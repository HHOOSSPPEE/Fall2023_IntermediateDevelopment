using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class sTrigger : MonoBehaviour
{
    public Animator s;
    void Start()
    {

        s = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            s.SetTrigger("sTrigger");
        }
    }
}
