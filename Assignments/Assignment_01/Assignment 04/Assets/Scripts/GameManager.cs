using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Net;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int pointsNumber;

    public float pointsDisplay = 3000;

     float pointTimer = 0;
    float pointLimit = 10;
    public GameOver GameOver;

    //[SerializeField]
    //private Text _title;
    [SerializeField] TextMeshProUGUI _title;
    [SerializeField] TextMeshProUGUI scnd;

    public int storevalue;
    public ScoreManager scr;
    int maxPoints = 0;
    
    // Start is called before the first frame update
    public GameObject myGameObject;
    void Start()
    {

        storevalue = GameObject.Find("point").GetComponent<PointObject>().addPoint;

    }

    // Update is called once per frame
    void Update()
    {
        //ownScore = scr.score;
        //pointsDisplay += storevalue * 100;
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        pointsNumber = points.Length - 1;
        //_title.text = (pointsNumber.ToString());
        _title.GetComponent<TMPro.TextMeshProUGUI>().text = pointsDisplay.ToString();
        //for (int i = 0; i < pointsNumber; i++)

        //{
        //if (myGameObject.activeInHierarchy && Input.GetMouseButtonDown(0))
        //}
        pointTimer++;
        if (pointTimer >= pointLimit)
        {
            pointsDisplay--;
            pointsDisplay += storevalue * 10;
            pointTimer = 0;

        }

        if (pointsDisplay < 0)
        {
            //switch scene
            //gameObject.GetComponent<SwitchScenes>().Switch();
            //GameOverS();
            GameOver.Setup(scr.score);

        }

        scnd.GetComponent<TMPro.TextMeshProUGUI>().text = storevalue.ToString();

    }



   
}
