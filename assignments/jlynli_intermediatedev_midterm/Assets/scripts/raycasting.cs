using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasting : MonoBehaviour
{

    public static raycasting instance;
    public PlayerMovement playerMove;
    private Vector2 rayDirection;
    public float rayHitbox;
    

    //can edit mask in unity
    public LayerMask mask;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (playerMove.facing == 1) //facing right
        {
            rayDirection = -transform.right;
        }
        else if (playerMove.facing == 3) //facing left
        {
            rayDirection = transform.right;
        }
        else if (playerMove.facing == 2) //facing down
        {
            rayDirection = transform.up;
        }
        else //facing up 
        {
            rayDirection = -transform.up;
        }
    }


    //function to raycast dash that kills stuff
    public void DashCast()
    {
        #region Raycast 2d 
        //raycast2d - send a ray in a direction
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            rayDirection,
            rayHitbox, //set length of raycast
            mask); //goes until hits mask/layer set in unity (?)

        //draw raycast in scene
        Debug.DrawRay(
            transform.position,
            rayDirection * rayHitbox,
            Color.red, 5);

        //if enemy in raycast, destroy enemy
        if (hit.collider != null && hit.collider.tag == "enemy")
        {
            Debug.Log("working yay");
            Destroy(hit.collider.gameObject);
        }
        #endregion
    }
}