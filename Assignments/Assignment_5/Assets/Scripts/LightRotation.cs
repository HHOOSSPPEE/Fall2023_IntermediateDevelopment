using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{

    [Header("Rotation variables")]
    public float rotationSpeed;
    public Vector3 viewA;
    public Vector3 viewB;
    public float angle1 ;
    public float angle2 ;
            
    public float distance;
   

    void Start()
    {
        viewA = transform.eulerAngles + new Vector3(0f, 0f,angle1 );
        viewB = transform.eulerAngles + new Vector3(0f, 0f,angle2 );
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * rotationSpeed, 1);
        transform.eulerAngles = Vector3.Lerp(viewA, viewB, time);
    }
}
