using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControlledArmAxis : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode controllKey;
    public float rotatingAngleLimit;
    public float rotationSpeed;
    public RotationDirection rotationDirection;
    private float _angularVelocity;
    private quaternion _initialRotation;
    private bool rotating = false;
    private Rigidbody2D _rigidbody2d;

    public enum RotationDirection { Clockwise, CounterClockwise}
    void Start()
    {
        _initialRotation = transform.rotation;
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(controllKey)) 
        {
            if (rotationDirection == RotationDirection.Clockwise) // set velocity
                _angularVelocity = rotationSpeed * Time.deltaTime;
            else
                _angularVelocity = -rotationSpeed * Time.deltaTime;

        }
        if (Input.GetKeyUp(controllKey))
        {

        }

        if (rotating)
        {
            _rigidbody2d.AddTorque(_angularVelocity);
        }
    }
}
