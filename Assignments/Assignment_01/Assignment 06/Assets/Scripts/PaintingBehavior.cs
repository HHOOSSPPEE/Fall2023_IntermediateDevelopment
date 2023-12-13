using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingBehavior : MonoBehaviour
{

    public GameObject painting;
    public Sprite picture;
    public Animator _animator;
    public int bigNum = 0;
    //public Animator animation;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //PaintingView.changeAni = bigNum;
            painting.SetActive(true);
            _animator = painting.GetComponent<Animator>();
            if (painting.activeSelf)
            {
                if (bigNum == 1)
                {
                    _animator.SetInteger("Object", 1);
                }
                if (bigNum == 2)
                {

                    _animator.SetInteger("Object", 2);
                }
                if (bigNum == 3)
                {
                    _animator.SetInteger("Object", 3);
                }
            }
            

        }
            //painting.GetComponent<Animation>(). = animation;
            
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            painting.SetActive(false);
            
        }

        if (collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("change");
        }
    }
}
