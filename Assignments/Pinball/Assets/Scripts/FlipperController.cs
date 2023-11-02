using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    public bool Flipper;
  
    void Update()
    {
        if ((Flipper && Input.GetKey(KeyCode.RightShift)) || ((!Flipper && Input.GetKey(KeyCode.LeftShift)))){
            GetComponent<HingeJoint2D>().useMotor = true;
         

        }
        else
        {
            GetComponent<HingeJoint2D>().useMotor = false;
        }
    }

    
}
