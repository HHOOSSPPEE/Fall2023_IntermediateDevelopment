using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool kill = false;
    public static bool windowVideoDone = false;
    public GameObject screen;

    public AudioSource source;
    //public static int[] stageApoc = { 0, 1, 2, 3, 4, 5, 6 };
    //public VideoPlayer vid;
    //public static AudioListener aud;

    [Header("Stages of Apocalypse")]
    public static int currentStage = 1;

    public GameObject stageOne;
    public GameObject stageTwo;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(windowVideoDone);
        //Debug.Log(VolumeBehavior.vol);
        //AudioListener.volume = VolumeBehavior.vol;
        if (kill)
        {
            SceneManager.LoadScene("Death Scene");
        }

        if (screen.activeSelf)
        {
            Debug.Log("volume down");
            AudioListener.volume = 0f;
        }
        if (!screen.activeSelf)
        {
            Debug.Log("H");
            AudioListener.volume = VolumeBehavior.vol;
        }


        switch (currentStage)
        {
            case 7:

                break;
            case 6:
                
                break;
            case 5:
                break;
            case 4:
                break;
            case 3:
                break;
            case 2:
                //if (stageTwo.activeSelf)
                //{
                //    currentStage = 3;
                //}
                Debug.Log("case 2");
                //source.Play(0);
                stageTwo.SetActive(true);
                //print("Grog SMASH!");
                break;
            case 1:
                Debug.Log("case1");
                if (stageOne.activeSelf)
                {
                    currentStage = 2;
                }
                //source.Play(0);
                //print("Ulg, glib, Pblblblblb");
                break;

        }
    }
}
