using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{

    private Movement movement;
    private bool isMoving;
    private Vector3 origPosition, targetPositon;
    private float timetoMove = 0.2f;

    private void Awake()
    {
        movement = GetComponent<Movement>();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.up));
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.down));
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.right));
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector2.left));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPosition = transform.position;
        targetPositon = origPosition + direction;

        while (elapsedTime < timetoMove)
        {
            transform.position = Vector3.Lerp(origPosition, targetPositon, (elapsedTime / timetoMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPositon;

        isMoving = false;
    }
}