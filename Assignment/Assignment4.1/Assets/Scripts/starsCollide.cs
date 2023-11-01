using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class starsCollide : MonoBehaviour

{
    public AudioSource soundEffect;
    public GameManager gameManager;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            soundEffect.Play();
            gameManager.Addscore();


            Destroy(collision.gameObject);
            Debug.Log("Collide with star");
        }
        if (collision.gameObject.CompareTag("5"))
        {
            soundEffect.Play();
            gameManager.Addsecondscore();

            Debug.Log("Collide with sun or earth.");
        }

      
    }
    



}
