using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playnoise : MonoBehaviour
{
    private AudioSource source;
    private AudioClip clip;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        source = GetComponent<AudioSource>();
        Player.onPlayerStep += PlaySound;
    }

    public void PlaySound()
    {
        source.clip = clip;
        source.Play();
    }
}
