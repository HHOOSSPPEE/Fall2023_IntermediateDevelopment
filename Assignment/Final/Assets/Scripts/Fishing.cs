using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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

    public GameObject FishingGame;

    private Animator _animator;

  
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        switch (StateController.currentState)
        {
            case FishingState.Start:

                
                    //Debug.Log("Cast line");
                    //StateController.currentState = FishingState.CastingRod;
                
                break;

            case FishingState.CastingRod:
                //Debug.Log("Casting");
               

                break;

            case FishingState.Fishing:
               // Debug.Log("Fishing");
                Fish();
                Hook();
                ProgressCheck();
                if (Input.GetMouseButtonDown(1))
                {
                    StateController.currentState = FishingState.Exit;
                }
               /* if(pause == true)
                {
                    StateController.currentState = FishingState.Win;
                    break;
                }
                if(pause == false)
                {
                    StateController.currentState = FishingState.Lose;
                    break;
                }*/
                break;

            case FishingState.Win:

                StateController.currentState = FishingState.Exit;
                break;

            case FishingState.Lose:

                StateController.currentState = FishingState.Exit;
                break;

            case FishingState.Exit:

                Debug.Log("HERE");
                StateController.currentState = FishingState.Start;
               
               
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
