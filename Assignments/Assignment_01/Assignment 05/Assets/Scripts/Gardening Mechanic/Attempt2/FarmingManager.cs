using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FarmingManager : MonoBehaviour
{
    public PlantID selectPlant;
    public bool isPlanting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SelectPlant(PlantID newPlant)
    {
        if (selectPlant == newPlant)
        {
            Debug.Log("selected" + selectPlant.plantIDNumber);
            selectPlant = null;
            isPlanting = false;

        }
        else
        {
            Debug.Log("deselected");
            selectPlant = newPlant;
            isPlanting = true;
        }
    }
}
