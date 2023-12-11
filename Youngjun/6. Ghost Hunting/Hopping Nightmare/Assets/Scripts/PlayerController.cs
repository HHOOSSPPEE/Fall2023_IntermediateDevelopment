using TMPro;
using UnityEngine;

public enum PlayerState
{
    Idle, 
    Walk, 
    Attack,
}

public class PlayerController : MonoBehaviour
{
    public Transform attackPos;
    public LayerMask enemyLayer;
    public float attackRange;

    /*
    float timeBtwAttack;
    float startTimeBtwAttack = 0.3f;
    */

    bool canAttack = true;
    float damage = 1f;

    float moveSpeed = 12f;
    Vector3 targetPosition;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    PlayerState currentState = PlayerState.Idle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (canAttack && Input.GetMouseButton(0))
        {
            currentState = PlayerState.Attack;
            targetPosition = transform.position;
            UpdateAnimation();
            return;
        }

        if (Input.GetMouseButton(1) && currentState != PlayerState.Attack)
        {
            if (canAttack && Input.GetMouseButton(0))
            {
                currentState = PlayerState.Attack;
                rb.velocity = Vector2.zero;
                UpdateAnimation();
                return;
            }
            else
            {
                currentState = PlayerState.Walk;
                UpdateAnimation();
                GetMousePosition();
            }

        }

        if (rb.velocity == Vector2.zero && currentState != PlayerState.Attack)
        {
            currentState = PlayerState.Idle;
            UpdateAnimation();
        }

        SetDirection();

        //Debug.Log(rb.velocity.x + " " + rb.velocity.y);
        //Debug.Log(GetPlayerDirection().x + " " + GetPlayerDirection().y);
        //Debug.Log(Vector2.Distance(transform.position, targetPosition));
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, targetPosition) > 0.2f)
        {
            rb.velocity = (targetPosition - transform.position).normalized * moveSpeed;
        }
        else rb.velocity = Vector2.zero;
            
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        targetPosition = mousePosition;
    }
    public Vector2 GetPlayerDirection() //left, right, up, down
    {
        Vector2 direction = Vector2.zero;

        if (rb.velocity != Vector2.zero)
        {
            if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
            {
                if (rb.velocity.x > 0)
                {
                    direction = new Vector2(1, 0);
                }
                else direction = new Vector2(-1, 0);
            }
            else
            {
                if (rb.velocity.y > 0)
                {
                    direction = new Vector2(0, 1);
                }
                else direction = new Vector2(0, -1);
            }
        }
        return direction;
    }

    void Attack()
    {
        canAttack = false;
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<NightmareController>().TakeDamage(damage);
        }
    }

    void FinishAttack()
    {
        canAttack = true;
        if (canAttack && Input.GetMouseButton(0))
        {
            currentState = PlayerState.Attack;
        }
        else currentState = PlayerState.Idle;
    }

    void SetDirection()
    {
        NightmareController nightmareController = FindObjectOfType<NightmareController>();
        float direction = Mathf.Sign(nightmareController.transform.position.x - transform.position.x);
        transform.localScale = new Vector3(direction, 1, 1);

    }

    void UpdateAnimation()
    {
        animator.SetInteger("PlayerState", (int)currentState);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
