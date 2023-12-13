using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float remainingTime;
    public AudioSource whistleAudio;
    private bool hasPlayedWhistle = false;

    public DialogueManager DM;

    private void Start()
    {
        DM = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if (DM != null && DM.CanFish)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            else
            {
                remainingTime = 0;

                if (!hasPlayedWhistle)
                {
                    whistleAudio.Play();
                    hasPlayedWhistle = true;
                }

                StateController.currentState = FishingState.Exit;
                DM.CanFish = false;
            }

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
