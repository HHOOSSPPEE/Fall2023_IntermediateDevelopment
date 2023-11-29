using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
//using static UnityEditor.Progress;

public class CubeGardening : MonoBehaviour
{
    // Start is called before the first frame update
    public bool emptyDirt = true;
    public string helpText;
    GameManager gameManager;
    //ClickManager click;
    public GameObject[] flowers;
    //public GameObject tulip;
    //public GameObject lilly;
    //public GameObject iris;
    //public GameObject wisteria;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlantNew(int itemID, GameObject seed)
    {

        int flowerNumber = itemID-25;
        Debug.Log("h");
        if (emptyDirt == false)
        {
            Instantiate(flowers[flowerNumber], transform.position, transform.rotation);
            gameObject.SetActive(false);
            seed.SetActive(false);
            
            return;
        }
        return;
    }
}
