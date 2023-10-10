using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundMaker : MonoBehaviour
{
    public AudioSource source;
   // public AudioClip clip;

    public void makeNoise(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
}
