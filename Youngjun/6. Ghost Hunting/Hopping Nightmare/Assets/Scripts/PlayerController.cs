using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask enemyLayer;
    public float attackRange;
    int damage = 1;

    float moveSpeed = 5f;
    Vector3 targetPosition;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetMousePosition();
        }

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<NightmareController>().TakeDamage(damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
        Debug.Log(rb.velocity.x + " " + rb.velocity.y);
        //Debug.Log(GetPlayerDirection().x + " " + GetPlayerDirection().y);
    }

    private void FixedUpdate()
    {
        rb.velocity = (targetPosition - transform.position).normalized * moveSpeed;
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
        return Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y)
            ? new Vector2(Mathf.Sign(rb.velocity.x), 0)
            : new Vector2(0, Mathf.Sign(rb.velocity.y));
    }

    /*
    Vector2 GetPlayerDirection() //left, right, up, down
    {
        Vector2 direction = Vector2.zero;

        if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.y))
        {
            if (rb.velocity.x > 0)
            {
                direction = new Vector2 (1,0);
            }
            else direction = new Vector2 (-1,0);
        }
        else
        {
            if (rb.velocity.y > 0)
            {
                direction = new Vector2(0, 1);
            }
            else direction = new Vector2(0, -1);
        }

        return direction;
    }
    */

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
