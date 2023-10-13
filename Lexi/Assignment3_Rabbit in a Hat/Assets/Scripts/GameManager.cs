using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    //Quit Menu
    public void Quit()
    {
        Application.Quit();
    }

    //Option Menu
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
