using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    public GameObject dicePrefab;
    Vector2 newDicePos = new Vector2(8f, -4f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newDice()
    {
        Instantiate(dicePrefab, newDicePos, Quaternion.identity);
    }
}
