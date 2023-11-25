using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sell : MonoBehaviour
{
    public void Clicked()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.money += Mathf.FloorToInt(gameManager.price);
        gameManager.isPainting = false;
        gameManager.chosenColorList.Clear();
    }
}
