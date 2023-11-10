using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private Slider _slider;
    private RandomVibrator _vibrator;
    [SerializeField] private float _maxHungerValue;
    [SerializeField] private float _hungerValue;
    private float _value;
    [SerializeField] private Color _maxColor;
    [SerializeField] private Color _minColor;
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
        #region set how the bar should looks like
        _value = _hungerValue / _maxHungerValue;
        _slider.value = _value;
        _fillImage.color = Color.Lerp(_maxColor, _minColor, _value);
        #endregion

        #region Vibration animation of the hunger bar
        _vibrator.vibrationSpeed = 1 - _value;
        _vibrator.vibrationStrength = 1 - _value;
        #endregion
    }

    private void setMaxHungerValue(float maxHungerValue)
    {
        _maxHungerValue = maxHungerValue;
        _slider.maxValue = maxHungerValue;
    }
}
