using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodLineBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //public LineRenderer lineRenderer;
    public LineRenderer trail;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float width = trail.startWidth;
        trail.material.mainTextureScale = new Vector2(1f / width, 1.0f);
    }
}
