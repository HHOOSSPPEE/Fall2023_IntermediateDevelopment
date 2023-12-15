using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public static float vol = 1.0f;
    public UnityEngine.UI.Slider slider;
    public AudioSource auds;

    public static float brightness = 1.0f;
    public UnityEngine.UI.Slider bslider;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        vol = slider.value;
        AudioListener.volume = slider.value;
        brightness = bslider.value;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            auds.Play(0);
        }

        }


}
