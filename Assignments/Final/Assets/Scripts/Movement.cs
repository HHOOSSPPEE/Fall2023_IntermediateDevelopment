using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager;
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
    }


    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if (forced || !cannotMove(direction))
        {
            this.direction = direction;
            this.nextDirection = Vector2.zero;
        }
        else
        {
            nextDirection = direction;
        }
    }

    public bool cannotMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,
            Vector2.one * 0.75f,
            0.0f,
            direction,
            1.5f,
            WallLayer
        );
        return hit.collider != null;
        
    }


}
