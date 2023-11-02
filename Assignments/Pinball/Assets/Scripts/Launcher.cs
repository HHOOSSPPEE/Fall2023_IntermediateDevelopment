using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    // Touch Listener
    public bool isTouched = false;
    public bool isKeyPress = false;
    // Ready for Launch
    public bool isActive = true;
    // Timers
    private float pressTime = 0f;
    private float startTime = 0f;

    private SpringJoint2D springJoint;
    private Rigidbody2D rb;
    private float force = 0f;
    //[SerializeField] public float maxForce = 3500f;
    public float storedForce = 0f;

    void Start()
    {

        springJoint = GetComponent<SpringJoint2D>();
        springJoint.distance = 1f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isActive)
        {
            if (Input.GetKeyDown("space"))
            {
                isKeyPress = true;
            }

            if (Input.GetKeyUp("space"))
            {
                isKeyPress = false;
            }

            // If player holds down Space 
            if (isKeyPress == true)
            {
                storedForce += 60f;
                if (startTime == 0f)
                {
                    startTime = Time.time;
                    storedForce = 0f;

                }
            }

            // on keyboard release 
            if (isKeyPress == false && isTouched == false && startTime != 0f)
            {

                force = storedForce;

                // reset values & animation
                pressTime = 0f;
                startTime = 0f;

            }
        }


    }

    private void FixedUpdate()
    {
        // When force is not 0
        if (force != 0)
        {
            // release springJoint and power up
            springJoint.distance = 1f;
            rb.AddForce(Vector3.up * force);
            force = 0;
        }

        // When the plunger is held down
        if (pressTime != 0)
        {
            // retract the springJoint distance and reduce the power
            springJoint.distance = 0.8f;
            rb.AddForce(Vector3.down * 900);
        }
    }
}


