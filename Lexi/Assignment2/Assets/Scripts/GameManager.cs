using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void SwitchScene(string newScene)
    {
        StartCoroutine(SceneWait(2f, newScene));
    }

    IEnumerator SceneWait(float waitTime, string newScene)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(newScene);
    }
}