using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    private Rigidbody2D _rigidBody;
    private Vector2 _movement;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _movement.normalized * movementSpeed;
    }
}
