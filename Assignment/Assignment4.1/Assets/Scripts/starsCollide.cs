using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starsCollide : MonoBehaviour

{

    public GameManager gameManager;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {

            gameManager.Addscore();


            Destroy(collision.gameObject);
            Debug.Log("Collide with star");
        }
        if (collision.gameObject.CompareTag("5"))
        {

            gameManager.Addsecondscore();

            Debug.Log("Collide with sun or earth.");
        }
    }



}
