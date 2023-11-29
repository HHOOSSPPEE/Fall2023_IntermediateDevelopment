using System;
using UnityEngine;

public class Single : MonoBehaviour
{
    private float moveSpeed = -20f;
    private string[] types = new string[] { "water", "earth", "thunder", "flame" };
    public string myType;

    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprites[Array.IndexOf(types, myType)];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
