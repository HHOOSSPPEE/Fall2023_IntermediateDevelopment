using System;
using UnityEngine;

public class Multiple : MonoBehaviour
{
    private string[] types = new string[] { "water", "earth", "thunder", "flame" };
    public string myType;

    SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = sprites[Array.IndexOf(types, myType)];
    }
}