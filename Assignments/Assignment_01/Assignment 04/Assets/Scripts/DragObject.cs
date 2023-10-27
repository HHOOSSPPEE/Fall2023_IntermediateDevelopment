using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]


public class DragObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;

    private bool ifCollided = false;

    private int collisionCount = 0;

    private int timerCollision = 0;
    public int timerLimit = 0;
     bool hasJoint;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //for collisions not triggers
        if (collision.gameObject.tag == "Marble")
        {
            //ifCollided = true;
            //Debug.Log("in");
            collisionCount++;
        }
       
         
        

    }

  
    void OnCollisionExit2D(Collision2D collision)
    {
        //for collisions not triggers

        if (collision.gameObject.tag == "Marble")
        {
            //ifCollided = true;
            //Debug.Log("out");
            collisionCount--;

        }

        //if (collision.gameObject.GetComponent<Rigidbody2D>() != null && !hasJoint && collision.gameObject.tag == "Tubes")
        //{
        //    Debug.Log("Yes");
        //    gameObject.AddComponent<FixedJoint2D>();
        //    gameObject.GetComponent<FixedJoint2D>().connectedBody = collision.rigidbody;
        //    gameObject.GetComponent<FixedJoint2D>().breakForce = 2;
        //    hasJoint = true;
        //}

    

    }

    void Update()
    {
        Debug.Log(collisionCount);


        if (collisionCount == 0)
        {
            timerCollision++;
            
        }

        if (collisionCount > 0)
        {
            ifCollided = false;
            //Debug.Log("in");
            timerCollision = 0;
        }

        if (timerCollision >= timerLimit)
        {
            ifCollided = false;
            //Debug.Log("out");
            timerCollision = 0;
        }
    }



    void OnMouseDown()
    {
        if (ifCollided == false)
        {
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        }

        

    }



    void OnMouseDrag()
    {
        if (ifCollided == false)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            if (Input.GetKeyDown("space"))
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x *= -1;
                gameObject.transform.localScale = newScale;
            }
        }


        

    }

    

}

