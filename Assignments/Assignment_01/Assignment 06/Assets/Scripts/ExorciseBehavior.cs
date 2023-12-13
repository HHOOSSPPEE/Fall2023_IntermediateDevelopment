using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.Video;

public class ExorciseBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController playerCont;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "MainCamera")
        {
            if (playerCont.rosary)
            {
                Debug.Log("destroyed");
                Destroy(gameObject);
            }
        }


    }
}
