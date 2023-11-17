using System.Collections;
using System.Collections.Generic;
using Fungus;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{

    //private GameObject[] containers;
   
    public float delay = 3;
    float timer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        PaperContainer[] containers = FindObjectsOfType(typeof(PaperContainer)) as PaperContainer[];
        foreach (PaperContainer container in containers)
        {
            bool allComplete = true;
            if (container.doneCollecting != true)
            {
                allComplete = false;
                break;
            }
            if (allComplete)
            {
                ReturnStudio();
               
                //LoadScene
            }
        }
        
    }

    void ReturnStudio()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            SceneManager.LoadScene("StudioScene02");
            
        }
        
    }
}
