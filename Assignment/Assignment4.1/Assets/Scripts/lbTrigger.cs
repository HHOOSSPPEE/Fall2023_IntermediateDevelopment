using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lbTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator lb;
    void Start()
    {

        lb = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            lb.SetTrigger("lbTrigger");
        }
    }
}
