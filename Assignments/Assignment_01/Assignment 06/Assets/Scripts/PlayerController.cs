using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    //public Rigidbody2D rigidBody;
    public Rigidbody2D _rigidBody;
    public Vector2 _previousPosition;
    private Vector2 _movement;
    //public bool moveAllowed = true;
    public bool rosary = false;
    private Animator _animator;
    public AudioSource auds;
    public GameObject animator;
    public bool useRosary = true;

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
        
       

        if (useRosary)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rosary = true;
            }
            else
            {
                rosary = false;
            }
        }
       

        if (rosary)
        {
            if (!auds.isPlaying)
            {
                auds.Play(0);
            }
            _animator.SetBool("rosary", true);
            Debug.Log("rosary on");
        }

        if (!rosary)
        {
            _animator.SetBool("rosary", false);
            Debug.Log("rosary off");
            auds.Pause();
        }

        //animation
        if (_rigidBody.position == _previousPosition)
        {
            _animator.SetBool("isWalking", false);

        }
        else
        {
            _animator.SetBool("isWalking", true);
            //down
            if (_movement.y > 0)
                _animator.SetInteger("Direction", 2);
                //_movement.x = 0;

            //right
            if (_movement.x > 0)
                _animator.SetInteger("Direction", 1);
                //_movement.y = 0;

            //up
            if (_movement.y < 0)
                _animator.SetInteger("Direction", 0);
            
            //left
            if (_movement.x < 0)
                _animator.SetInteger("Direction", 3);
            
            //left up
        }

        //_animator.SetInteger("Animation", 2);

    }

    private void FixedUpdate()
    {
        // _movement.y = _movement.y + waterSpeed;
        if (!rosary && !animator.activeSelf)
        {
            _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);

            _previousPosition = _rigidBody.position;
        }
    }

   

}
