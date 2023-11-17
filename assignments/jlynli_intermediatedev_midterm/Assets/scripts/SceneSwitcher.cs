using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneSwitch : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("game");

    }

    public void Title()
    {
        SceneManager.LoadScene("start");
    }

    public void Win()
    {
        SceneManager.LoadScene("win");
    }
}
