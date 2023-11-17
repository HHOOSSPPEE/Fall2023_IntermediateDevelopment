using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnDash : MonoBehaviour
{
    public AudioSource sword;
    public PlayerMovement player;

    // Update is called once per frame
    void Update()
    {
        if(player.isDashing)
        {
            sword.Play();
        }
    }
}
