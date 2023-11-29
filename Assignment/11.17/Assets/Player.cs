using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Player : MonoBehaviour
{
    public static event Action onPlayerStep;
    // Start is called before the first frame update
    public static event Action <int> onPlayerTakeDamage;
    private void Start()
    {
       
    }

    // Update is called once per frame
   public void TakeStep()
    {
        onPlayerStep?.Invoke();
        onPlayerTakeDamage?.Invoke(2);
    }
}
