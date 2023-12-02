using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        Vector3 playerDirection = new Vector3 (player.GetPlayerDirection().x, player.GetPlayerDirection().y, 0);
        transform.position = player.transform.position + playerDirection;
    }
}
