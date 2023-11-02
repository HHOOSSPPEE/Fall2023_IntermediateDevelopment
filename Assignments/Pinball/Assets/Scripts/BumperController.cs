using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public Gamecontroller gamecontroller;
    public AudioSource bounce;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Ball")
        {
            gamecontroller.trackScore();
            bounce.Play();

        }
        
    }
    
}
