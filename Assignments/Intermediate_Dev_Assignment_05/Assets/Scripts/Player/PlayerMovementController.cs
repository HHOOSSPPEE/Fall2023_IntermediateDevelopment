using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is a singleton class.
/// This script should and only should be given a single "Player" object unless this game becomes multiplayer.
/// </summary>
public class PlayerMovementController : MonoBehaviour
{
    private static PlayerMovementController instance;
    public static PlayerMovementController Instance => instance;
    #region input

    private float horizontalInput;
    private float verticalInput;
    private float jumpInput;
    private float dashinput;
    [SerializeField] private bool jumpInputActive;
    [SerializeField] private bool dashInputActive;
    [SerializeField] private bool horizontalInputActive;
    [SerializeField] private bool verticalInputActive;

    #endregion

    #region state

    private bool allowMovement = true;
    private bool isFlying = false;
    public bool isJumping = false;

    public enum FacingDirection { Left, Right }
    private FacingDirection facingDirection;

    #endregion

    [SerializeField] private float movementSpeed;
    [SerializeField] private float flightSpeed;
    private float initialGravityScale;

    #region dashing

    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashSpeedDuringFlight = 10f;
    private bool allowDashing = true;
    private bool isDashing = false;
    private Vector2 dashingVelocity;
    private GameObject dashingEffectPrefab;
    private GameObject dashingTrailPrefab;
    #endregion

    #region jumping

    private bool allowJumping = false;
    [SerializeField][Range(0, 50)] private float jumpForce;
    [SerializeField][Range(0, 50)] private float jumpFroceInpulse;
    [SerializeField] private float maxJumpDuration = 0.1f;
    [SerializeField] private float jumpCooldownDuration = 0.1f;
    [SerializeField] private int maxJumpCount = 3;
    private int currentJumpCount = 0;
    private bool inAir = false;
    private bool jumpInputActiveLastFrame = false;
    #endregion

    #region references

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    [Tooltip("the GameObject which Tilemaps belong to")]
    private GameObject grid;

    #endregion

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        dashingEffectPrefab = Resources.Load<GameObject>("Prefabs/DashEffect");
        if (dashingEffectPrefab == null )
            Debug.LogError("Failed to load DashingEffect prefab from Resources.");

        dashingTrailPrefab = Resources.Load<GameObject>("Prefabs/DashingTrail");
        if (dashingTrailPrefab == null)
            Debug.LogError("Failed to load DashingEffect prefab from Resources.");

