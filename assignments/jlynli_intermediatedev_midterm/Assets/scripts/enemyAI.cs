using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    private Rigidbody2D body; //this a reference to the player's rigidbody, which is needed to apply movement in FixedUpdate.
    private Animator anim; //this is a reference to the Animator component, by which we can update parameter's for the Animator state tree.

    public int facing = 12;
    private int currentFacing = 1;

    private bool isMoving = false;

    public float waitingTime = 10f;

    public float lerpAmount;

    public float walkSpeed;
    public float accel;
    public float decel;
    private Vector2 currentSpeed;

    private Vector2 destination;

    private IEnumerator enumerator;

    public bool isChasing = false;

    public BulletSpawner bullet;

    [SerializeField]
    Transform player;

    [SerializeField]
    float aggroRange;

    private bool isAggro;


    private void Start()
    {
        player = GameObject.Find("player").transform;
    }

    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //InvokeRepeating(nameof(CallPatrol), 0, waitingTime);
    }



    // Update is called once per frame
    void Update()
    {
    

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);


        //Debug.Log("distance to player: " + distToPlayer);
        if (distToPlayer < aggroRange && player)
        {
            isAggro = true;

            //cancel invoke stops patrolling
            CancelInvoke();

            var delta = player.transform.position - transform.position;
            delta.Normalize();

            var moveSpeed = walkSpeed * Time.deltaTime;

            transform.position = transform.position + (delta * moveSpeed);

            bullet.numberOfBullets = 20;

            Vector3 rotation = transform.eulerAngles * Mathf.Deg2Rad;
            Debug.Log("this is rotation: " + rotation);

            float toPlayer = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = new Vector3(rotation.x, rotation.y, toPlayer); 

        }
        else
        {
           
            bullet.numberOfBullets = 0;
        }

        if(isAggro)
        {
            aggroRange = 20;
        }
    }


    void CallPatrol()
    {
        StartCoroutine("patrol");

    }
    void PatrolBehavior()
    {

    }

    //coroutine patrol
    private IEnumerator patrol()
    {
        isMoving = true;

        float timer = Time.time;
        Vector2 initialPosition = transform.position;

        //if (currentFacing == 1)
        //{
        //    facing = 12;
        //    Debug.Log("enemy up");
        //}
        //else if (currentFacing == 2)
        //{
        //    facing = 3;
        //    Debug.Log("enemy right");
        //}
        //else if (currentFacing == 3)
        //{
        //    facing = 6;
        //    Debug.Log("enemy down");
        //}
        //else if (currentFacing == 4)
        //{
        //    facing = 9;
        //    Debug.Log("enemy left");

        //}
        //else if (currentFacing == 5)
        //{
        //    //should reset?
        //    currentFacing = 1;
        //    facing = 12;
        //}


        //set destination based on facing direction
        if (facing == 12) //up
        {
            destination.Set(transform.position.x, transform.position.y + lerpAmount);

        }
        else if (facing == 3) //right
        {
            destination.Set(transform.position.x + lerpAmount, transform.position.y);

        }
        else if (facing == 6) //down
        {
            destination.Set(transform.position.x, transform.position.y - lerpAmount);

        }
        else if (facing == 9) //left
        {
            destination.Set(transform.position.x - lerpAmount, transform.position.y);

        }

        //Debug.Log(initialPosition + " " + destination);

        //lerp enemy
        while (isMoving)
        {

            float elapsed = Time.time - timer;
            float lerpTime = elapsed / waitingTime;

            transform.position = Vector2.Lerp(initialPosition, destination, lerpTime);

            yield return new WaitForEndOfFrame();

            if (lerpTime >= 1)
            {
                isMoving = false;
                currentFacing += 1;
            }

        }

        Debug.Log("facing number is: " + currentFacing);
        yield break;

    }



}
