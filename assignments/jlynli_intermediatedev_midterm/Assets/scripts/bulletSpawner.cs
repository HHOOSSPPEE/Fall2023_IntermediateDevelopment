using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletResource;
    public float minRotation;
    public float maxRotation;
    public int numberOfBullets;
    public bool isRandom;

    public float cooldown;
    float timer;
    public float bulletSpeed;
    public Vector2 bulletVelocity;

    public GameObject player;

    public enemyAI enemy;




    //https://www.youtube.com/watch?v=UZWEkpWgs-4&ab_channel=SkyanSam-SkyriftStudios
    //code from here

    float[] rotations;
    void Start()
    {
        timer = cooldown;
        rotations = new float[20];
        if (!isRandom)
        {
            DistributedRotations();
        }



    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && numberOfBullets > 0)
        {
            //calling to spawn bullets
            SpawnBullets();
            timer = cooldown;
        }

    }

    // Select a random rotation from min to max for each bullet
    public float[] RandomRotations()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            rotations[i] = Random.Range(minRotation, maxRotation);
        }
        return rotations;

    }

    //set random rotations evenly distributed between min and max 
    public float[] DistributedRotations()
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            //too much math
            var fraction = (float)i / ((float)numberOfBullets - 1); //subtract because bullets count from 0
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + minRotation; //minRotation to undos difference
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }



    //spawn bullets called in void update
    public GameObject[] SpawnBullets()
    {
        Debug.Log("spawning bullets right now");
        

        if (isRandom)
        {
            //random rotation for each bullet each time
            RandomRotations();
        }

        //spawn bullets
        //for statement spawns bullets based on number of bullets
        GameObject[] spawnedBullets = new GameObject[numberOfBullets];
        for (int i = 0; i < numberOfBullets; i++)
        {
            //instantiate bullet in array
            spawnedBullets[i] = Instantiate(bulletResource, transform.position, Quaternion.identity);

            //based on spawned bullet
            var b = spawnedBullets[i].GetComponent<bullet>();

            //spawned with individual rotation
            b.rotation = rotations[i];
            b.speed = bulletSpeed;
            b.velocity = bulletVelocity;
        }
        return spawnedBullets;
    }
}