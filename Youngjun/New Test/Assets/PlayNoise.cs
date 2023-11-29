using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNoise : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource _source;
    void Awake()
    {
        _source = GetComponent<AudioSource>();
        Player.onPlayerStep += PlaySound;
    }

    public void PlaySound()
    {
        _source.clip = clip;
        _source.Play();
    }
}
