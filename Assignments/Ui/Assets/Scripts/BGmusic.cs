using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    public static BGmusic instance;
    AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            
        }
        else {
           Destroy(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }
}
