using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    SpringJoint2D springJoint;
    float distanceToPlayer;

    Transform selfTransform;
    public Transform targetTransform;
    public float eyeForce;
    public float springDistance;
    public Animator stormAnimator;
    float i_StormAnimatorSpeed;

    // Start is called before the first frame update
    void Start()
    {
        selfTransform = transform;

        springJoint = GetComponent<SpringJoint2D>();
        springJoint.enabled = false;

        i_StormAnimatorSpeed = stormAnimator.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            springJoint.enabled = false;
            springJoint.distance = springDistance;
            stormAnimator.speed = 0f;
        }
        else
        {
            distanceToPlayer = Vector2.Distance(selfTransform.position, targetTransform.position);

            if (distanceToPlayer < springDistance)
            {
                springJoint.enabled = true;
            }
            else springJoint.enabled = false;

            if (springJoint.enabled)
            {
                if (springJoint.distance > eyeForce)
                {
                    springJoint.distance -= eyeForce;
                }
                else springJoint.enabled = false;
            }
            else springJoint.distance = springDistance;

            stormAnimator.speed = i_StormAnimatorSpeed;
        }

    }
}