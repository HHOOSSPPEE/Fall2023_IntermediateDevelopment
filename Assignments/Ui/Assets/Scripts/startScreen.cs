using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScreen : MonoBehaviour
{
   
 
    void Update()
    {
     
        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Return))) 
        {
          
                SceneManager.LoadScene("GameMenu");
   
        }
      
    }
}
