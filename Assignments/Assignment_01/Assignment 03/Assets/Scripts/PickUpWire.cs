using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWire : MonoBehaviour
{
    private bool isDragging;
    private bool pickedUp;
    private Rigidbody2D rb2d;
    public float grav = 4f;

    public void OnMouseDown()
    {
        isDragging = true;
        Debug.Log("H");
        pickedUp = true;
        rb2d = GetComponent<Rigidbody2D>();
        //why won't it detect my mouse????? help???? lol
        //fixed it, it was bc it was an image LOL - made it a sprite instead 
    }
    public void OnMouseUp()
    {
        isDragging = false;
    }

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    

    void Update()
    {
        if (isDragging)
        {
            Vector2 mousePosition = Input.mousePosition - transform.position;
            transform.Translate(mousePosition);
        }

        if (pickedUp)
        {
            spriteRenderer.sprite = newSprite;
            if (!isDragging)
            {

                rb2d.gravityScale += grav;
            }
            
            
        }
    }
}
