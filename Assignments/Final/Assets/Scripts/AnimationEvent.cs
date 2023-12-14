using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public ParticleSystem stompDust;
   
    public void TriggerEvent()
    {
        stompDust.Play();
    }
}
