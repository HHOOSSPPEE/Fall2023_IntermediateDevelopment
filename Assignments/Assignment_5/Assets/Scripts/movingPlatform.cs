using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    [Header("Movement variales")]
    public float movementSpeed;
    public int startingPoint;
    private int i;
    public Transform[] points;
 

    private void Start()
    {
        transform.position = points[startingPoint].position;

    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, points[startingPoint].position) < 0.002f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].position, movementSpeed * Time.deltaTime);
    }
   
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}