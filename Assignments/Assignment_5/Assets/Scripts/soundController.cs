using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playnoise : MonoBehaviour
{
    private AudioSource source;
    void Update()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}

