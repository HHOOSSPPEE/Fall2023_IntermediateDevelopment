using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public static Timer instance;
    public Slider slider1;
    public Slider slider2;
    public float gameTime = 12f;
    private float time;

    private bool stopTimer;

    public Image background_1;
    public Image fill_1;

    public Image background_2;
    public Image fill_2;

   
    public void Start()
    {
        instance = this;

        stopTimer = false;
        slider1.maxValue = gameTime;
        slider1.value = gameTime;

        slider2.maxValue = gameTime;
        slider2.value = gameTime;

        background_1.enabled = true;
        fill_1.enabled = true;

        background_2.enabled = true;
        fill_2.enabled = true;

    }

    public void ResetTime()
    {
        gameTime = 12f;
        stopTimer = false;
        slider1.maxValue = gameTime;
        slider1.value = gameTime;
        slider2.maxValue = gameTime;
        slider2.value = gameTime;
    }
    public void Update()
    {
        time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time - minutes * 60);


        if (stopTimer == false)
        {
            slider1.value = time;
            slider2.value = time;
        }

        if (time <= 0)
        {
            stopTimer = true;
            background_1.enabled = false;
            fill_1.enabled = false;

            background_2.enabled = false;
            fill_2.enabled = false;

        }

    }

}
