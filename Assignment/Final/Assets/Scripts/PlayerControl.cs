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

    AnimatorStateInfo stateinfo;

    public GameObject FishingGame;

    private Animator _animator;

   // public FishingState fishingState;

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

        stateinfo = _animator.GetCurrentAnimatorStateInfo(0);

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
        switch (StateController.currentState)
        {
            case FishingState.Start:
                if (Input.GetMouseButtonDown(0) && !FishingGame.activeSelf)
                {
                    StateController.currentState = FishingState.Start;
                    _animator.SetTrigger("leftMouseClick");
                    _animator.Play(abiReadyAnim.name);

                    _animator.ResetTrigger("leftMouseClick");
                    StateController.currentState = FishingState.CastingRod;
                    Debug.Log("Start");
                }
               
                
                break;

            case FishingState.CastingRod:
                if (Input.GetMouseButtonUp(0) && !FishingGame.activeSelf)
                {
                    //Debug.Log("CastingFishRod");
                    _animator.SetTrigger("leftMouseOff");
                    _animator.Play(abiCastFishingRodAnim.name);

                    _animator.ResetTrigger("leftMouseOff");
                    StateController.currentState = FishingState.Fishing;
                    Debug.Log("CastingRod");
                }
                
       
                break;

            case FishingState.Fishing:  
                if (stateinfo.IsName("abi_fishing"))
                {
                    FishingGame.SetActive(true);
                    Debug.Log("Fishing");
                }
                

                break;
            case FishingState.QuickExit:

                    _animator.SetTrigger("rightMouseClick");
                    _animator.Play(abiFishingRodBackAnim.name);
                    StateController.currentState = FishingState.Exit;
                    _animator.ResetTrigger("rightMouseClick");

                    Debug.Log("Exit the game.");
                    _animator.SetTrigger("gameEnd");
                    _animator.ResetTrigger("gameEnd");

                    FishingGame.SetActive(false);
                StateController.currentState = FishingState.Start;
                break;

            case FishingState.Exit:
                _animator.Play(abiFishingRodBackAnim.name);
                FishingGame.SetActive(false);
                StateController.currentState = FishingState.Start;

                    Debug.Log("Exit");
                break;
        }

    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * movementSpeed);

        _previousPosition = _rigidBody.position;
    }
}