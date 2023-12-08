using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FishingState
{
    Start,
    CastingRod,
    Fishing,
    Win,
    Lose,
    Exit
}

public class Fishing: MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;
    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    float fishTimer;
    [SerializeField] float timeMultiplicator = 3f;

    float fishSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;

    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.01f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;
    [SerializeField] float failTimer = 10f;

    bool pause = false;

    [SerializeField] Transform progressBarContainer;

    public FishingState currentState = FishingState.Start;

    private Animator _animator;

    public AnimationClip abiReadyAnim;
    public AnimationClip abiCastFishingRodAnim;
    public AnimationClip abiFishingAnim;
    public AnimationClip abiFishingRodBackAnim;
    public AnimationClip abiIdleAnim;

    public GameObject FishingGame;

  
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        switch (currentState)
        {
            case FishingState.Start:

                if (Input.GetMouseButtonDown(0))
                {
                    _animator.SetTrigger("leftMouseClick");
                    _animator.Play(abiReadyAnim.name);

                    _animator.ResetTrigger("leftMouseClick");
                    currentState = FishingState.CastingRod;
                }
                break;

            case FishingState.CastingRod:
                
                if (Input.GetMouseButtonUp(0))
                {
                  
                    _animator.SetTrigger("leftMouseOff");
                    _animator.Play(abiCastFishingRodAnim.name);
                    _animator.ResetTrigger("leftMouseOff");
                    currentState = FishingState.Fishing;
                    break;
                }
                if (Input.GetMouseButtonDown(1))
                {
                  
                    _animator.SetTrigger("rightMouseClick");
                    _animator.Play(abiFishingRodBackAnim.name);
                    _animator.ResetTrigger("rightMouseClick");
                    currentState = FishingState.Exit;
                    break;
                }
                break;

            case FishingState.Fishing:
               FishingGame.SetActive(true);
                Fish();
                Hook();
                ProgressCheck();
                if (Input.GetMouseButtonDown(1))
                {
                    _animator.SetTrigger("rightMouseClick");
                    _animator.Play(abiFishingRodBackAnim.name);
                    _animator.ResetTrigger("rightMouseClick");
                    currentState = FishingState.Exit;
                }
                if(pause == true)
                {
                    currentState = FishingState.Win;
                    break;
                }
                if(pause == false)
                {
                    currentState = FishingState.Lose;
                    break;
                }
                break;

            case FishingState.Win:
                             
                _animator.Play(abiFishingRodBackAnim.name);
               
                currentState = FishingState.Exit;
                break;

            case FishingState.Lose:
                
               
                _animator.Play(abiFishingRodBackAnim.name);
                
                currentState = FishingState.Exit;
                break;

            case FishingState.Exit:

                FishingGame.SetActive(false);
               
                 _animator.Play(abiFishingRodBackAnim.name);               
                currentState = FishingState.Start;
                break;
        }
    }

        private void ProgressCheck()
    {
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize / 2;
        float max = hookPosition + hookSize / 2;

        if(min<fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;
            failTimer -= Time.deltaTime;
            if(failTimer < 0 || hookProgress == 0.0f)
            {
                Lose();
            }
        }
        if(hookProgress >= 0.75f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0.0f, 0.75f);
    }
    private void Win()
    {
        pause = true;
        Debug.Log("WIN");
    }

    private void Lose()
    {
        pause = true;
        Debug.Log("Lose");
       
    }

     void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition - hookSize / 2 <= 0f && hookPullVelocity <0f)
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition - hookSize / 2 >= 0.75f && hookPullVelocity >0f)
        {
            hookPullVelocity = 0f;
        }
        hookPosition = Mathf.Clamp(hookPosition, hookSize/2, 1-hookSize/2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
    }

    void Fish()
    {
        fishTimer -= Time.deltaTime;
        if (fishTimer < 0f)
        {
            fishTimer = UnityEngine.Random.value * timeMultiplicator;

            fishDestination = UnityEngine.Random.value;
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }
}
