using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator _animator;
    public int aniNumber;
    //private AnimationTestBehavior test;
    PlayerController player;
    void Start()
    {

        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aniNumber == 1)
        {
            //Debug.Log("switch animation1");
            
            _animator.SetInteger("Animation", 1);
           
        }
        if (aniNumber == 2)
        {
            //Debug.Log("switch animation2");
            _animator.SetInteger("Animation", 2);
            
        }


        
    }
   
    public void CloseAnimation()
    {
        //Debug.Log("closing it?");
        //player.moveAllowed = true;
        gameObject.SetActive(false);
    }
}
