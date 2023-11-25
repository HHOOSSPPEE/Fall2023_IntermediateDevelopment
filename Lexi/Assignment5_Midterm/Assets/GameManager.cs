using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int money = 0;
    public float price = 0;
    public bool isPainting = false;
    private float moneyPerSec = 1f;
    public List<Color> chosenColorList = new List<Color>();
    private float timer = 0f;

    public TextMeshProUGUI coin;

    Draw drawScript;

    // Update is called once per frame
    void Update()
    {
        coin.text = money + "";

        if (isPainting)
        {
            timer += Time.deltaTime;
            if (timer > 1f)
            {
                price += moneyPerSec;
                timer = 0f;
            }
            
        }
        else price = 0;

        drawScript = FindObjectOfType<Draw>();
        if (!chosenColorList.Contains(drawScript.Pen_Colour))
        {
            price += 8;
            chosenColorList.Add(drawScript.Pen_Colour);
        }


    }
}
