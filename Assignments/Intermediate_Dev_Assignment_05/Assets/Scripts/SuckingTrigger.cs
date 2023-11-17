using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckingTrigger : MonoBehaviour
{
    public bool detected = false;
    public BoxCollider2D _boxCollider;
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
