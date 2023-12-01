using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [Header("Raycasting variables")]
    public RaycastHit2D hitInfo;
    public Gradient redColor;
    public float distance;
    public LineRenderer lineOfSight;

    [SerializeField] public float respawnX = 36.04f;
    [SerializeField] public float respawnY = 0.57f;
    [SerializeField] public float respawnZ = 0f;

    void Update()
    {

        hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                player.instance.transform.position = new Vector3(respawnX, respawnY, respawnZ);

            }


        }
        else if (hitInfo.collider.CompareTag("Cover"))
        {
          
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
           
        }

        lineOfSight.SetPosition(0, transform.position);
    }

}


