    using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SliderController : MonoBehaviour
{
    public  SliderController Instance;
    // public static SliderController instance;
    public float timerDuration = 5f;
    public Slider timerSlider;
    public float timer;
    public bool shouldUpdate;
    public bool canUse;
    // private UnityEvent

    public Image background;
    public Image fill;


    public player player;
    public GameObject Particles;

    public void Start()
    {
        timer = timerDuration;
        timerSlider = GameObject.Find("Slider").GetComponent<Slider>();
        Particles.SetActive(false);
        background.enabled = false;
        fill.enabled = false;

    }


    public void Update()
    {
        if (Input.GetButton("Fire1") && canUse)
        {
            shouldUpdate = false;
            background.enabled = true;
            fill.enabled = true;
            timer -= Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(timer / timerDuration);
            timerSlider.value = normalizedTime;
            player.instance.invisible = true;
            Particles.SetActive(true);


            if (timer <= 0)
            {
                player.instance.invisible = false;

            }
       

        }
        else
        {
            if (shouldUpdate)
            {
                //If the clider is resetting you can not use the ability
                canUse = false;
                Particles.SetActive(false);
                timer += Time.deltaTime;
                float normalizedTime = Mathf.Clamp01(timer / timerDuration);
                timerSlider.value = normalizedTime;

                player.instance.invisible = false;

                if (timer >= timerDuration)
                {
                    // When the slider resets you can use the button
                    canUse = true;
                    timer = timerDuration;
                    shouldUpdate = false;
                    background.enabled = false;
                    fill.enabled = false;

                }
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            shouldUpdate = true;

        }
    }

}
