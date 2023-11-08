using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask mask;
    Vector2 customV = new Vector2(2, 2);
    private void FixedUpdate()
    {

        #region Raycast 2D
        //raycast2d - send a ray in a direction

        /*RaycastHit2D hit = Physics2D.Raycast(transform.position,-transform.up,
            Mathf.Infinity,mask);

        Debug.DrawRay(transform.position, -transform.up*hit.distance,
            Color.red);
        

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.name);
        }*/
        #endregion

        #region Raycast (3D)
        /*RaycastHit hit;
        if (Physics.Raycast(transform.position,
            transform.TransformDirection(Vector3.left),
            out hit,
            Mathf.Infinity,
            mask))
        {
            Debug.Log(hit.collider.name);
        }
        else
        {
            Debug.Log("Hit");
        }*/
        #endregion

        #region CircleCast2D
        RaycastHit2D hit = Physics2D.CircleCast(
            transform.position,
            1f,
            -transform.up,
            Mathf.Infinity,
            mask);

        #endregion

    }
}
