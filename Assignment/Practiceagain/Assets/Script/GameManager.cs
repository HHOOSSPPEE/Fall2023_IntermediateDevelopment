using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    private float _waititme = 0;
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
        SceneManager.LoadScene(newScene);
        StartCoroutine(SceneWait(2f, newScene));
    }

    IEnumerator SceneWait(float waitTime,string newScene)
    {
        //everything here works right away
        yield return new WaitForSeconds(waitTime);

        //everything down here hap[ens after the wait
        SceneManager.LoadScene(newScene);
    }
}
