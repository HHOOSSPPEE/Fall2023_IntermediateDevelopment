using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayer : MonoBehaviour
{
    
    public GameManager gameManager;
    // Start is called before the first frame update
    public Transform spaceship;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.Emptyscore();
            spaceship.position = new Vector3(7.07f, -3.61f, 0);
            
            //GameManager.instance.SwitchScene("Start");
        }
    }
}
