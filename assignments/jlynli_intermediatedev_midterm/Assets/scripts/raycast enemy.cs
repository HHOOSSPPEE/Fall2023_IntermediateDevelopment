using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEnemy : MonoBehaviour
{

    public static RaycastEnemy instance;

    public enemyAI enemy;

    private Vector2 rayDirection;
    public float rayHitbox;
    public bool chasingPlayer = false;


    //can edit mask in unity
    public LayerMask mask;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //rays rirection
        if (enemy.facing == 3) //facing right
        {
            rayDirection = transform.right;
        }
        else if (enemy.facing == 9) //facing left
        {
            rayDirection = -transform.right;
        }
        else if (enemy.facing == 6) //facing down
        {
            rayDirection = -transform.up;
        }
        else //facing up 
        {
            rayDirection = transform.up;
        }
    }

    public void patrolRaycast()
    {
        Debug.Log("enemy raycasting");
        //raycast to detect player or not
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
            Color.red);

        //if enemy in raycast, destroy enemy
        if (hit.collider != null && hit.collider.tag == "player")
        {
            Debug.Log("CHASE AFTER PLAYER");
            chasingPlayer = true;
        }

    }
}
