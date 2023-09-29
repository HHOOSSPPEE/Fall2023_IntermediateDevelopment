using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    //public Rigidbody2D rigidBody;
    private Rigidbody2D _rigidBody;
    private Vector2 _previousPosition;
    private Vector2 _movement;

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
        _movement.x = Input.GetAxisRaw("Horizontal"); //move in press A and D /arrow keys
       // _movement.y = Input.GetAxisRaw("Vertical");

        if (_rigidBody.position == _previousPosition)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
            if (_movement.x > 0)
                _animator.SetInteger("direction", 3);
            if (_movement.x < 0)
                _animator.SetInteger("direction", 9);

            /* if (_movement.y < 0)
                 _animator.SetInteger("direction", 6);
            */

        }

    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);

        _previousPosition = _rigidBody.position;
    }
}