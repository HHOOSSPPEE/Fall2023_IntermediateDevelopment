using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
      
      
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.SetDirection(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.SetDirection(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.SetDirection(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.SetDirection(Vector2.right);
        }
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.tag == "Wall") {
    //        ScreenShake.instance.TriggerShake(0.2f, 0.5f);
    //        Debug.Log("WallTouched");

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            ScreenShake.instance.TriggerShake(0.2f, 0.5f);
            Debug.Log("WallTouched");
        }
    }



}
