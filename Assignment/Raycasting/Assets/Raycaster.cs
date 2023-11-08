using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    public LayerMask mask;

    Vector2 customV = new Vector2(2, 2);

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        #region Raycast2D


        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            customV,Mathf.Infinity,mask);

        Debug.DrawRay(transform.position, customV * hit.distance, Color.red);

        if(hit.collider != null)
        {
            Debug.Log("Hit");
        }

        #endregion

        #region Raycast(3D)
        RaycastHit hit;

        if (Physics.Raycast(
            transform.position,
            transform.TransformDirection(Vector3.left),
            out hit,
            Mathf.Infinity,
            mask))
        {
            Debug.Log("Hit3D");
        }


        #endregion

        #region CircleCast2D
        RaycastHit2D hit = Physics2D.CircleCast(
            transform.position)
    }


}
