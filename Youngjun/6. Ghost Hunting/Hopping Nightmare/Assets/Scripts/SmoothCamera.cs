using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    /*
    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;

    private Vector3 _velocity = Vector3.zero;

    public void FixedUpdate()
    {
        Transform currentTarget = target;

        Vector3 desiredPosition = currentTarget.position + offset;

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, smoothSpeed);

        transform.position = smoothPosition;
    }
    */
    public Transform target;
    float smoothSpeed = 0.125f;
    Vector3 offset = new Vector3(0f, 0f, -10f);
    float maxLeft = -10f;
    float maxRight = 10f;
    float maxUp = 10f;
    float maxDown = -10f;

    private Vector3 _velocity = Vector3.zero;

    public void FixedUpdate()
    {
        Transform currentTarget = target;

        Vector3 desiredPosition = currentTarget.position + offset;

        float clampedX = Mathf.Clamp(desiredPosition.x, maxLeft, maxRight);
        float clampedY = Mathf.Clamp(desiredPosition.y, maxDown, maxUp);
        desiredPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, smoothSpeed);

        transform.position = smoothPosition;
    }
}
