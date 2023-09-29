using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Source")]
    [SerializeField] AudioSource musicSource;
   

    [Header("Audio Clip")]
    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}



