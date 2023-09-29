using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{

    public Transform target;
    public float smoothSpeed = .125f;
    public Vector3 offset;

    private Vector3 _velocity = Vector3.zero;

    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

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

        //from this https://www.youtube.com/watch?v=05VX2N9_2_4&ab_channel=LostRelicGames
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            (Mathf.Clamp(transform.position.y, bottomLimit, topLimit)),
            transform.position.z);

    }

}
