using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playNoise : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>;


    }
}
