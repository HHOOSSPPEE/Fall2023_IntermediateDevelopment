using BennetTools;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a singleton class.
/// This script should and only should be given a single "Player" object unless this game becomes multiplayer.
/// </summary>
public class PlayerAnimationController : MonoBehaviour
{
    private static PlayerAnimationController instance;
    public static PlayerAnimationController Instance => instance;
    public Animator animator { get; private set; }
    [SerializeField] private BloodSuckingDetector bloodSuckingDetector;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D playerCollider;
    private BoxCollider2D bloodSuckingDetectionCollider;
    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<BoxCollider2D>();
        instance = this;
        bloodSuckingDetectionCollider = bloodSuckingDetector.GetComponent<BoxCollider2D>();
        bloodSuckingDetector.OnEnemyDetected += HandleOnEnemyBloodSuckingDetected;
    }
    private void Update()
    {
        playerCollider.AdjustColliderToFitSprite(spriteRenderer);
        var clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length > 0)
        {
            // Debug.Log(clipInfo[0].clip.name); what the hell is playing
            if (clipInfo[0].clip.name.Equals("Idle"))
                animator.ResetTrigger("endCasting");
        }
    }
    private void HandleOnEnemyBloodSuckingDetected(GameObject enemyObject)
    {
        SetTrigger(AnimationTrigger.enterBloodSuckingLoop);
    }

    private void OnDestroy()
    {
        bloodSuckingDetector.OnEnemyDetected -= HandleOnEnemyBloodSuckingDetected;
    }
    public void SwitchToAnimation(string name)
    {
        animator.Play(name);
    }
    public enum AnimationTrigger
    {   
        startCasting, enterCastingLoop , endCastingLoop , endCasting , //casting
        startTransformation, endTransformation, //transformation
        startBloodSucking, enterBloodSuckingLoop, endBloodSuckingLoop, //blood sucking
        backToIdle
    }
    public void SetTrigger(AnimationTrigger tigger)
    {
        animator.SetTrigger(tigger.ToString());
        /*
        var val = Tools.GetCallerMethodName();
        Debug.Log(val);
        */
    }

    public enum BoolParameters
    { 
        isRunning, isJumping, inAir, isFlying, isCasting 
    }
    public void SetBool(BoolParameters parameter, bool value) => animator.SetBool(parameter.ToString(), value);
    public void SetBoolTrue(BoolParameters parameter) => animator.SetBool(parameter.ToString(), true);
    public void SetBoolFalse(BoolParameters parameter) => animator.SetBool(parameter.ToString(), false);
    public void SetAnimation(string name)
    {
        animator.Play(name);
    }
    public void StartBloodSuckingDetection()
    {
        bloodSuckingDetector.StartDetection();
    }
    public void EndBloodSuckingDetection() => bloodSuckingDetectionCollider.enabled = false;
}
