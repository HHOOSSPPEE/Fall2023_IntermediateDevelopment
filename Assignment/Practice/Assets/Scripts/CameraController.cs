using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;
    private Vector3 _velocity = Vector3.zero;
    public Vector3 minValue, maxValue;
    // Start is called before the first frame update

    public void LateUpdate()
    {
        Transform currentTarget = target;
        Vector3 desiredPosition = currentTarget.position + offset;
        /*Vector3 boundPosition = new Vector3(Mathf.Clamp(desiredPosition.x, minValue.x, maxValue.x),
                                            Mathf.Clamp(desiredPosition.y, minValue.y, maxValue.y),
                                            Mathf.Clamp(desiredPosition.z, minValue.z, maxValue.z));*/
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref _velocity, smoothSpeed);

        transform.position = smoothedPosition;
    }
    


        
}

