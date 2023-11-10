using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;

public class Dice : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;
    private string targetTag = "DiceJoint";
    Vector3 closestJointPosition;

    private PolygonCollider2D[] polygonColliders;

    int randomSpriteNumber;
    Sprite selectedSprite;
    SpriteRenderer childSpriteRenderer;
    public Sprite[] sprites;



    void Start()
    {
        randomSpriteNumber = Random.Range(1, 25);
        selectedSprite = sprites[randomSpriteNumber - 1];

        childSpriteRenderer = GetChildSpriteRendererByName("DiceSprite");

        if (selectedSprite != null)
        {
            childSpriteRenderer.sprite = selectedSprite;
        }

        polygonColliders = GetComponents<PolygonCollider2D>();

        if (polygonColliders[0] != null) //Top
        {
            Vector2[] points = new Vector2[]
            {
                new Vector2(-1.3f, 0.85f), //left
                new Vector2(0, 1.4f), //top
                new Vector2(1.3f, 0.8f), //right
                new Vector2(0, 0.2f) //bottom
            };
            polygonColliders[0].points = points;
        }

        if (polygonColliders[1] != null) //left
        {
            Vector2[] points = new Vector2[]
            {
                    new Vector2(-1.4f, 0.8f), //tleft
                    new Vector2(-0.05f, 0.1f), //tright
                    new Vector2(-0.1f, -1.3f), //bright
                    new Vector2(-1.4f, -0.7f) //bleft
            };
            polygonColliders[1].points = points;
        }

        if (polygonColliders[2] != null) //left
        {
            Vector2[] points = new Vector2[]
            {
                    new Vector2(0.05f, 0.1f), //tleft
                    new Vector2(1.4f, 0.65f), //tright
                    new Vector2(1.3f, -0.6f), //bright
                    new Vector2(0.05f, -1.2f) //bleft
            };
            polygonColliders[2].points = points;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        if (childSpriteRenderer != null)
        {
            childSpriteRenderer.sortingOrder = Mathf.RoundToInt(11 - (transform.position.y * 10));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);

            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - mousePosition;
            }
        }

        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x + offset.x, mousePosition.y + offset.y);

            GameObject closestJoint = FindClosest(targetTag);

            if (closestJoint != null)
            {
                closestJointPosition = closestJoint.transform.position;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            transform.position = closestJointPosition;
        }
    }

    GameObject FindClosest(string tag)
    {
        GameObject[] DiceJoints = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestJoint = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject obj in DiceJoints)
        {
            float distance = Vector3.Distance(obj.transform.position, currentPosition);

            if (distance < closestDistance)
            {
                closestJoint = obj;
                closestDistance = distance;
            }
        }
        
        return closestJoint;
    }

    SpriteRenderer GetChildSpriteRendererByName(string childObjectName)
    {
        Transform childTransform = transform.Find(childObjectName);

        if (childTransform != null)
        {
            SpriteRenderer childSpriteRenderer = childTransform.GetComponent<SpriteRenderer>();
            return childSpriteRenderer;
        }

        return null;
    }
}

