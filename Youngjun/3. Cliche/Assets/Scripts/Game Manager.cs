using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;
//using UnityEngine.UI;
using UnityEngine.Audio;
//using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public Animator animator;
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        resolutions = Screen.resolutions;
        AddResolutions();
    }

    public void SetUiAnimation(GameObject target)
    {
        animator = target.GetComponent<Animator>();
        int currentValue = animator.GetInteger("state");
        animator.SetInteger("state", currentValue + 1);

        if (animator.GetInteger("state") == 2)
        {
            animator.SetInteger("state", 0);
        }
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

    public void AddResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        options.Add("640 x 360");
        options.Add("854 x 480");
        options.Add("960 x 540");
        options.Add("1280 x 720");
        options.Add("1600 x 900");
        options.Add("1920 x 1080");
        options.Add("2560 x 1440");
        options.Add("3840 x 2160");

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void ActiveMenu(GameObject target)
    {
        StartCoroutine(ActivateMenuWait(target, 0.65f));
    }

    IEnumerator ActivateMenuWait(GameObject target, float time)
    {
        yield return new WaitForSeconds(time);
        target.SetActive(true);
    }
}
