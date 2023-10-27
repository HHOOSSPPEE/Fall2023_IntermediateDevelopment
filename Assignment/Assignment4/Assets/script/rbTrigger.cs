using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator rb;
    void Start()
    {

        rb = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            rb.SetTrigger("rbTrigger");
        }
    }
}
