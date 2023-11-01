using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator bouncer;
    public AudioSource soundEffect;

    void Start()
    {
       
        bouncer = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            soundEffect.Play();
            bouncer.SetTrigger("BouncerTrigger");
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            soundEffect.Play();

        }
    }*/

}
