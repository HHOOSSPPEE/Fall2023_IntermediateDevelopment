using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class WanderBehavior : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 direction;
    private Vector2 newPos = new Vector2(2f,2f);
    private Vector2 positionMouse;
    public float moveSpeed;
    private bool mouseClick = false;


    // Update is called once per frame
    void Update()
    {
        //Camera.transform.position = new Vector2(0, 0);
        if (mouseClick)
        {
           
            transform.position = Vector2.MoveTowards(transform.position, positionMouse, moveSpeed  * 1.5f * Time.deltaTime);

            if (Vector2.Distance(transform.position, positionMouse) < 0.1f)
            {
                mouseClick = false;

            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, newPos, moveSpeed * Time.deltaTime);
            transform.LookAt(newPos);

            if (Vector2.Distance(transform.position, newPos) < 0.1f)
            {
                newPos = new Vector2(UnityEngine.Random.Range(-8f, 8f), UnityEngine.Random.Range(-5f, 5f));

            }
        }


        GameObject[] lillies = GameObject.FindGameObjectsWithTag("Lily");
        foreach (GameObject l in lillies)
            if (l.GetComponent<LillyPads>().lilyUp == false && Input.GetMouseButtonUp(0))
            {
                positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseClick = true;
            }
       

        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
    }

  
   
}
