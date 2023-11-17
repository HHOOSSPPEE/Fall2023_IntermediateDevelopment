using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    Vector3 tempVec3 = new Vector3();

    void LateUpdate()
    {
        
     tempVec3.x = Mathf.Clamp(targetTransform.position.x, 0, 56);
        
        
        tempVec3.y = this.transform.position.y;
        tempVec3.z = this.transform.position.z;
        this.transform.position = tempVec3;
    }
}