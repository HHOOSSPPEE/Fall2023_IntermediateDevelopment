using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class player : MonoBehaviour
{
    //public UnityEvent onPlayerStep;
    //public delegate void PlayerTakesStep();

    public static event Action onPlayerStep;
    public static event Action<int> onPlayerTakeDamage;

    //public static event Action onPlayerStep;

    private void Start()
    {
       
    }

    public void TakeStep()
    {
        onPlayerStep?.Invoke();
        onPlayerTakeDamage?.Invoke(2);
    }

}
