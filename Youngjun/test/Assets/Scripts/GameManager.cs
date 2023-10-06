using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float _waittime = 0;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void FloatSetter(float time)
    {
        _waittime = time;
    }
    public void SwitchScene(string newScene)
    {
        StartCoroutine(SceneWait(_waittime, newScene));
    }

    IEnumerator SceneWait(float waitTime, string newScene)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(newScene);
    }
}
