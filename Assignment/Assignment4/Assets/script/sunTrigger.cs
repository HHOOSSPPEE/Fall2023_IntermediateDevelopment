using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator sun;
    void Start()
    {
        
        sun = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            sun.SetTrigger("sunTrigger");
        }
    }
}
