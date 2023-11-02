using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISlideController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI soundText = null;
    [SerializeField] private TextMeshProUGUI musicText = null;
    [SerializeField] private float soundmaxSliderAmount = 100f;
    [SerializeField] private float musicmaxSliderAmount = 100f;

    public void soundsliderChange (float value)
    {
        float localValue = value * soundmaxSliderAmount;
        soundText.text = localValue.ToString("0");
    }

    public void MusicsliderChange(float value)
    {
        float localValue = value * musicmaxSliderAmount;
        musicText.text = localValue.ToString("0");
    }
}
