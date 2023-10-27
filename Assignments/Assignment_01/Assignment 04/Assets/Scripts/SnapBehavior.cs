using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    bool snapped = false;
    public GameObject snapparent; // the gameobject this transform will be snapped to
    Vector3 offset; // the offset of this object's position from the parent
    private DragObject drag;
    private void Start()
    {
        drag = GetComponent<DragObject>();
    }

    void Update()
    {

        if (snapped == true)
        {
            //retain this objects position in relation to the parent
            transform.position = snapparent.transform.position + offset;
            Vector3 currentPos = transform.position;
            

            
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Tubes")
        {
            snapped = true;
            Debug.Log("testing");
            snapparent = col.gameObject;
            offset = transform.position - snapparent.transform.position; //store relation to parent
            drag.enabled = false;
            this.transform.parent.position = col.transform.position + (this.transform.parent.position - this.transform.position);
        }
        
    }

 

}
