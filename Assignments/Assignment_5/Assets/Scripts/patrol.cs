using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class patrol : MonoBehaviour
{
    [Header("Patrol variales")]
    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    public float movementSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        currentPoint = pointB.transform;
        rb = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        moveAround();
    }
    private void moveAround()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(0, movementSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, -movementSpeed);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}
