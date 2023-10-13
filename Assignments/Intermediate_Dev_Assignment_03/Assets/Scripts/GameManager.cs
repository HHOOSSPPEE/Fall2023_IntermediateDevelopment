using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    IEnumerator SceneWait(float waitTime, string newScene)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(newScene);
    }

    public string newGameLevel;
    private string _levelToLoad;
    [SerializeField] private GameObject noSavedGameDialog = null;

    public void NewGameMenuYes()
    {
        SceneManager.LoadScene(newGameLevel);
    }

    public void LoadGameMenuYes()
    {
        if (PlayerPrefs.HasKey("Saved Level"))
        {
            _levelToLoad = PlayerPrefs.GetString("Saved Level");
            SceneManager.LoadScene(_levelToLoad);
        }
        else
        {
            noSavedGameDialog.SetActive(true);
        }
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    [Header("Volume Settings")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private GameObject confirmationPrompt = null;
    [SerializeField] private float defaultVolume = 0.75f;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.00");
    }
    public void VolumeReset()
    {
        AudioListener.volume = defaultVolume;
        volumeSlider.value = defaultVolume;
        volumeTextValue.text = defaultVolume.ToString("0.00");
        VolumeApply();
    }
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmBox()); 
    }
    public IEnumerator ConfirmBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }

    [Header("Gameplay Settings")]
    [SerializeField] private TMP_Text controllerSensitivityTextValue = null;
    [SerializeField] private Slider controllerSensitivitySlider = null;
    [SerializeField] private float defaultSensitivity = 1.0f;
    public float controlllerSensitivity = 1.0f;
    public void SetControllerSensitivity(float sensitivity)
    {
        controllerSensitivityTextValue.text = sensitivity.ToString("0.00");
    }
    public void ControlllerSensitivityReset()
    {
        controlllerSensitivity = defaultSensitivity;
        controllerSensitivitySlider.value = defaultSensitivity;
        controllerSensitivityTextValue.text = defaultSensitivity.ToString("0.00");
        VolumeApply();
    }
    public void ControllerSensitivityApply()
    {
        PlayerPrefs.SetFloat("controlllerSensitivity", controlllerSensitivity);
        StartCoroutine(ConfirmBox());
    }

}
