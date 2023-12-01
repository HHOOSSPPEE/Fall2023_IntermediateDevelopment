using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    // public UnityEvent onPlayerStep;

    public delegate void PlayerTakesStep();
    public static event PlayerTakesStep onPlayerStep;
    void Start()
    {
       // onPlayerStep?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        
    }

    public void PlaySound()
    {
        onPlayerStep?.Invoke();
    }
}


