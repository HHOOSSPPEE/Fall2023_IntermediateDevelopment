using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuantPic : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    //public SpriteRenderer spriteRenderer1;

    public Sprite newSprite;
    public Sprite newSprite1;
    public bool nonquant;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        
    }

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (nonquant == true)
        {

            spriteRenderer.sprite = newSprite;
        }
        else
        {
            spriteRenderer.sprite = newSprite1;
        }
    }
}
