using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTile : MonoBehaviour
{
    // press a to title press d to restart
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("game");
        }
        if (Input.GetKey(KeyCode.E))
        {
            SceneManager.LoadScene("start");
        }
    }
}
