using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpringController : MonoBehaviour
{
    public Transform targetTransform;
    float distance;
    SpringJoint2D springJoint2D;

    void Start()
    {
        springJoint2D = GetComponent<SpringJoint2D>();
    }

    void Update()
    {
       distance = Vector3.Distance(targetTransform.position, transform.position);

        if (distance < springJoint2D.distance)
        {
            springJoint2D.enabled = false;
        }
    }
}
