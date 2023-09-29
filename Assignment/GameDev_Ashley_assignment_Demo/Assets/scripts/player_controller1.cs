using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller1 : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float rotateSpeed = 100.0f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f).normalized * movementSpeed * Time.deltaTime;

        transform.Translate(movement, Space.World);

        float rotationH = -moveHorizontal * rotateSpeed * Time.deltaTime;
        float rotationV = -moveVertical * rotateSpeed * Time.deltaTime;

        transform.Rotate(Vector3.forward, rotationH);
        transform.Rotate(Vector3.forward, rotationV);
    }
}