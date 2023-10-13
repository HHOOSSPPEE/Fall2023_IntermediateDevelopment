using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWire : MonoBehaviour
{
    private bool isDragging;
    private bool pickedUp;
    private Rigidbody2D rb2d;
    public float grav = 4f;
    public int fall = -15;

    private Vector3 screenPoint;
    private Vector3 offset;

    public void OnMouseDown()
    {
        isDragging = true;
        Debug.Log("H");
        pickedUp = true;
        rb2d = GetComponent<Rigidbody2D>();
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));


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
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

        if (pickedUp)
        {
            spriteRenderer.sprite = newSprite;
            if (!isDragging)
            {
                //Physics.IgnoreCollision(GetComponent<Collider>(), GetComponent<Collider>());
                //rb2d.gravityScale += grav;
                transform.position += new Vector3(0, fall, 0);
            }
            
            
        }
    }
}
