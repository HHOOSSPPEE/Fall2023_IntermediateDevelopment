using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.transform.position.x < -35 || gameObject.transform.position.x > 35 ||
        // gameObject.transform.position.y < 19 || gameObject.transform.position.y > -19)
        //{
        //    Destroy(gameObject);
            
        //}

        if (gameObject.transform.position.y < -300)
        {
            Destroy(gameObject);
        }

      

    }
}
