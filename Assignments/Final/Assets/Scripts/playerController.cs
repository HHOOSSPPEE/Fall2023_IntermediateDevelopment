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
    private Vector2 direction = Vector2.right;

    private Rigidbody2D rb;
    private RaycastHit2D hitInfo;
    public BoxCollider2D gridArea;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //hitInfo = GetComponent<RaycastHit2D>();
    }

    // Update is called once per frame
    void Update()
    {
        #region MOVEMENT

        if (Input.GetKeyDown(KeyCode.W)){
            direction = Vector2.up;
        }else if (Input.GetKeyDown(KeyCode.S)){
            direction = Vector2.down;
        }else if (Input.GetKeyDown(KeyCode.D)){
            direction = Vector2.right;
        }else if (Input.GetKeyDown(KeyCode.A)){
            direction = Vector2.left;
        }

        #endregion

        Bounds bounds = this.gridArea.bounds;

        //hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        //if (hitInfo.collider != null)
        //{
        //    Debug.DrawRay(transform.position, hitInfo.point, Color.white);


        //    if (hitInfo.collider.CompareTag("Wall"))
        //    {


        //    }


        //}
    }

    private void FixedUpdate()
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }
}
