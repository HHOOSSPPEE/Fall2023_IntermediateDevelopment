using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    private float _waittime = 0;
    // Update is called once per frame
    public void Playgame()
    {
        SceneManager.LoadScene("GameScreen");
    }

    

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
        //Everything here works right away
        yield return new WaitForSeconds(waitTime);

        //Everything here works after a certain time
        SceneManager.LoadScene(newScene);
    }
}
