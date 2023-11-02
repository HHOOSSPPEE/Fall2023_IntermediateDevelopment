using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprController : MonoBehaviour
{
    public float movementSpeed = 0.2f;
    // public Rigidbody2D rigidBody;
    private Rigidbody2D _rigidBody;
    private Vector2 _previousPosition;
    private Vector2 _movement;
    private Animator _animator;

    public KeyCode JumpKey;

    
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = gameObject.GetComponent<Rigidbody2D>();   
        _previousPosition = gameObject.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(JumpKey))
        {
            Debug.Log("Up");
        }

        if (_rigidBody.position == _previousPosition)
        {
            _animator.SetBool("isMoving", false);

        }
        else
        {
            _animator.SetBool("isMoving", true);

            if (_movement.x != 0) // ideally use > or <
                _animator.SetInteger("direction", 9);
            if (_movement.y != 0)
                _animator.SetInteger("direction", 6);
       
        }

        
    }

    private void FixedUpdate()
    {
        //-GetComponent<Rigidbody>().MovePosition(-Rigidbody.position + _movement * movementSpeed);
        _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);
        _previousPosition = _rigidBody.position;

    }
}
