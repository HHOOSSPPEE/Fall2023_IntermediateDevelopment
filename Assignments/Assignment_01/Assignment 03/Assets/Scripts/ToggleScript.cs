using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleScript : MonoBehaviour
{
    public GameObject toggler;
    public SpriteRenderer spriteRenderer;
    //public SpriteRenderer spriteRenderer1;

    public Sprite newSprite;
    public Sprite newSprite1;
    public bool tog;
    // Start is called before the first frame update
    void Start()
    {
        print(toggler.GetComponent<Toggle>().isOn);
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spriteRenderer.sprite = newSprite;
            Debug.Log("osf");
        }
    }

    public void userToggle(bool tog)
    {
        print(tog);
        if (tog == true)
        {
            Debug.Log("off");
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            spriteRenderer.sprite = newSprite1;
        }
    }
    void OnMouseDown()
    {
        spriteRenderer.sprite = newSprite;
        Debug.Log("osf");
    }


}
