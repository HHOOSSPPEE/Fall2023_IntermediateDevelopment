using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]
public class SoundSlider : MonoBehaviour
{

    Slider slide
    {
        get { return GetComponent<Slider>(); }
    }

    public AudioMixer mixer;

    [SerializeField]
    private string volumeName;

    private void Start()
    {
          UpdateValueOnChange(slide.value);

        slide.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slide.value);
        }
        );
    }


    public void UpdateValueOnChange(float value)
    {
        if(mixer != null)
        mixer.SetFloat(volumeName, value);

        Debug.Log(value);
    }


}
