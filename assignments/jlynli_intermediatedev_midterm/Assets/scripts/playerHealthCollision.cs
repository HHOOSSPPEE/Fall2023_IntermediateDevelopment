using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealthCollision : MonoBehaviour
{
    //starting hp
    public int startHp;
    //current hp
    public int hp;
    public float bulletCooldown;
    float bulletTimer;

    public PlayerMovement playerMove;

    public Healthbar healthBar;
    
   
    void Start()
    {
        hp = startHp;

        healthBar.SetMaxHealth(startHp); 
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
                //current health minus 1
                hp -= 1;

                healthBar.SetHealth(hp);

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
