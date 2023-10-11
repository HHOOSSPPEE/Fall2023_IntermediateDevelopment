using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISlideController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sliderText = null;
    [SerializeField] private float maxSliderAmount = 100f;

    public void sliderChange (float value)
    {
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
    }
}
