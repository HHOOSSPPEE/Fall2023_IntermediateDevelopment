using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationTestBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    private Animator _animator;

    public int AnimationNum;
    
    public GameObject animationObject;
    public AnimationEnd aniEnd;
    public bool animationDone = false;
    PlayerController player;
    public GameObject screen;
    public GameObject playVideo;
    public VideoClip video;


    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //currently, you're trying to have each animation seperate, based on int, but maybe it would be easier to make each one by hand so you don't waste time here, okay?
        //i know its manual but it will work regardless!
        //works now :)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player" && !animationDone)
        {
            VideoPlayer vid = screen.GetComponent<VideoPlayer>();
            vid.clip = video;
            screen.SetActive(true);
            playVideo.SetActive(true);
            animationDone = true;
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && animationDone)
        {
            if (GameManager.windowVideoDone)
            {
                //change event
            }
        }
    }

    public void AnyPlayCutScene(VideoClip vid)
    {
        VideoPlayer vidp = screen.GetComponent<VideoPlayer>();
        vidp.clip = vid;
        screen.SetActive(true);
        playVideo.SetActive(true);
        //animationDone = true;
    }

}
