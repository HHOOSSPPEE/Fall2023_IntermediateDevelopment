using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource aud;
    public float subAmt = 0.0001f;
    private void Start()
    {
        aud = GetComponent<AudioSource>();
        GameManager.kill = false;

        GameManager.windowVideoDone = false;
        GameManager.currentStage = 1;

    }

    public void Update()
    {
        if (aud.pitch > 0)
        {

            aud.pitch -= subAmt;
        }
        else
        {
            aud.pitch = 0;
        }
    }

}
