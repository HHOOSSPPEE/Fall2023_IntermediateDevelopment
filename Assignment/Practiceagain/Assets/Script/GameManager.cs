using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour

{
    private float waitTime = 2f;
    public Animator transition;
    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /*public void FloatSetter(float time)
    {
        _waittime = time;
    }*/
    public void SwitchScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
        StartCoroutine(SceneWait(waitTime, newScene));
    }

    IEnumerator SceneWait(float waitTime,string newScene)
    {
        transition.SetTrigger("Start");
        //everything here works right away
        yield return new WaitForSeconds(waitTime);

        //everything down here hap[ens after the wait
        SceneManager.LoadScene(newScene);
    }
}
