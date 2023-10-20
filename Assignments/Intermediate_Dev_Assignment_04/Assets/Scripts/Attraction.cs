using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    public float gravitationalConstant = .981f;
    public float attractionRange = 1000.0f;
    public float attractionForce = 1.0f;
    public bool followMouse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followMouse)
        {
            var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new(mouseWorldPos.x, mouseWorldPos.y);
        }
    }
    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, attractionRange);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            if (rb != null && rb.bodyType == RigidbodyType2D.Dynamic)
            {
                Vector2 direction = new Vector2(transform.position.x,transform.position.y) - rb.position;
                float distance = direction.magnitude;

                if (distance > 0.1f) // Avoid division by zero.
                {
                    float forceMagnitude = (gravitationalConstant * rb.mass) / (distance * distance);
                    Vector2 force = direction.normalized * attractionForce * forceMagnitude;
                    rb.AddForce(force);
                }
            }
        }
    }
}
