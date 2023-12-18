using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class ChaseBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10.0f;
    private Vector2 target;
    private Vector2 position;
    public Transform player;
    private bool chase = false;
    public PlayerController controller;
    //public bool kill = false;
    private bool runAway = false;
    private bool audioPlay = false;
    AudioSource audioData;
    private bool playerSaw = false;



    void Start()
    {
        audioData = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //if (chase)
        //{
        if (!runAway)
        {
            float step = speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
            //}
        }
        else
        {
            float step = - speed * Time.deltaTime;

            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        }


        if (controller.rosary && Vector2.Distance(transform.position, controller.gameObject.transform.position) <= 5)
        {
            runAway = true;
        }

        //if (audioPlay && !audioData.isPlaying)
        //{
        //    audioData.Play(0);
        //    audioPlay = false;
        //}
        //if (!audioPlay && !audioData.isPlaying)
        //{
        //    GameManager.kill = true;
        //}
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            
            //GameManager.kill = true;
            //if (!audioData.isPlaying)
            //{
            //    audioData.Play(0);
               
            //}

            //chase = true;
        }

        if (collision.gameObject.tag == "MainCamera")
        {
            //Debug.Log("runaway");
            playerSaw = true;
            //gameObject.transform.Pright;
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

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "MainCamera")
    //    {
    //        gameObject.SetActive(false);
    //        //Debug.Log("chan ge");
    //    }
    //}
}
