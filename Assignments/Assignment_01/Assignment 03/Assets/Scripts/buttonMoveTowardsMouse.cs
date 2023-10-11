using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveTowardsSmoothDamp : MonoBehaviour
{
    public float maxMoveSpeed = 10;
    public float smoothTime = 0.3f;
    public float minDistance = 2;
    Vector2 currentVelocity;
    float currentVelocityThird;

    public float maxTurnSpeed = 90;
    float angle;
    

    void Update()
    {
        Vector2 mousePosition = Input.mousePosition;
        // Offsets the target position so that the object keeps its distance.
        Vector3 mousePositionThird = Input.mousePosition;
        Vector3 direction = mousePositionThird - transform.position;
        float targetAngle = Vector2.SignedAngle(Vector2.right, direction);
        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocityThird, smoothTime, maxTurnSpeed);
        transform.eulerAngles = new Vector3(0, 0, angle);
        mousePosition += ((Vector2)transform.position - mousePosition).normalized * minDistance;
        transform.position = Vector2.SmoothDamp(transform.position, mousePosition, ref currentVelocity, smoothTime, maxMoveSpeed);

    }
}