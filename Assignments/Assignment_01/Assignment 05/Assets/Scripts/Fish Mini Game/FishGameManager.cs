using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishGameManager : MonoBehaviour
{

    private int mouseCounter = 0;
    public float delay = 3;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && FindObjectOfType<LillyPads>().lilyUp == false)
        {
            mouseCounter++;
        }

        if (mouseCounter >= 7)
        {
            ReturnStudio();
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
