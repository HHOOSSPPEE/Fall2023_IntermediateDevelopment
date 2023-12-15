using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource SFX;
    [SerializeField] private AudioSource music;

    [Header("Audio Source")]
    public AudioClip item;
    public AudioClip wallHit;
    public AudioClip background;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        music.clip = background;
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
