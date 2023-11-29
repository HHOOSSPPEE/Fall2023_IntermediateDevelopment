using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 offset;
    Vector3 closestJointPosition;
    Vector3 lastPosition;

    private PolygonCollider2D[] polygonColliders;

    int randomSpriteNumber;
    Sprite selectedSprite;
    SpriteRenderer childSpriteRenderer;
    public Sprite[] sprites;

    public string myTopFace;
    public string myLeftFace;
    public string myRightFace;

    bool isMyTopFaceTouched;
    bool isMyLeftFaceTouched;
    bool isMyRightFaceTouched;

    List<GameObject> collidedGameObjects = new List<GameObject>();

    float life;
    public bool permanent = false; 

    private string[] topFaces = 
        new string[] { "water", "water", "water", "water", 
                       "thunder", "thunder", "thunder", "thunder",
                       "earth", "earth", "earth", "earth",
                       "flame", "flame", "flame", "flame", 
                       "single", "single", "single", "single", 
                       "multiple", "multiple", "multiple", "multiple"};

    private string[] leftFaces =
        new string[] { "multiple", "single", "earth", "flame",
                       "multiple", "earth", "flame", "single",
                       "water", "multiple", "thunder", "single",
                       "multiple", "thunder", "single", "water",
                       "thunder", "earth", "water", "flame",
                       "flame", "earth", "water", "thunder"};

    private string[] rightFaces =
        new string[] { "earth", "flame", "single", "multiple",
                       "flame", "multiple", "single", "earth",
                       "multiple", "thunder", "single", "water",
                       "water", "multiple", "thunder", "single",
                       "flame", "thunder", "earth", "water",
                       "water", "thunder", "earth", "flame"};


    void Start()
    {
        if (!permanent)
        {
            life = 30f;
            Destroy(gameObject, life);
        }

        randomSpriteNumber = Random.Range(0, 24);
        selectedSprite = sprites[randomSpriteNumber];

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
                new Vector2(-1.3f, 0.8f), //left
                new Vector2(0, 1.4f), //top
                new Vector2(1.3f, 0.75f), //right
                //new Vector2(0, 0.2f) //bottom
            };
            polygonColliders[0].points = points;
        }

        if (polygonColliders[1] != null) //left
        {
            Vector2[] points = new Vector2[]
            {
                new Vector2(-1.4f, 0.8f), //tleft
                new Vector2(-0.1f, 0.1f), //tright
                //new Vector2(-0.1f, -1.3f), //bright
                new Vector2(-1.4f, -0.5f) //bleft
            };
            polygonColliders[1].points = points;
        }

        if (polygonColliders[2] != null) //right
        {
            Vector2[] points = new Vector2[]
            {
                new Vector2(0.1f, 0.1f), //tleft
                new Vector2(1.4f, 0.65f), //tright
                new Vector2(1.3f, -0.4f), //bright
                //new Vector2(0.05f, -1.2f) //bleft
            };
            polygonColliders[2].points = points;
        }

        myTopFace = topFaces[randomSpriteNumber];
        myLeftFace = leftFaces[randomSpriteNumber];
        myRightFace = rightFaces[randomSpriteNumber];

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
        }
        else
        {
            lastPosition = transform.position;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GameObject closestJoint = FindClosestObject<DiceJoint>();
            GameObject closestDice = FindClosestObject<Dice>();

            if (closestDice != null && Vector2.Distance(transform.position, closestDice.transform.position) < 5f)
            {
                transform.position = lastPosition;
            }
            else if (closestJoint != null)
            {
                closestJointPosition = closestJoint.transform.position;
                transform.position = closestJointPosition;
            }
            else transform.position = lastPosition;

            isDragging = false;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < polygonColliders.Length; i++)
        {
            if (!polygonColliders[i].IsTouchingLayers())
            {
                if (i == 0)
                {
                    isMyTopFaceTouched = false;
                }
                if (i == 1)
                {
                    isMyLeftFaceTouched = false;
                }
                if (i == 2)
                {
                    isMyRightFaceTouched = false;
                }
            }
        }

        if (isMyTopFaceTouched)
        {
            myTopFace = null;
        }
        else myTopFace = topFaces[randomSpriteNumber];

        if (isMyLeftFaceTouched)
        {
            myLeftFace = null;
        }
        else myLeftFace = leftFaces[randomSpriteNumber];

        if (isMyRightFaceTouched)
        {
            myRightFace = null;
        }
        else myRightFace = rightFaces[randomSpriteNumber];
    }

    GameObject FindClosestObject<T>() where T : Component
    {
        T[] objects = FindObjectsOfType<T>();
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (T obj in objects)
        {
            if (obj.gameObject != gameObject)
            {
                float distance = Vector3.Distance(obj.transform.position, currentPosition);

                if (distance < closestDistance)
                {
                    closestObject = obj.gameObject;
                    closestDistance = distance;
                }
            }
        }

        if (closestDistance <= 1)
        {
            return closestObject;
        }
        return null;
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


    void OnTriggerStay2D(Collider2D collision)
    {
        PolygonCollider2D polyCollider = collision.GetComponent<PolygonCollider2D>();

        if (polyCollider != null)
            //&& !collidedGameObjects.Contains(collision.gameObject))
        {
            //collidedGameObjects.Add(collision.gameObject);

            Dice diceComponent = collision.gameObject.GetComponent<Dice>();
            if (childSpriteRenderer.sortingOrder < diceComponent.childSpriteRenderer.sortingOrder)
            {
                isMyTopFaceTouched = polygonColliders[0].IsTouching(collision);
                isMyLeftFaceTouched = polygonColliders[1].IsTouching(collision);
                isMyRightFaceTouched = polygonColliders[2].IsTouching(collision);

            }
        }   
    }

}



