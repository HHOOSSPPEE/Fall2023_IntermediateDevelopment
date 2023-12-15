using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public int button = 1;
    public float[] location = { 61.5f, -113f, -158.57f };
    public float xloc;
    public SpriteRenderer visible;
    public GameObject canvas;
    public GameObject settingsCanvas;
    public GameObject aboutCanvas;
    

    //public UnityEngine.UI.Image img;
    //public float timeDelay = 0.2f;
    void Start()
    {
        InvokeRepeating("TurnOff", 2.75f, 4.0f);
        InvokeRepeating("TurnOn", 3.0f, 4.0f);
        SpriteRenderer visible = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            button += 1;
            if (button > 3)
            {
                button = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            button -= 1;
            if (button < 1)
            {
                button = 3;
            }
        }
        if (button == 1)
        {
            gameObject.transform.position = new Vector3(xloc, location[0],0);
        }
        if (button == 2)
        {
            gameObject.transform.position = new Vector3(xloc, location[1],0);
        }
        if (button == 3)
        {
            gameObject.transform.position = new Vector3(xloc, location[2],0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (button == 1)
            {
                
                SceneManager.LoadScene("Loading Scene");
            }
            if (button == 2)
            {
                
                gameObject.SetActive(false);
                canvas.SetActive(false);
                settingsCanvas.SetActive(true);

            }
            if (button == 3)
            {
                
                gameObject.SetActive(false);
                canvas.SetActive(false);
                aboutCanvas.SetActive(true);
            }
        }

    }

    void TurnOff()
    {
        visible.enabled = false;
    }
    void TurnOn()
    {
        visible.enabled = true;
    }

   
  
}
