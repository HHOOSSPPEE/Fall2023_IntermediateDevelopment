using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonAnimation : MonoBehaviour
{
    public Camera Camera;
    public float alpha = 1;

    private void Start()
    {
        Camera = GetComponent<Camera>(); 
    }

    private void Update()
    {
        
    }
}
