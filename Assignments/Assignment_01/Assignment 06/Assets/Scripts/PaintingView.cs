using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingView : MonoBehaviour
{
    AudioSource audioData;
    private Animator animator;
    public static int changeAni = 1;
    
    void Start()
    {

        audioData = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!audioData.isPlaying)
        {
            audioData.Play(0);
        }
        //}
        //else
        //{
        //    audioData.Pause();
        //}

        //if (painting.bigNum == 1)
        //{

        //    animator.SetInteger("Object", 2);
        //}
        //if (changeAni == 2)
        //{

        //    animator.SetInteger("Object", 1);
        //}
        //if (changeAni == 3)
        //{

        //    animator.SetInteger("Object", 3);
        //}
    }
}
