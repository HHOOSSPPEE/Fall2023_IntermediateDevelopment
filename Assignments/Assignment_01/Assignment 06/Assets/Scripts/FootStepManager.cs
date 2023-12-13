using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource aud;
    public AudioClip[] audioClips;
    public PlayerController cont;
    private int audNum = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cont._rigidBody.position != cont._previousPosition)
        {
            if (!aud.isPlaying)
            {

                aud.clip = audioClips[audNum];
                aud.Play(0);
            }
            
        }
        else
        {
            aud.Pause();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Carpet")
        {
            //Debug.Log("car");
            audNum = 1;
        }
        else if (collision.gameObject.tag == "Grass")
        {
            //Debug.Log("2");
            audNum = 2;
        }
        else
        {
            //Debug.Log("0");
            audNum = 0;
        }
    }
}
