using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    

    [Header("Rotation variables")]
    public float rotationSpeed;
    public Vector3 viewA;
    public Vector3 viewB;
    public float distance;

    [Header("Raycasting variables")]
    public RaycastHit2D hitInfo;
    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;

    [Header("Patrol variales")]
    public GameObject pointA;
    public GameObject pointB;
    private Transform currentPoint;
    public float movementSpeed;
    private Rigidbody2D rb;

    //PLAYER REFERENCE 
    public static player player;
    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        
        viewA = transform.eulerAngles + new Vector3(transform.position.x, transform.position.y, -55f);
        viewB = transform.eulerAngles + new Vector3(transform.position.x, transform.position.y, -120f);

        currentPoint = pointB.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        patrol();
        
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * rotationSpeed, 1);
        transform.eulerAngles = Vector3.Lerp(viewA, viewB, time);



        hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {


                player.instance.gameObject.SetActive(false);


            }


        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greenColor;
        }

        lineOfSight.SetPosition(0, transform.position);
    }
    private void patrol()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(movementSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2 (-movementSpeed, 0);
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
