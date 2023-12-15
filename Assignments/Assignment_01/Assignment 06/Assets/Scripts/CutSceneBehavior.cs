using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutSceneBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    public VideoPlayer video;
    public GameObject screen;
    public bool videoDone = false;

    public bool killPlayer = false;
    //public GameObject statueEvil;
    //private FireBehavior fire;
    
    //VideoPlayer video;

    void Awake()
    {
        if (!GameManager.windowVideoDone)
        {

            GameManager.windowVideoDone = false;
            video = GetComponent<VideoPlayer>();
            videoDone = false;
            video.Play();
            video.SetDirectAudioVolume(0, VolumeBehavior.vol);
            video.loopPointReached += CheckOver;

        }


    }


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        if (killPlayer)
        {
            GameManager.kill = true;
        }
        else
        {
            videoDone = true;
            GameManager.windowVideoDone = true; //SceneManager.LoadScene(1);//the scene that you want to load after the video has ended.

            screen.SetActive(false);
        }

        Debug.Log("done");
       

       
        //statueEvil.SetActive(true);

    }


// Update is called once per frame
void Update()
    {
        
    }
}
