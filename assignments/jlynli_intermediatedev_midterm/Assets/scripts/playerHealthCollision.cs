using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealthCollision : MonoBehaviour
{
    //starting hp
    public int startHp;
    //current hp
    int hp;
    public float bulletCooldown;
    float bulletTimer;

    public PlayerMovement playerMove;
    
   
    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bullet" || collision.tag == "enemy")
        {
            if(bulletTimer <= 0 && !playerMove.isDashing)
            {
                hp -= 1;
                bulletTimer = bulletCooldown;
                Debug.Log("yowza" + hp);
            }
        }

        if(hp <= 0)
        {
            SceneManager.LoadScene("lose");
        }
    }



   

}
