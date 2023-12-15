using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public enum NightmareState
{
    Idle, 
    Chase, 
    Bite, 
    Blink,
    TeleportBite,
    Dash, 
    Teleport,
}

public class NightmareController : MonoBehaviour
{
    [HideInInspector] public float i_hp;
    [HideInInspector] public float hp;
    [HideInInspector] public NightmareState currentState;

    public Transform attackPos;
    public LayerMask playerLayer;
    public float attackRange;

    public GameObject illusion;
    public GameObject EndingScreen1;
    public GameObject EndingScreen2;

    Animator animator;
    Rigidbody2D rb;

    int stateNumber;
    float delayTimer;
    float delayInterval = 1f;
    float moveSpeed = 0f;
    float moveSpeedChase = 5f;
    float moveSpeedDash = 50f;
    float dashTimer;
    float dashTimeInterval = 0.2f;
    float chaseOffset = 1f;
    bool isMovingToPlayer = false;

    Vector3 playerPosition;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        i_hp = 30f;
        hp = i_hp;
        currentState = NightmareState.Idle;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case NightmareState.Idle:
                Idle();
                break;
            case NightmareState.Chase:
                Chase();
                break;
            case NightmareState.Bite:
                Bite();
                break;
            case NightmareState.Blink:
                Blink();
                break;
            case NightmareState.TeleportBite:
                TeleportBite();
                break;
            case NightmareState.Dash:
                Dash();
                break;
            case NightmareState.Teleport:
                Teleport();
                break;

            
        }

        if (isMovingToPlayer)
        {
            MoveToPlayer();
        }
    }

    void FixedUpdate()
    {
        

        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    void Idle()
    {
        UpdateAnimation();

        moveSpeed = 0f;

        delayTimer += Time.deltaTime;

        if (delayTimer >= delayInterval)
        {
            delayTimer = 0f;
            stateNumber = Random.Range(0, 5);
            switch (stateNumber)
            {
                case 0:
                    currentState = NightmareState.Chase;
                    break;
                case 1:
                    currentState = NightmareState.Chase;
                    break;
                case 2:
                    currentState = NightmareState.Bite;
                    break;
                case 3:
                    currentState = NightmareState.Blink;
                    break;
                case 4:
                    currentState = NightmareState.Blink;
                    break;
            }
        }
    }

    void Chase()
    {
        UpdateAnimation();

        moveSpeed = moveSpeedChase;
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        direction = playerPosition - transform.position;
        direction.Normalize(); 

        int dashChance = Random.Range(0, 100);
        if (dashChance == 0)
        {
            currentState = NightmareState.Dash;
            return;
        }

        if (Vector2.Distance(playerPosition, transform.position) <= chaseOffset)
        {
            currentState = NightmareState.Bite;
        }
    }

    void Dash()
    {
        UpdateAnimation();

        moveSpeed = moveSpeedDash;
        direction = GetMousePosition() - transform.position;
        direction.Normalize();

        if (dashTimer >= dashTimeInterval)
        {
            dashTimer = 0f;
            currentState = NightmareState.Bite;
        }
        else dashTimer += Time.deltaTime;

    }

    void Bite()
    {
        UpdateAnimation();

        if (!isMovingToPlayer)
        {
            moveSpeed = 0f;
            direction = transform.position;
        }
        
    }

    void TeleportBite()
    {
        UpdateAnimation();

        if (!isMovingToPlayer)
        {
            moveSpeed = 0f;
            direction = transform.position;
        }

    }

    void MoveToPlayer()
    {
        if (Vector2.Distance(transform.position, playerPosition) <= 12f)
        {
            moveSpeed = moveSpeedChase * 1.5f;
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            direction = playerPosition - transform.position;
            direction.Normalize();
        }
    }

    void SetIsMovingToPlayer()
    {
        isMovingToPlayer = !isMovingToPlayer;
    }

    void FinishBite()
    {
        currentState = NightmareState.Idle;
    }

    void Attack()
    {
        Collider2D[] targetToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerLayer);
        for (int i = 0; i < targetToDamage.Length; i++)
        {
            targetToDamage[i].GetComponent<PlayerController>().TakeDamage(1);
        }
    }

    void Blink()
    {
        UpdateAnimation();

        moveSpeed = 0f;
    }

    void SpawnIllusions()
    {
        TVController[] tvControllers = FindObjectsOfType<TVController>();

        for (int i = 0; i < Mathf.Min(1, tvControllers.Length); i++)
        {
            int numberOfTVs = Random.Range(0, tvControllers.Length);
            TVController randomTV = tvControllers[numberOfTVs];

            if (randomTV != null)
            {
                GameObject newIllusion = Instantiate(illusion, randomTV.transform.position, Quaternion.identity);
                newIllusion.GetComponent<NightmareIncoming>().direction = Mathf.Sign(tvControllers[numberOfTVs].transform.localScale.x);
            }
        }
    }

    void FinishBlink()
    {
        currentState = NightmareState.Idle;
    }

    void Teleport()
    {
        NightmareIncoming[] nightmareIncomings = FindObjectsOfType<NightmareIncoming>();
        NightmareIncoming selectedIllusion = nightmareIncomings[Random.Range(0, nightmareIncomings.Length)];
        Vector3 offset = new Vector3 (selectedIllusion.direction * 5, -1, 0);
        transform.position = selectedIllusion.transform.position + offset;
        currentState = NightmareState.TeleportBite;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            if (FindObjectOfType<PlayerController>().hp == FindObjectOfType<PlayerController>().i_hp)
            {
                EndingScreen2.SetActive(true);
            }
            else EndingScreen1.SetActive(true);

            Destroy(gameObject);
        }
    }

    void UpdateAnimation()
    {
        animator.SetInteger("NightmareState", (int)currentState);
    }

    Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        return mousePosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
