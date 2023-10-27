using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    private void OnCollisionEnter2D(Collision2D Collision)
    {
        Debug.Log("yowza");
    }
}
