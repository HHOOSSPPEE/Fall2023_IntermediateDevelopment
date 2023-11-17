using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{
    [Header("Assignments")]
    [SerializeField] private GameObject cam;

    [Header("Parallax")]
    [SerializeField] private float parallaxIntensity;

    [Header("Translation")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool parallaxIndependentMovementSpeed;

    private float spriteWidth;
    private float translationOffset = 0;
    private Vector2 initialPos;

    void Start()
    {
        initialPos = transform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        translationOffset +=
            movementSpeed * Time.deltaTime * 20f *
            (parallaxIndependentMovementSpeed ? 1 : (1 - parallaxIntensity));

        float relativeCamPositionX =
            (cam.transform.position.x * (1 - parallaxIntensity))
            - translationOffset;
        float parallaxOffsetX =
            (cam.transform.position.x * parallaxIntensity)
            + translationOffset;
        float parallaxOffsetY = cam.transform.position.y * parallaxIntensity;

        transform.position = new Vector3(
            initialPos.x + parallaxOffsetX,
            initialPos.y + parallaxOffsetY,
            transform.position.z
            );

        if (relativeCamPositionX > initialPos.x + spriteWidth)
            initialPos.x += spriteWidth;
        else if (relativeCamPositionX < initialPos.x - spriteWidth)
            initialPos.x -= spriteWidth;
    }
}
    