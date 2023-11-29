using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    //public UnityEvent onPlayerStep;

    /*
    public delegate void PlayerTakesSteps();
    public static event PlayerTakesSteps onPlayerStep;
    */

    //This is the same function as upper one
    public static event Action onPlayerStep;

    private void Start()
    {
        
    }

    public void TakeStep()
    {
        onPlayerStep?.Invoke();
    }
}