        initialGravityScale = rb.gravityScale;
    }
    private void Start()
    {
        grid = GameObject.Find("Grid");
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        jumpInput = Input.GetAxisRaw("Jump");
        dashinput = Input.GetAxisRaw("Dash");
        horizontalInputActive = !Mathf.Approximately(horizontalInput, 0f);
        verticalInputActive = !Mathf.Approximately(verticalInput, 0f);
        jumpInputActive = !Mathf.Approximately(jumpInput, 0f);
        dashInputActive = !Mathf.Approximately(dashinput, 0f);

        if (!isFlying)
            CheckIfOnTilemap();

        //movement
        if (allowMovement)
        {
            if (isFlying)
            {
                if (!isDashing)
                    rb.velocity = new Vector2(flightSpeed * horizontalInput, flightSpeed * verticalInput);
                else
                    rb.velocity = dashingVelocity;
                Debug.Log(rb.velocity.ToString());
            }
            else if (isDashing)
                rb.velocity = dashingVelocity;
            else
                rb.velocity = new Vector2(movementSpeed * horizontalInput, rb.velocity.y);

            //chagne facing direction, the sprite by default should facing right
            if (horizontalInputActive)
            {
                bool facingRight;
                if (isFlying)
                    facingRight = horizontalInput > 0f;
                else
                    facingRight = horizontalInput < 0f; //I don't want change sprite... just change the code

                spriteRenderer.flipX = facingRight ? false : true;
                facingDirection = facingRight? FacingDirection.Right : FacingDirection.Left;
            }


            if (allowJumping && jumpInputActive && !isJumping && !jumpInputActiveLastFrame)
                StartJumping();

            if (isJumping)
            {
                if (!jumpInputActive)
                    EndJumping();
                else
                    AddJumpForce();
            }

            if (allowDashing && dashInputActive && !isDashing)
                StartDashing();
        }
        jumpInputActiveLastFrame = jumpInputActive;

        PlayerAnimationController.Instance.SetBool(PlayerAnimationController.BoolParameters.isRunning, horizontalInputActive);
    }
    #region Dash
    [SerializeField] private float dashingDuration = 0.5f;
    [SerializeField] private float dashCooldownDuration = 2.0f;
    private void StartDashing()
    {
        isDashing = true;
        if (isFlying)
        {
            if (!horizontalInputActive && !verticalInputActive)
                dashingVelocity = new Vector2(facingDirection == FacingDirection.Right ? dashSpeedDuringFlight : -dashSpeedDuringFlight, 0);
            else
                dashingVelocity = new Vector2(horizontalInput * dashSpeedDuringFlight, verticalInput * dashSpeedDuringFlight);
            CreateDashingEffect();
        }
        else
            dashingVelocity = new Vector2(facingDirection == FacingDirection.Right ? -dashSpeed : dashSpeed, 0);
        rb.gravityScale = 0;
        StartCoroutine(DashDurationCoroutine(dashingDuration));
    }
    private void interruptDash(bool skipCooldown)
    {
        StopCoroutine(DashDurationCoroutine(dashingDuration));
        if (skipCooldown)
            EnableDash();
        else
            StartCoroutine(DashCooldownCoroutine(dashCooldownDuration));
    }
    private void EndDash()
    {
        isDashing = false;
        allowDashing = false;
        StartCoroutine(DashCooldownCoroutine(dashCooldownDuration));
        rb.gravityScale = isFlying ? 0 : initialGravityScale;
    }
    private void EnableDash()
    {
        allowDashing = true;
    }
    private void CreateDashingEffect()
    {
        Instantiate(dashingEffectPrefab).transform.position = transform.position;
        Instantiate(dashingTrailPrefab).transform.position = transform.position;
    }
    public bool GetIsDashing() => isDashing;
    private IEnumerator DashDurationCoroutine(float durationSecond)
    {
        yield return new WaitForSeconds(durationSecond);

        EndDash();
    }
    private IEnumerator DashCooldownCoroutine(float durationSecond)
    {
        yield return new WaitForSeconds(durationSecond);

        EnableDash();
    }

    #endregion

    #region Jump

    private void StartJumping()
    {
        //The first jump should be on the ground
        if (inAir && currentJumpCount == 0)
            currentJumpCount++;
        if (currentJumpCount >= maxJumpCount)
        {
            DisableJump();
            return;
        }
        isJumping = true;
        currentJumpCount++;
        PlayerAnimationController.Instance.SetBool(PlayerAnimationController.BoolParameters.isJumping, true);
        StartCoroutine(StopJumping(maxJumpDuration));
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(new Vector2(0, jumpFroceInpulse), ForceMode2D.Impulse);
        Debug.Log("Here start jumping" + currentJumpCount);
    }
    private void InterruptJumping()
    {
        StopCoroutine("StopJumping");
        EndJumping();
    }
    private void EndJumping()
    {
        isJumping = false;
        if (currentJumpCount >= maxJumpCount)
            DisableJump();
        else
            StartCoroutine(JumpCooldown(jumpCooldownDuration));
        PlayerAnimationController.Instance.SetBool(PlayerAnimationController.BoolParameters.isJumping, false);

    }
    private void ResetJump()
    {
        currentJumpCount = 0;
        EnableJump();
    }
    private void AddJumpForce()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }
    private void EnableJump()
    {
        allowJumping = true;
    }
    private void DisableJump()
    {
        allowJumping = false;
    }
    private IEnumerator StopJumping(float durationSecond)
    {
        yield return new WaitForSeconds(durationSecond);

        EndJumping();
    }
    private IEnumerator JumpCooldown(float durationSecond)
    {
        yield return new WaitForSeconds(durationSecond);

        EnableJump();
    }

    #endregion

    #region Flight

    public void StartFlying()
    {
        isFlying = true;
        rb.gravityScale = 0;
        CreateDashingEffect();
    }
    public void StopFlying()
    {
        isFlying= false;
        rb.gravityScale = initialGravityScale;
        CreateDashingEffect();
    }


    #endregion

    #region basics

    public FacingDirection GetFacingDirection() => facingDirection;
    private void CheckIfOnTilemap()
    {
        Vector2 bottomCenter = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y + .1f);
        RaycastHit2D[] hits = Physics2D.RaycastAll(bottomCenter, Vector2.down, 0.3f);
        Debug.DrawRay(bottomCenter, Vector2.down * 0.1f, Color.red);

        GameObject playerLayerTile = GameObject.Find("PlayerLayerTilemap");

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject == playerLayerTile)
            {
                //if stands on tile
                ResetJump();
                inAir = false;
                PlayerAnimationController.Instance.SetBool(PlayerAnimationController.BoolParameters.inAir, false);
                return;
            }
        }
        // If does not stand on any player layer tile
        inAir = true;
        PlayerAnimationController.Instance.SetBool(PlayerAnimationController.BoolParameters.inAir, true);
    }
    public void EnableMovement()
    {
        allowMovement = true;
    }
    public void DisableMovement()
    {
        allowMovement = false;
        rb.velocity = Vector2.zero;
    }


    #endregion
}
