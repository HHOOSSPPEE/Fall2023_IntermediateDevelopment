using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public float followSpeed = 5f;
    public Vector2 borderSize = new Vector2(5f, 3f);

    void Update()
    {

        // Get the player's position
        Vector3 playerPosition = playerTransform.position;

        // Calculate the camera's target position with borders
        float targetX = Mathf.Clamp(playerPosition.x, borderSize.x, borderSize.x + borderSize.x);
        float targetY = Mathf.Clamp(playerPosition.y, borderSize.y, borderSize.y + borderSize.y);
        Vector3 targetPosition = new Vector3(targetX, targetY, transform.position.z);

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
