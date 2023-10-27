using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject newGameObj;
    public Rigidbody2D rb2d;
    private HingeJoint2D jointRef;
    private JointMotor2D motorRef;
    public float speed = 300;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        jointRef = GetComponent<HingeJoint2D>();
        motorRef = jointRef.motor;
        //jointRef.useLimits{ 20f:20f }

        jointRef.useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchHinge()
    {
        speed = speed * -1;
        var motor = jointRef.motor;
        motor.motorSpeed = speed;
        jointRef.useMotor = true;
        //newGameObj.GetComponent<HingeJoint2D>().motor get: motorAmt};

    }
}
