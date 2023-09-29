using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using UnityEngine;

public class spawner : MonoBehaviour
{

    public GameObject ItemPrefab_1;
    public GameObject ItemPrefab_2;
    public GameObject ItemPrefab_3;
    public GameObject ItemPrefab_4;
    public float Radius = 1;
    public int Timer = 0;

    public Transform target; // The GameObject to follow
    public float speed = 2.0f;
    public float spawnRadius = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float step = speed * Time.deltaTime;
            transform.position += direction.normalized * step;
        }


        if (Timer >= 600)
        {
            //SpawnObjectAtRandom();


            SpawnObject(ItemPrefab_1);
            SpawnObject(ItemPrefab_2);
            SpawnObject(ItemPrefab_3);
            SpawnObject(ItemPrefab_4);

            Timer = 0;
        }
        else Timer++;

    }

    void SpawnObject(GameObject name)
    {
        if (target != null)
        {
            // Generate random offsets for X and Y within the spawnRadius
            float randomX = Random.Range(-spawnRadius, spawnRadius);
            float randomY = Random.Range(-spawnRadius, spawnRadius);

            // Create a random position relative to the player's position
            Vector3 randomOffset = new Vector3(randomX, randomY, 0);
            Vector3 randomPosition = target.position + randomOffset;

            // Instantiate the itemPrefab at the randomPosition
            Instantiate(name, randomPosition, Quaternion.identity);


        }
    }

    //void SpawnObjectAtRandom()
    //{
        
    //    Vector3 randomPos = target.position + randomOffset;

    //    Instantiate(ItemPrefab, randomPos, Quaternion.identity);

    //    Destroy(gameObject, 10f);
    //}
}
