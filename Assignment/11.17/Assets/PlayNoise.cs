using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNoise : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip clip;
    private AudioSource _source;   
    void Awake()
    {
        _source = GetComponent<AudioSource>();
        Player.onPlayerStep += PlaySound;

        Player.onPlayTakeDamage += TakeDamage;
    }

    // Update is called once per frame
    public void PlaySound()
    {
        _source.clip = clip;
        _source.Play();
    }
    private void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }
}
