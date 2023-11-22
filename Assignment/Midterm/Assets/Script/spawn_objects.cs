using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawn_objects : MonoBehaviour
{
    public GameObject[] spritesToSpawn; // Array of different sprites to spawn
    public Transform spawnPosition; // The position where sprites will be spawned
    public float spawnInterval = 2f; // Time interval between spawns

    public Slider progressBar;

    private float timer;
    private GameObject currentSprite;
    private bool isDogWantingSprite;

    private float progress = 0f; 



    void Start()
    {
        timer = spawnInterval;
        SpawnRandomSprite();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            DestroyCurrentSprite();
            SpawnRandomSprite();
            timer = spawnInterval;
        }
    }

    void SpawnRandomSprite()
    {
        // Randomly select a sprite
        GameObject randomSpritePrefab = spritesToSpawn[Random.Range(0, spritesToSpawn.Length)];

        currentSprite = Instantiate(randomSpritePrefab, spawnPosition.position, Quaternion.identity);

        // newSprite.transform.parent = someParentTransform;

        isDogWantingSprite = true;

        Draggable draggableComponent = currentSprite.GetComponent<Draggable>();
        if (draggableComponent != null)
        {
            draggableComponent.desiredObject = currentSprite;
        }
    }

    void DestroyCurrentSprite()
    {
        if (currentSprite != null)
        {
            Destroy(currentSprite);
            isDogWantingSprite = false;
        }
    }

    public void OnObjectDropped(Draggable draggedObject, GameObject desiredObject)
    {
        // Check if the dropped object matches what the dog wants
        if (isDogWantingSprite && draggedObject != null && desiredObject != null && draggedObject.desiredObject == desiredObject)
        {
            Debug.Log("Dog is happy!");
            IncreaseProgress(1.0f);

        }
        else
        {
            Debug.Log("Wrong object! Try again.");
        }
    }

    private void IncreaseProgress(float amount)
    {
        progress += amount;

        // Ensure the progress value stays within the valid range (0 to 100)
        progress = Mathf.Clamp(progress, 0f, 100f);

        // Update the UI Slider's value
        if (progressBar != null)
        {
            progressBar.value = progress;
        }
    }
}