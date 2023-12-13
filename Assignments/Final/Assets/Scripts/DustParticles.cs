using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustT : MonoBehaviour
{
    [SerializeField] ParticleSystem movementtrails;

    [Range(0, 10)]
    [SerializeField] private int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] private float dustlifetime;

    [SerializeField] Rigidbody2D player;

    private float counter;

    private void Update()
    {
        //Timer
        counter += Time.deltaTime;
        //Debug.Log(counter);
        Debug.Log("Velocity " + player.velocity.x);

        //When the player moves,
        if (player.velocity.x < occurAfterVelocity)

        { 
            //Check to see if the time has past the dustlifetime
            if (counter > dustlifetime)
            {
                //if it has, play the dust particle and reset the timer
                movementtrails.Play();
                counter = 0;
            }
        }
    }

}
