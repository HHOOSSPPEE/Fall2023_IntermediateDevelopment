using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Invokes when the hunger value is no longer cirtical </summary>
public class HungerSystem : MonoBehaviour
{
    private static HungerSystem instance;
    public static HungerSystem Instance => instance;
    private HungerBar hungerBar;
    [SerializeField] private float hungerValue;
    [SerializeField] private float maxHungerValue;
    [SerializeField] private float minHungerValue;

    private bool isHungerValueCritical = false;

    /// <summary> Eveents related to HungerSystem </summary>
    public delegate void HungerSystemEvent();

    /// <summary> Invokes when the hunger value is critical </summary>
    public event HungerSystemEvent OnHungerValueCritical;
    /// <summary> Invokes when the hunger value is no longer cirtical </summary>
    public event HungerSystemEvent OnHungerValueSafe;
    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        hungerBar = GameObject.Find("Hunger Bar").GetComponent<HungerBar>();
    }

    public void SetHungerValue(float hungerValue)
    {
        this.hungerValue = Mathf.Clamp(hungerValue, maxHungerValue, minHungerValue);

        if (!isHungerValueCritical && Mathf.Approximately(hungerValue, minHungerValue))
        {
            OnHungerValueCritical?.Invoke();
            isHungerValueCritical = true;
        }
        if (isHungerValueCritical && !Mathf.Approximately(hungerValue, minHungerValue))
        {
            OnHungerValueSafe?.Invoke();
            isHungerValueCritical = false;
        }
    }
    public float GetHungerValue() => hungerValue;
    public void SetMaxHungerValue(float maxHungerValue) => this.maxHungerValue = maxHungerValue;
    public float GetMaxHungerValue() => maxHungerValue;
    public float SetMinHungerValue(float minHungerValue) => this.minHungerValue = minHungerValue;
    public float GetMinHungerValue() => minHungerValue;
}
