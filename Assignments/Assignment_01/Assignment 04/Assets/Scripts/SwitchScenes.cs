using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneLabel;
    public bool sceneSwitch;

    void Start()
    {
        sceneSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void Switch()
    {
        sceneSwitch = !sceneSwitch;

        if (sceneSwitch)
        {
            SceneManager.LoadScene(sceneName: sceneLabel);
        }
    }
}
