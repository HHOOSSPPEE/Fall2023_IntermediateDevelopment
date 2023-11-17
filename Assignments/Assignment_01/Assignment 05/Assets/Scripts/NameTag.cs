using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameTag : MonoBehaviour
{
    Vector2 resolution, resolutionInWorldUnits = new Vector2(17.8f,10);
    
    private Vector3 screenPoint;
    private Vector3 offset;
    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
    }

    void LateUpdate()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 20);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

}

