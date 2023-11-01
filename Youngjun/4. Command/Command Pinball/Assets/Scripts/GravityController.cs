using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    SpringJoint2D m_Joint2D;
    // Start is called before the first frame update
    void Start()
    {
        m_Joint2D = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Joint2D.distance > 0.005f)
        {
            m_Joint2D.distance -= 0.005f;
        }
        else m_Joint2D.enabled = false;
            
    }
}
