using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private Slider slider;
    private RandomVibrator vibrator;
    private HungerSystem hungerSystem;
    [SerializeField] private Image fillImage;
    [SerializeField] private Image backgroundImage;

    public Color maxFillColor = Color.green;
    public Color minFillColor = Color.red;
    public Color backgroundColor = Color.black;
    public float maxVibrationSpeed;
    public float maxVibrationStrength;
    private void Awake()
    {
        slider = GetComponent<Slider>();

        if (GetComponent<RandomVibrator>() == null )
            gameObject.AddComponent<RandomVibrator>();

    }

    private void Start()
    {
        hungerSystem = HungerSystem.Instance;

        slider.value = hungerSystem.GetHungerValue();
        slider.maxValue = hungerSystem.GetMaxHungerValue();
        slider.minValue = hungerSystem.GetMinHungerValue();

        vibrator = GetComponent<RandomVibrator>();
        vibrator.SetMaxSpeed(maxVibrationSpeed);
        vibrator.SetMaxStrength(maxVibrationStrength);
    }

    private void Update()
    {
        //temp value
        float hungerValue = hungerSystem.GetHungerValue();
        float maxHungerValue = hungerSystem.GetMaxHungerValue();
        float minHungerValue = hungerSystem.GetMinHungerValue();

        //slider appearance
        slider.value = hungerValue;
        slider.maxValue = maxHungerValue;
        slider.minValue = minHungerValue;

        fillImage.color = Color.Lerp(minFillColor, maxFillColor, hungerValue / maxHungerValue);
        backgroundImage.color = backgroundColor;

        //vibration
        vibrator.SetSpeedPercentage(hungerValue / maxHungerValue);
        vibrator.SetStrengthPercentage(hungerValue / maxHungerValue);
        vibrator.SetMaxSpeed(maxVibrationSpeed);
        vibrator.SetMaxStrength(maxVibrationStrength);
    }

}
