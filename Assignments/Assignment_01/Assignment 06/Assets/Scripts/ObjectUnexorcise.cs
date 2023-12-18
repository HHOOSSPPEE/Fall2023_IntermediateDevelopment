using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUnexorcise : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playcont;
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
            if (playcont.rosary && !gameObject.GetComponent<AudioSource>().isPlaying)
            {
                //Debug.Log("works");
                gameObject.GetComponent<AudioSource>().Play(0);
            }
           
            //else if (!playcont.rosary)
            //{
            //    gameObject.GetComponent<AudioSource>().Pause();
            //}
        }

    }
}
