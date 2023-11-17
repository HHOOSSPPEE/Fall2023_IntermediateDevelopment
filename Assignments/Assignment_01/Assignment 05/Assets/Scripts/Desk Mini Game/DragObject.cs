using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]


public class DragObject : MonoBehaviour
{

    private Vector3 screenPoint;
    private Vector3 offset;
    [Header("Sprites")]
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public Sprite normalSprite;

    bool pickUp = false;
    bool inCup = false;
   
    

    void OnMouseDown()
    {
       
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        

    }



    void OnMouseDrag()
    {
        
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;

        if (gameObject.tag == "Paintbrush")
        {
            pickUp = true;
            StartCoroutine("ChangeSprite");

        }
        
   
            
    }

     void OnMouseUp()
    {
        if (gameObject.tag == "Paintbrush" && inCup == false)
        {
            pickUp = false;
            StartCoroutine("ChangeSprite");

        }
    }

   
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("H");
        if (collider.gameObject.tag == "Cup")
        {
            pickUp = true;
            inCup = true;
            //Debug.Log(amountOfPaper);

        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        //Debug.Log("H");
        if (collider.gameObject.tag == "Cup")
        {
            //pickUp = ;
            inCup = false;
            //Debug.Log(amountOfPaper);

        }
    }

    void ChangeSprite()
    {
        if (pickUp || inCup)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            spriteRenderer.sprite = normalSprite;
        }
        
    }

    public Vector2 targetPosition;
    public float snapDistance = 1;
    public List<Transform> nodes = new List<Transform>();
    void Update()
    {
       
        //transform.position = targetPosition;
        float smallestDistance = snapDistance;
        foreach (Transform node in nodes)
        {
            if (Vector2.Distance(node.position, targetPosition) < smallestDistance)
            {
                transform.position= node.position;
                smallestDistance = Vector2.Distance(node.position, targetPosition);
            }
        }
    }

}