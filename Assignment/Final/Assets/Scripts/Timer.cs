using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEditor.VersionControl;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainingTime;


    public DialogueManager DM;
    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>();
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (DM != null && DM.CanFish)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else if (remainingTime < 0)
            {
                remainingTime = 0;

                
                
                StateController.currentState = FishingState.Exit;
                DM.CanFish = false;


            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        }
    }
}
