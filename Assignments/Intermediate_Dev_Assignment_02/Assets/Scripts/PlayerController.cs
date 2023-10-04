using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _movementSpeed = 2.0f;
    //public Rigidbody2D rigidBody;

    private Rigidbody2D _rigidBody;
    private Vector2 _previousPosition;
    private Vector2 _movement;

    public KeyCode runKey;  //guess what? I havn't draw this sprite yet!

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
        _movement.y = 0;
        //_movement.y = Input.GetAxisRaw("Vertical");
        //not useful yet

        if (_movement.magnitude != 0)
        {
            if (_movement.x > 0)
            {
                _animator.SetBool("isMoving", true);
                _animator.SetBool("facingRight", true);
            }
            else if (_movement.x < 0)
            {
                _animator.SetBool("isMoving", true);
                _animator.SetBool("facingRight", false);
            }
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
       
        _movement.x -= .1f;
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movementSpeed * Time.deltaTime * _movement);

        _previousPosition = _rigidBody.position;
    }
}
