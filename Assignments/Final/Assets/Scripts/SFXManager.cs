using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource itemSFX;
    [SerializeField] private AudioSource collisionSFX;
    [SerializeField] private AudioSource music;

    [Header("Audio Source")]
    public AudioClip item;
    public AudioClip wallHit;
    public AudioClip background;
}
