using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactTrigger : MonoBehaviour
{
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.Play();
    }

}