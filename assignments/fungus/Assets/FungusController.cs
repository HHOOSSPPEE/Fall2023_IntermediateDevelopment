using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusController : MonoBehaviour
{
    public Flowchart dialogueJosh;

    // Start is called before the first frame update
    void Start()
    {
        dialogueJosh.ExecuteBlock("New Block");
        GameDatabase.playerHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
