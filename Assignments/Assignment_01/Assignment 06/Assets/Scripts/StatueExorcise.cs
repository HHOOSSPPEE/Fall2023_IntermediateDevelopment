using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueExorcise : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playcont;
    public GameObject aniscary;
    public Sprite spr;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    private bool seenObj = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "MainCamera")
        {
            //Debug.Log("inframe");
            if (playcont.rosary && seenObj)
            {
                aniscary.SetActive(true);
                //gameObject.GetComponent<SwitchBehavior>().enabled = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = spr;
                //Debug.Log("works");
                //gameObject.GetComponent<AudioSource>().Play(0);
            }

            //else if (!playcont.rosary)
            //{
            //    gameObject.GetComponent<AudioSource>().Pause();
            //}
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "MainCamera" && !seenObj)
        {
            spriteRenderer.sprite = newSprite;
            seenObj = true;
        }
    }
}
