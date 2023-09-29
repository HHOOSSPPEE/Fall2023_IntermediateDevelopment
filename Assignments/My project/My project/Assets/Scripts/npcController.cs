using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcController : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    public GameObject ways;
    public Transform[] waypoints;
    int pointIndex;
    int pointCount;
    int direction = 1;

    private void Awake()
    {
        waypoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            waypoints[1] = ways.transform.GetChild(i).transform;
        }

    }
    // Start is called before the first frame update
    private void Start()
    {
        pointCount = waypoints.Length;
        pointIndex = 1;
        targetPos = waypoints[pointIndex].transform.position; 
    }

    // Update is called once per frame
    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step); 

        if (transform.position == targetPos )
        {
            NextPoint();
        }

    }

    void NextPoint()
    {
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }

        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = waypoints[pointIndex].transform.position;
    }
}

