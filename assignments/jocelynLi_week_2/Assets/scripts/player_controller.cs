using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    public float movementSpeed = 1.0f;

    private Rigidbody2D _rigidBody;
    private Vector2 _previousPosition;
    private Vector2 _movement;

    public KeyCode jumpKey;

    private Animator _animator;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        _previousPosition = gameObject.transform.position;

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(jumpKey))
        {
            Debug.Log("Up");
        }

        if(_rigidBody.position == _previousPosition)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);

            if(_movement.x > 0)
            {
                _animator.SetInteger("direction", 9);
            }

            if (_movement.x < 0)
            {
                _animator.SetInteger("direction", 3);
            }
        }

    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);

        _previousPosition = _rigidBody.position;

    }
}
