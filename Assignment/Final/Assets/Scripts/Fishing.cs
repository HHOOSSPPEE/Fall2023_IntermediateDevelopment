using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class Fishing : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

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
    public AnimationClip abiFishingRodBackAnim;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        switch (StateController.currentState)
        {

            case FishingState.Fishing:
                Debug.Log("Fishing");
                if (StateController.currentState == FishingState.Fishing)
                {
                    Fish();
                    Hook();
                    ProgressCheck();

                    if (Input.GetMouseButtonDown(1))
                    {
                        StateController.currentState = FishingState.QuickExit;
                    }
                }
                break;

            case FishingState.Win:
                Debug.Log("Win State");

                if (Input.GetMouseButtonDown(1))
                {
                    StateController.currentState = FishingState.QuickExit;
                }
                else
                {
                    StateController.currentState = FishingState.Exit;
                }
                break;



            case FishingState.Lose:
                Debug.Log("Lose State");

                if (Input.GetMouseButtonDown(1))
                {
                    StateController.currentState = FishingState.QuickExit;
                }
                else
                {
                    StateController.currentState = FishingState.Exit;
                }
                break;



            case FishingState.Exit:

                if (pause)
                {
                   
                   
                    StateController.currentState = FishingState.Start;
                    Debug.Log("Exit State");
                }
                pause = false;


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

        if (min < fishPosition && fishPosition < max)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;
            failTimer -= Time.deltaTime;
            if (failTimer < 0 || hookProgress == 0.0f)
            {
                Lose();
            }
        }
        if (hookProgress >= 0.75f)
        {
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0.0f, 0.75f);
    }
    private void Win()
    {
        pause = true;
       
        hookProgress = 0.0f;
        score += 1;
        scoreText.text = " " + score;
        StateController.currentState = FishingState.Win;
        Debug.Log("WIN");
    }

    private void Lose()
    {
        pause = true;
        Debug.Log("Lose");
        hookProgress = 0.0f;
        StateController.currentState = FishingState.Lose;
    }

    void Hook()
    {
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if (hookPosition - hookSize / 2 <= 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if (hookPosition - hookSize / 2 >= 0.75f && hookPullVelocity > 0f)
        {
            hookPullVelocity = 0f;
        }
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
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