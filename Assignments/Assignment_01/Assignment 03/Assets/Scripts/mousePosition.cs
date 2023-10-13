using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class mousePosition : MonoBehaviour
{
    private float _waittime = 0.08f;
    IEnumerator mCoroutine;
    public TMP_Text mousePos;
    void Start()
    {
        mousePos = GetComponent<TextMeshProUGUI>();
        mCoroutine = numberGenerate(_waittime);
        StartCoroutine(mCoroutine);
    }


    IEnumerator numberGenerate(float seconds)
    {
        
        //yield return new WaitForSeconds(_waittime);
        while (true)
        {
            yield return new WaitForSeconds(seconds);
            float randomNumber = Random.Range(50000, 1000000);
            float randomNumber2 = Random.Range(50000, 1000000);
            float randomNumber3 = Random.Range(100, 10000);
            float randomNumber31 = Random.Range(100, 10000);
            float randomNumber4 = Random.Range(50000, 1000000);
            float randomNumber41 = Random.Range(50000, 1000000);
            mousePos.text = Input.mousePosition.x + "." + randomNumber + randomNumber + "\n" + Input.mousePosition.y + "." + randomNumber2 + randomNumber2 + "\n" + randomNumber3 + "." + randomNumber4 + randomNumber4 + "\n" + 42 + "." + randomNumber41 + randomNumber41;
        }

    }
  
}