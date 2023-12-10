using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Movement movement;
    public bool isMoving;
    public bool canMove;

    public LineRenderer trail;
    private Vector3 previousPositin;


    private void Awake()
    {
        movement = GetComponent<Movement>();    
      
    }
    private void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                movement.SetDirection(Vector2.up);
                trail.SetPosition(1, transform.position);
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
               movement.SetDirection(Vector2.down);
                trail.SetPosition(1, transform.position);
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                movement.SetDirection(Vector2.left);
                trail.SetPosition(1, transform.position);
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
               movement.SetDirection(Vector2.right);
                trail.SetPosition(1, transform.position);
            }

     }

   

}
