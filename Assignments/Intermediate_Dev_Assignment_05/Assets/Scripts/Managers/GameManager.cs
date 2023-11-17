using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager instance {  get; private set; }
    void Start()
    {
        instance = this;

    }

    // Update is called once per frame
    void Update()
    {

        DrawWithBrush.Pen_Colour = Color.blue;
    }
}
