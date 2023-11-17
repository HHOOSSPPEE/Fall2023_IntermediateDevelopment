using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;


public class PlantID : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] plantStages;
    public int plantIDNumber;
    public bool plantChosen = false;
    //public PlotManager plt;

    //public Camera myCam;
    //public Collider2D plotCol;

    //public PlotManager plotManager;
    public bool isPlanted = false;
    public SpriteRenderer plant;

    float timeBtwnStages = 2f;
    int plantStage = 0;

    float timer;
    public GameObject wateringCanGrow;
    public PlantID plantID;
    public GameObject plantType;


    WateringCan wateringCan;
    GameManager gm;
    FarmingManager fm;

    void Start()
    {
        fm = FindObjectOfType<FarmingManager>();
        wateringCan = FindObjectOfType<WateringCan>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < plantStages.Length - 1)
            {
                timer = timeBtwnStages;
                Debug.Log("restarting plant ");

                plantStage += 1;
                Debug.Log(plantStage);
                isPlanted = false;
                UpdatePlant();

            }
        }


    }

    public void OnMouseUp()
    {
        Debug.Log("plantchosen");
        plantChosen = true;
        //fm.SelectPlant(this);
        if (gm.wateringFull && gm.selectedItemId == 20)
        {
            Debug.Log("just about to start plant");
            plant.sprite = plantStages[plantStage];
            if (plantStage < plantStages.Length - 1)
            {
                plantStage += 1;
                gm.wateringFull = false;
                Debug.Log("changing plant");
                return;
            }
            //Plant();
            
        }
    }

    public void Plant()
    {
        //selectedPlant = newPlant;
        //isPlanted = true;
        Debug.Log("just starting plant");

        //plantStage = 0;
        isPlanted = true;
        UpdatePlant();
        timer = timeBtwnStages;
        //plant.gameObject.SetActive(true);
    }

    void UpdatePlant()
    {
        plantStage += 1;
        plant.sprite = plantStages[plantStage];
        
        plant.GetComponent<BoxCollider2D>().size = plant.GetComponent<SpriteRenderer>().sprite.bounds.size;
        Debug.Log("updating plant");
        return;
        
    }
}
