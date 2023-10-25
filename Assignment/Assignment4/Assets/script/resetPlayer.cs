using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spaceship;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        //spaceship.position = new Vector3(6.6f, -7.7f, 0);
        GameManager.instance.SwitchScene("Start");
    }
}
