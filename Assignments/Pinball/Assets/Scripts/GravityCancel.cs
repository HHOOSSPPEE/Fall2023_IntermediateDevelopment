using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GravityCancel : MonoBehaviour
{

    private void light()
    {
        Physics2D.gravity = new Vector2(0, -1.2f);
    }

    private void heavy()
    {
        Physics2D.gravity = new Vector2(0,-9.8F);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flipper")
        {
           light();
                                                
        }else
        {
            heavy();
        }
      
    }

}
