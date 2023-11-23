using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playNoise : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource _source;
    

    // Start is called before the first frame update

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
        player.onPlayerStep += PlaySound;
        player.onPlayerTakeDamage += TakeDamage;
    }

    public void PlaySound()
    {
        _source.clip = clip;
        _source.Play();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }
}
