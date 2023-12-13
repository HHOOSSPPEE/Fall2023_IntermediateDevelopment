using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    //public Sprite newSprite;
    public bool pureWater = true;
    void Start()
    {

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (pureWater)
        {
            gameObject.GetComponent<PaintingBehavior>().bigNum = 1;
            animator.SetBool("pure", true);
        }
        if (!pureWater)
        {
            gameObject.GetComponent<PaintingBehavior>().bigNum = 3;
            animator.SetBool("pure", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "MainCamera" )
        {
            //Debug.Log("run?");
            if (transform.childCount == 0)
            {
                Debug.Log("true");
                pureWater = true;
            }
            if (transform.childCount > 0)
            {
                pureWater = false;
            }


        }
    }
}
