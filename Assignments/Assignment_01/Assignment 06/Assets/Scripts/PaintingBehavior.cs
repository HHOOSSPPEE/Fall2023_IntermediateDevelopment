using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingBehavior : MonoBehaviour
{

    public GameObject painting;
    public Sprite picture;
    public Animator _animator;
    public int bigNum = 0;
    public SpriteRenderer _sprite;
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
            _sprite = painting.GetComponent<SpriteRenderer>();
            if (painting.activeSelf)
            {
                if (bigNum == 1)
                {
                    _animator.SetInteger("Object", 1);
                    _sprite.enabled = true;
                }
                else if (bigNum == 2)
                {

                    _animator.SetInteger("Object", 2);
                    _sprite.enabled = true;
                }
                else if (bigNum == 3)
                {
                    _animator.SetInteger("Object", 3);
                    _sprite.enabled = true;
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
            _sprite.enabled = false;

        }

        if (collision.gameObject.tag == "MainCamera")
        {
            Debug.Log("change");
        }
    }
}
