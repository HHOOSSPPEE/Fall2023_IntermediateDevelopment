using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBounce : MonoBehaviour
{
    public ballMovement ballmovement;
    public scoreManager scoremanager;
    // Start is called before the first frame update

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "player 1")
        {
            positionX = 1;
        }

        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y) / racketHeight;

        ballmovement.IncreaseHitCounter();
        ballmovement.MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "player1" || collision.gameObject.name == "player2")
        {
            Bounce(collision);
        }

        else if(collision.gameObject.name =="leftBorder")
        {
            scoremanager.Player2Goal();
            ballmovement.player1Start = false;
            StartCoroutine(ballmovement.Launch());
        }

        else if (collision.gameObject.name == "rightBorder")
        {
            scoremanager.Player1Goal();
        }
    }
}
