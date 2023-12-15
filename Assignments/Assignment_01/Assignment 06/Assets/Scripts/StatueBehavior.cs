using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public bool playerSaw = false;
    public int speed = 10;
    public AudioSource source;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSaw)
        {
            
            if (!source.isPlaying)
            {
                source.Play(0);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("runaway");
            playerSaw = true;
            //gameObject.transform.POright;
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera" && playerSaw)
        {
            gameObject.SetActive(false);
            //Debug.Log("chan ge");
        }
    }

}
