using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour

{
    private float waitTime = 2f;
    private int score = 0;
    public TMP_Text scoreText;
    public static GameManager instance;


    public void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SwitchScene(string newScene)
    {
        Debug.Log("switch scene called " + newScene);
        SceneManager.LoadScene(newScene);
        StartCoroutine(SceneWait(waitTime, newScene));
    }

    IEnumerator SceneWait(float waitTime, string newScene)
    {
      
        //everything here works right away
        yield return new WaitForSeconds(waitTime);

        //everything down here hap[ens after the wait
        SceneManager.LoadScene(newScene);
    }

    public void Addscore()
    {
        score += 10;
        scoreText.text = "SCORE: " + score;
        Debug.Log(score);
    }
}