using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1_FlipperControl : MonoBehaviour
{
    public float flipperSpeed = 500f; // Adjust the speed as needed
    private HingeJoint2D hingeJoint;

    void Start()
    {
        hingeJoint = GetComponent<HingeJoint2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = -flipperSpeed; // Negative speed for clockwise rotation
            hingeJoint.motor = motor;
        }
        else
        {
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = flipperSpeed; // Positive speed for counter-clockwise rotation
            hingeJoint.motor = motor;
        }
    }
}
