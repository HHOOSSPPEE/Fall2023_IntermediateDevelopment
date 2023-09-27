using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform_controller : MonoBehaviour
{



    private Vector2 _movement;
    private Animator _animator;
    private Renderer _render;
    public int t;
    public  Boolean isTransform;


    void Start()
    {
       
        _animator = GetComponent<Animator>();
        _render = GetComponent<Renderer>();
        _render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        t++;
        if (t > 300)
        {

            isTransform = false;
        }
        if (t > 600)
        {
            t = 0;
            isTransform = true;
        }

        if (isTransform)
        {
            _render.enabled = true;
        }
        else
        {
            _render.enabled = false;
        }

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            _animator.SetInteger("direction", 6);
        }

        if (Input.GetKey(KeyCode.A)) 
        {
            _animator.SetInteger("direction", 9);
        }
        if(Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger("direction", 3);
        }
        
       






    }
}
