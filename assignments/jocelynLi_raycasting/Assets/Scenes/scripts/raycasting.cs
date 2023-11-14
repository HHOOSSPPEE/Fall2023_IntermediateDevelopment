using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycasting : MonoBehaviour
{
    //can edit mask in unity
    public LayerMask mask;

    private void FixedUpdate()
    {
        #region Raycast 2d
        ////raycast2d - send a ray in a direction




        //RaycastHit2D hit = Physics2D.Raycast(
        //    transform.position,
        //    -transform.up,
        //    Mathf.Infinity, //set length of raycast
        //    mask); //goes until hits mask/layer set in unity

        ////draw raycast in scene
        //Debug.DrawRay(
        //    transform.position,
        //    -transform.up * hit.distance,
        //    Color.red);

        ////if anything hits, then what
        //if (hit.collider != null)
        //{
        //    Debug.Log(hit.collider.name);
        //}

        #endregion

        #region Raycast(3D)

        //RaycastHit hit;

        //if (Physics.Raycast(
        //    transform.position,
        //    transform.TransformDirection(Vector3.left),
        //    out hit,
        //    Mathf.Infinity,
        //    mask))
        //{
        //    Debug.Log(hit.collider.name);
        //}
        //else
        //{
        //    Debug.Log("no");
        //}





        #endregion

        #region CircleCast2D
        RaycastHit2D hit = Physics2D.CircleCast(
            transform.position,
            1f,
            -transform.up,
            Mathf.Infinity, //set length of raycast
            mask); //goes until hits mask/layer set in unity

        //if anything hits, then what
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }



        #endregion
    }
}
