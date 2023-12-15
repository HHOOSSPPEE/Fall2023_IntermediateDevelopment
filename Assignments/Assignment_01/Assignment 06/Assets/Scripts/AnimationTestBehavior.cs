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

    public CutSceneBehavior cut;
    public bool killChar = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.windowVideoDone && animationDone)
        {
            if (killChar)
            {
                //cut.killPlayer = true;
            }
            //change event
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player" && !animationDone)
        {
            if (killChar)
            {
                cut.killPlayer = true;
            }
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
                if (killChar)
                {
                    //GameManager.kill = true;
                }
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
