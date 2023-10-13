using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    private float _waittime = 0;
    public void Awake()
    {
        //DontDestroyOnLoad(gameObject);
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
        //everything here works right away 
        yield return new WaitForSeconds(waitTime);

        //everything down here, happens after the wait
        //generally you're putting stuff down here
        SceneManager.LoadScene(newScene);
    }
}
