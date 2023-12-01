using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class player : MonoBehaviour
{
    public static player instance;

    //MOVEMENT
    private Rigidbody2D rb;
    [Range(1, 50)]
    public float speed = 10;
    public float moveX;
    public float moveY;
    

    //JUMP
    [Range(1, 50)]
    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowMultiplier = 2f;
    //Double Jump
    private int maxJumps = 2;
    private int jumpsRemaining;


    //GROUNDED
    private BoxCollider2D boxColl;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;

    //WALL CHECK
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    private bool isWallSliding;
    public float wallSlidingSpeed = 5f;

    //Wall Jump
    private bool isWallJumping;
    private float WalljumpDirection;
    private float wallJumpTime = 0.2f;
    private float wallJumpCount;
    private float wallJumpDuration = 0.4f;
    private Vector2 wallJumpPower = new Vector2(8f, 16f);

    //ANIMATION
    private Animator animator;
    private bool facingRight;

    //INVISIBILITY
    private SpriteRenderer spriteRenderer;
    public bool invisible;
    public bool waitTime;

    //PARTICLE SYSTEM
    private GameObject Burst;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
        jumpsRemaining = maxJumps;
        instance = this;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        invisible = false;
  
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(moveX, moveY);

        Walk(dir);

        if (moveX > 0 && facingRight)
        {
            Flip();
        }

        if (moveX < 0 && !facingRight)
        {
            Flip();
        }

        #region JUMP


        //if player jumps and and he has jumps available
        if (Input.GetButtonDown("Jump") && jumpsRemaining > 0)
        {
            animator.SetBool("isJumping", true);
            //Jump up and take away one jump
            Jump();
            jumpsRemaining -= 1;
        }

        if (isGrounded() && rb.velocity.y <= 1)
        {

            //Reset Jumps
            jumpsRemaining = maxJumps;
            animator.SetBool("isJumping", !isGrounded());
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            animator.SetBool("isJumping", !isGrounded());
        }
        else if (rb.velocity.y < 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowMultiplier - 1) * Time.deltaTime;

        }

        if (Input.GetButtonDown("Jump") && rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 2f); 
        }

        #endregion

        wallSlide();
        WallJump();
        TurnInvisible();

    }

    private void FixedUpdate()
    {
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);

        if (!isWallJumping) 
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        }
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));

    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpVelocity;
        animator.SetBool("isJumping", !isGrounded());

    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            WalljumpDirection = -transform.localScale.x;
            wallJumpCount = wallJumpTime;
            CancelInvoke(nameof(StopWallJump));
        }
        else
        {
            wallJumpCount -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpCount > 0f)
        {
            
            isWallJumping = true;
            rb.velocity = new Vector2 (WalljumpDirection * wallJumpPower.x, wallJumpPower.y);
            wallJumpCount = 0f;

            if (transform.localScale.x != WalljumpDirection)
            {
                Flip();
            }
            Invoke(nameof(StopWallJump), wallJumpDuration);
        }
    }

    private void StopWallJump()
    {
        isWallJumping = false;
    }


    private bool isGrounded()
    {
        //return Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0f, Vector2.down, .1f, groundLayer);
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void wallSlide()
    {
        if (isWalled() && !isGrounded()) 
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Math.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));

        }
        else
        {
            isWallSliding = false;
        }

        

    }
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void TurnInvisible()
    {
       if (invisible == true)
        {
            spriteRenderer.color = Color.clear;

        }
        else
        {
            spriteRenderer.color = Color.white;
        }
     
    }
    
}