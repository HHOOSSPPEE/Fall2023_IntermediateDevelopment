using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private Vector3 dir = Vector3.left;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * 50 * Time.deltaTime);

        if (transform.position.x <= -414)
        {
            dir = Vector3.right;
        }
        else if (transform.position.x >= 430)
        {
            dir = Vector3.left;
        }
    }
}
