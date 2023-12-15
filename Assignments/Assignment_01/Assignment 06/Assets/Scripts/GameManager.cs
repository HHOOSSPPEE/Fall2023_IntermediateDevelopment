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

    
    public static int currentStage = 1;
    [Header("Stages of Apocalypse")]
    public GameObject stageOne;
    public GameObject stageTwo;
    public GameObject stageThree;
    public GameObject stageFour;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(windowVideoDone);
        //Debug.Log(VolumeBehavior.vol);
        //AudioListener.volume = VolumeBehavior.vol;
       

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

        if (kill)
        {
            AudioListener.volume = VolumeBehavior.vol;
            SceneManager.LoadScene("Death Scene");
        }


        switch (currentStage)
        {
            case 4:
                stageFour.SetActive(true);
                Debug.Log("case 4");
                break;
            case 3:
                //if (stageTwo.activeSelf)
                //{
                //    currentStage = 4;
                //}
                stageThree.SetActive(true);
                Debug.Log("case 3");
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
