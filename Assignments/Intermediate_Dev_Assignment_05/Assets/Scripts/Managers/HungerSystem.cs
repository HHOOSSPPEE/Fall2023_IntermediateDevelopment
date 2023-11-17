using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerSystem : MonoBehaviour
{
    public static HungerSystem instance;
    [SerializeField] private HungerBar _hungerBar;
    [SerializeField] private float hungerValueConsumptionPerSecond;
    [SerializeField] private float maxHungerValue;
    [SerializeField] private float hungerValue;
    public float hungerValueConsumptionPerSpell {  get; private set; } 
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        setHungerValue(hungerValue - hungerValueConsumptionPerSecond * Time.deltaTime); // Continuous consumption of hunger
        _hungerBar.setValue(hungerValue);
    }
    public void setHungerValue(float hungerValue)
    {
        this.hungerValue = hungerValue;
        _hungerBar.setValue(hungerValue / maxHungerValue);
    }
    public float getHungerValue() => hungerValue;
    public float getMaxHungerValue() => maxHungerValue;
}
