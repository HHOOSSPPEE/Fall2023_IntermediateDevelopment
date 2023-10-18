using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    //public Rigidbody2D rigidBody;
    private Rigidbody2D _rigidBody;
    private Vector2 _previousPosition;
    private Vector2 _movement;

    public KeyCode jumpKey = KeyCode.K;

    private Animator _animator;

    public float waterSpeed = 0.1f;

    public float boostSpeed = 2f;

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
            //Debug.Log("Up");
            _movement.x = Input.GetAxisRaw("Horizontal")*boostSpeed;
            _movement.y = Input.GetAxisRaw("Vertical")*boostSpeed;
        }

        if (_rigidBody.position == _previousPosition)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
            //up
            if (_movement.y > 0 && _movement.x == 0)
                _animator.SetInteger("direction", 1);
            //right up
            if (_movement.y > 0 && _movement.x > 0)
                _animator.SetInteger("direction", 2);
            //right
            if (_movement.y == 0 && _movement.x > 0)
                _animator.SetInteger("direction", 3);
            //right down
            if (_movement.y < 0 && _movement.x > 0)
                _animator.SetInteger("direction", 4);
            //down
            if (_movement.y < 0 && _movement.x == 0)
                _animator.SetInteger("direction", 5);
            //down left
            if (_movement.y < 0 && _movement.x < 0)
                _animator.SetInteger("direction", 6);
            //left
            if (_movement.y == 0 && _movement.x < 0)
                _animator.SetInteger("direction", 7);
            //left up
            if (_movement.y > 0 && _movement.x < 0)
                _animator.SetInteger("direction", 8);

        }
    }

    private void FixedUpdate()
    {
        //_movement.y = _movement.y + waterSpeed;
        _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);

        _previousPosition = _rigidBody.position;
    }
}
