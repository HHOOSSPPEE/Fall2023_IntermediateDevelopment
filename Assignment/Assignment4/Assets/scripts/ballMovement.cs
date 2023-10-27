using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool player1Start = true;

    private int hitCounter = 0;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }

    //restart the ball position once a player get score
    private void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
    }

    public IEnumerator Launch()
    {
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        //if player1 start the first time player2 will start next round
        if(player1Start == true)
        {
            MoveBall(new Vector2(-1, 0));
        }

        else
        {
            MoveBall(new Vector2(1, 0));
        }
        
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter + extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }
}
