using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectExorcised : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioData;
    void Start()
    {

        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            audioData.volume = 0.25f;
            audioData.maxDistance = 12;
        }
    }
}
