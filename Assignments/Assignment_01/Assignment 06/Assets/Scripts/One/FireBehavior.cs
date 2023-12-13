using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FireBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    private int timer = 0;
    public int timerDuration = 120;
    public AnimationTestBehavior cutScene;
    public VideoClip video;
    public CutSceneBehavior cutbehave;
    public bool touchFire = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (GameManager.windowVideoDone)
        {
            GameManager.kill = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log(timer);
            timer++;
            
            if (timer > timerDuration)
            {
                //Debug.Log("activate");
                //Debug.Log("inside");
                touchFire = true;
                cutScene.AnyPlayCutScene(video);

            }


        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        if (collision.gameObject.tag == "Player")
        {
            timer = 0;
        }
    }
}
