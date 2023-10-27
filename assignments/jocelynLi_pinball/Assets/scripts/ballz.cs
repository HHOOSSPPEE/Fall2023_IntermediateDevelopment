using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballz : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        switch(tag)
        {
            case "times5":
                GameManager.instance.UpdateScore(0,5);
                break;

            case "plus10":
                GameManager.instance.UpdateScore(10, 1);
                break;

            case "times100":
                GameManager.instance.UpdateScore(0, 100);
                break;

            case "minus10":
                GameManager.instance.UpdateScore(-10, 1);
                break;

            default:
                break;




        }
    }
}
