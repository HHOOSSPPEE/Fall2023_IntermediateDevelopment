//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlotManager : MonoBehaviour
//{
//    // Start is called before the first frame update

//    public bool isPlanted = false;
//    public SpriteRenderer plant;

    
//    int plantStage = 0;
    
//    float timer;
//    public GameObject wateringCanGrow;
//    public PlantID plantID;
//    public GameObject plantType;

    

//    PlantObject selectedPlant;
//    WateringCan wateringCan;

//    GameManager gm;

//    //public FarmingManager fm;

//    void Start()
//    {

//        //gm = FindObjectOfType<GameManager>();
//        //fm = FindObjectOfType<FarmingManager>();
//        //wateringCan = FindObjectOfType<WateringCan>();
//        //fm = transform.parent.GetComponent<FarmingManager>();
//        Plant();
//    }


//    // Update is called once per frame
//    void Update()
//    {
//        if (isPlanted)
//        {
//            timer -= Time.deltaTime;

//            if (timer<0 && plantStage< selectedPlant.plantStages.Length - 1)
//            {
//                timer = selectedPlant.timeBtwnStages;
//                Debug.Log("updatingPlantStage");
               
//                plantStage++;
//                Debug.Log(plantStage);
//                UpdatePlant();

//            }
//        }
//    }

//    //void OnMouseDown()
//    //{
//    //    Debug.Log("canIcLICK");
//    //        //if (fm.isPlanting)
//    //        //{
//    //            Plant();
//    //        //}

//    //}

//    public void Plant()
//    {
//        //selectedPlant = newPlant;
//        //isPlanted = true;


//        //plantStage = 0;
//        isPlanted = true;
//        UpdatePlant();
//        timer = selectedPlant.timeBtwnStages;
//        //plant.gameObject.SetActive(true);
//    }

//    void UpdatePlant()
//    { 
//        plant.sprite = selectedPlant.plantStages[plantStage];
//        Debug.Log("plantspritechanged");
//        wateringCan.growUp = false;
//    }
//}
