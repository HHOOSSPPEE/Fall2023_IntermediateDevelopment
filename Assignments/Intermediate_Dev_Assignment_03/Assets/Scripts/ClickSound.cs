using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickSound : MonoBehaviour
{
    // Start is called before the first frame update
    public Button yourButton;  // Drag and drop your button in the Inspector.
    public AudioSource audioSource;  // Drag and drop your button's Audio Source component.
    public AudioClip soundClip;

    private void Start()
    {
        yourButton.onClick.AddListener(PlayButtonClickSound);
    }

    void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(soundClip);
    }
}
