using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;
    public Vector3 minValues, maxValues;

    private Vector3 _velocity = Vector3.zero;

    public void LateUpdate()
    {
        Transform currentTarget = target;

        Vector3 desiredPosition = currentTarget.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(desiredPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(desiredPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(desiredPosition.z, minValues.z, maxValues.z)
            );

        Vector3 smoothedPosition = Vector3.SmoothDamp(
           transform.position,
           boundPosition,
           ref _velocity,
           smoothSpeed);

        transform.position = smoothedPosition;
    }

}
