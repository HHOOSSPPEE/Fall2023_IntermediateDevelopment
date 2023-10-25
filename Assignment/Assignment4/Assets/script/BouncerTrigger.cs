using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator bouncer;

   void Start()
    {
        // ��ȡ�����ϵ�Animator���
        bouncer = GetComponent<Animator>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
           
            bouncer.SetTrigger("BouncerTrigger");
        }
    }
}
