using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RealitySlider : MonoBehaviour
{
    public Slider mainSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!Input.GetMouseButtonDown(0))
        //{

            if (mainSlider.value == 1 && Input.GetMouseButtonUp(0) && EventSystem.current.IsPointerOverGameObject())
            {
                SceneManager.LoadScene(sceneName: "SampleScene");
            }
            if (mainSlider.value == 2 && Input.GetMouseButtonUp(0) && EventSystem.current.IsPointerOverGameObject())
            {
                SceneManager.LoadScene(sceneName: "Wires_01");
            }
            if (mainSlider.value == 3 && Input.GetMouseButtonUp(0) && EventSystem.current.IsPointerOverGameObject())
            {
                SceneManager.LoadScene(sceneName: "Computers_02");
            }
            if (mainSlider.value == 4 && Input.GetMouseButtonUp(0)&& EventSystem.current.IsPointerOverGameObject())
            {
                SceneManager.LoadScene(sceneName: "UI");
            }
        //}
    }
}
