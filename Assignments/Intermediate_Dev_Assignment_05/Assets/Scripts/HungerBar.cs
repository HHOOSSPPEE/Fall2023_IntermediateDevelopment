using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private Slider _slider;
    private RandomVibrator _vibrator;
    private float maxValue = 1;
    private float value = 1;
    public Color maxColor;
    public Color minColor;
    private Image _fillImage;
    private Image _backgroundImage;
    void Start()
    {
        _slider = GetComponent<Slider>();
        _vibrator = GetComponent<RandomVibrator>();
        _fillImage = _slider.fillRect.GetComponent<Image>();
        _backgroundImage = transform.Find("Background").GetComponent<Image>();
    }

    void Update()
    {
        setValue(HungerSystem.instance.getHungerValue());
        setMaxValue(HungerSystem.instance.getMaxHungerValue());
        _slider.value = value;


        _vibrator.vibrationSpeed = 1 - value / maxValue;
        _vibrator.vibrationStrength = 1 - value / maxValue;
    }

    public void setMaxValue(float maxValue)
    {
        _slider.maxValue = maxValue;
        this.maxValue = maxValue;
    }
    public void setValue(float value)
    {
        _slider.value = value;
        this.value = value;
    }
}
