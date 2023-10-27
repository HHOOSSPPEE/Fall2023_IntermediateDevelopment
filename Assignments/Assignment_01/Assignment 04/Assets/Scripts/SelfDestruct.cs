using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
    public int destroyTime = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
    }

    //void DestroyObjectDelayed()
    //{
        
    //    Destroy(gameObject, destroyTime);
    //}
}
