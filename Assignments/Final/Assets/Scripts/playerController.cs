using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float moveX;
    public float moveY;
    public float distance;

    private Rigidbody2D rb;
    private RaycastHit2D hitInfo;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitInfo = GetComponent<RaycastHit2D>();
    }

    // Update is called once per frame
    void Update()
    {
        hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.DrawRay(transform.position, hitInfo.point, Color.white);
           

            if (hitInfo.collider.CompareTag("Wall"))
            {
               

            }


        }
    }
}
