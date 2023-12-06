using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    private Rigidbody2D _rigidBody;
    private Vector2 _previousPosition;
    private Vector2 _movement;

    public AnimationClip abiReadyAnim;
    public AnimationClip abiCastFishingRodAnim;
    public AnimationClip abiFishingAnim;
    public AnimationClip abiFishingRodBackAnim;
    public AnimationClip abiIdleAnim;

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
        _movement.y = Input.GetAxisRaw("Vertical");

        if (_rigidBody.position == _previousPosition)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
            if (_movement.x < 0)
                _animator.SetInteger("Direction", 9);
            if (_movement.x > 0)
                _animator.SetInteger("Direction", 3);
            if (_movement.y < 0)
                _animator.SetInteger("Direction", 6);
            if (_movement.y > 0)
                _animator.SetInteger("Direction", 12);


        }
        if (Input.GetMouseButtonDown(0)) 
        {
            _animator.SetTrigger("leftMouseClick");
            _animator.Play(abiReadyAnim.name);
            _animator.ResetTrigger("leftMouseClick");
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            
            _animator.SetTrigger("leftMouseOff");
            _animator.Play(abiCastFishingRodAnim.name);
            _animator.ResetTrigger("leftMouseOff");
        }

        if (Input.GetMouseButtonDown(1)) 
        {   
           
            _animator.SetTrigger("rightMouseClick");
            _animator.Play(abiFishingRodBackAnim.name);
            _animator.ResetTrigger("rightMouseClick");

        }

    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);

        _previousPosition = _rigidBody.position;
    }
}
