using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMultiplier = 1.0f;
    public Vector2 initialDirection;
    public LayerMask WallLayer;

    private Vector2 direction;
    private Vector2 nextDirection;
    private Vector3 startingPosition;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        speedMultiplier = 1f;
        direction = initialDirection;
        nextDirection = Vector2.zero;
        transform.position = startingPosition;
        rb.isKinematic = false;
        enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (nextDirection != Vector2.zero)
        {
            SetDirection(nextDirection);
            
        }

        Debug.DrawRay(transform.position, direction, Color.yellow);

    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
        //Debug.Log("Rb Position " + position);
       
    }


    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !cannotMove(direction))
        {
            this.direction = direction;
            nextDirection = Vector2.zero;
            Timer.instance.isRunning = true;
        }
        else
        {
            nextDirection = direction;
            //nextDirection = Vector2.zero;

        }
        Debug.Log(direction);
       
    }
    public bool cannotMove(Vector2 direction)
    {
            RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            Vector2.one * 0.05f,
            0.0f, 
            direction,
            0.0f,
            WallLayer
        );
        Debug.Log(direction + " " + hit.collider != null);
        return hit.collider != null; 
    }
}




