using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

using System.Collections;


public class NotMineChangeFont : MonoBehaviour
{
    
    public TMP_FontAsset[] fontOptions; 

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(ChangeFontsAgain());
    }

    IEnumerator ChangeFontsAgain()
    {
        while (true)
        {
            TextMeshProUGUI[] allTMProComponents = FindObjectsOfType<TextMeshProUGUI>();

            foreach (TextMeshProUGUI textMeshProComponent in allTMProComponents)
            {
                int randomFontIndex = Random.Range(0, fontOptions.Length);
                textMeshProComponent.font = fontOptions[randomFontIndex];
            }

            yield return new WaitForSeconds(0.01f); 
        }
    }


}
