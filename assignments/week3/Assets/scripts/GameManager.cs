using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public void Awake()
    //{
        //DontDestroyOnLoad(gameObject);

   // }
    public void SwitchScene(string newScene)
    {
        StartCoroutine(SceneWait(0.3f, newScene));
        
    }

    IEnumerator SceneWait(float waitTime, string newScene)
    {
        //everthing here right away
        yield return new WaitForSeconds(waitTime);

        //everything here after a wait
        SceneManager.LoadScene(newScene);

    }
}
