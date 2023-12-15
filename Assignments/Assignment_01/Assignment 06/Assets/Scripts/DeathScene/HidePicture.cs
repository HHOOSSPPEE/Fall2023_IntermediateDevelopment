using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePicture : MonoBehaviour
{
    // Start is called before the first frame update
    private int timer = 0;
    public int timerdur = 30;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (gameObject.activeSelf)
        {
            timer++;
            if (timer > timerdur)
            {
                timer = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
