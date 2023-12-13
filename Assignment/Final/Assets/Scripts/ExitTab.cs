using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExitTab : MonoBehaviour
{
    public GameObject exittab;
    public bool exittabOpened = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (exittab.activeSelf)
            {
                exittab.SetActive(false);
                
            }
            else
            {
                exittab.SetActive(true);
                exittabOpened = true;
                
            }
        }

    }
}
