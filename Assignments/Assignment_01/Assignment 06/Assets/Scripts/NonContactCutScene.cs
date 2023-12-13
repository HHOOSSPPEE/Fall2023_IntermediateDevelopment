using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Video;

public class NonContactCutScene : MonoBehaviour
{
    // Start is called before the first frame update
    //private Animator _animator;

    //public int AnimationNum;

    //public GameObject animationObject;
    //public AnimationEnd aniEnd;
    private bool animationDone = false;
    //PlayerController player;
    public GameObject screen;
    public GameObject playVideo;
    public VideoClip video;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void PlayCutScene(VideoClip vid)
    {
        VideoPlayer vidp = screen.GetComponent<VideoPlayer>();
        vidp.clip = vid;
        screen.SetActive(true);
        playVideo.SetActive(true);
        animationDone = true;
    }


}
