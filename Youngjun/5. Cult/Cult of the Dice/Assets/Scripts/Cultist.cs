using System.Collections;
using UnityEngine;

public class Cultist : MonoBehaviour
{
    private float moveSpeed = 0.5f;
    private string[] type = new string[] { "water", "earth", "thunder", "flame" };
    private string[] counterType = new string[] { "thunder", "flame", "water", "water" };
    SpriteRenderer spriteRenderer;

    public Sprite[] sprites;

    private int hp;
    private int[] hps = new int[] { 10, 11, 50 };
    private string[] tags = new string[] { "CultistNormal", "CultistFlag", "CultistPaladin" };

    private float jumpForce = 0f;
    private float jumpHeight = 0.3f;
    private bool isJumping = false;

    Vector3 initialPosition;

    public GameObject hitEffect; 

    public enum Type
    { 
        Water,
        Earth,
        Thunder,
        Flame
    }

    public Type myType;


    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        for (int i = 0; i < tags.Length; i++)
        {
            if (CompareTag(tags[i]))
            {
                hp = hps[i];
                break;
            }
        }
        

        spriteRenderer.sprite = sprites[(int)myType];

        switch (myType)
        {
            case Type.Earth:

                break;

            case Type.Thunder:

                break;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < initialPosition.y)
        {
            isJumping = true;
        }
        else if (transform.position.y > initialPosition.y + jumpHeight)
        {
            isJumping = false;
        }

        if (isJumping)
        {
            jumpForce = GetComponent<Rigidbody2D>().gravityScale * 2;
        }
        else
        {
            jumpForce = 0f;
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, jumpForce);
        if (hp <= 0) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Single hitBySingle = collision.gameObject.GetComponent<Single>();
        
        if (hitBySingle != null)
        {
            if (hitBySingle.myType == counterType[(int)myType])
            {
                hp -= hitBySingle.damage * 2;
            }
            else hp -= hitBySingle.damage;

            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Multiple"))
        {
            StartCoroutine(MultipleRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Multiple"))
        {
            StopCoroutine(MultipleRoutine());
        }
    }

    IEnumerator MultipleRoutine()
    {
        while (hp > 0)
        {
            yield return new WaitForSeconds(1f); 

            hp--;

            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
}
