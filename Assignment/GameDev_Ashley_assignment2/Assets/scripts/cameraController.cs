using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;

    private Vector3 _velocity = Vector3.zero;

    public void LateUpdate()
    {
        Transform currentTarget = target;

        Vector3 desiredPosition = currentTarget.position + offset;

        Vector3 smoothedPosition = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref _velocity,
            smoothSpeed);

        transform.position = smoothedPosition;
    }
}
