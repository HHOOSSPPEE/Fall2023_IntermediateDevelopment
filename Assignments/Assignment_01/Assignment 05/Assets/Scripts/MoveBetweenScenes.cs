using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveBetweenScenes : MonoBehaviour
{
    
    public float delay = 3;
    public string newScene;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void switchScene()
    {
        timer += Time.deltaTime;

        if (timer > delay)
        {
            SceneManager.LoadScene(newScene);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(newScene);
        }
    }
}
