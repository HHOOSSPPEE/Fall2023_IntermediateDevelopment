using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    public GameObject target;

    PlayerController playerController;
    NightmareController nightmareController;

    Vector3 targetDirection;

    private void Start()
    {
        playerController = target.GetComponent<PlayerController>();
        nightmareController = target.GetComponent<NightmareController>();
    }

    void Update()
    {
        if (playerController != null)
        {
            Vector3 playerDirection = new Vector3(playerController.GetPlayerDirection().x, playerController.GetPlayerDirection().y, 0);

            if (playerDirection != Vector3.zero)
            {
                targetDirection = playerDirection * 3;
            }
        }

        if (nightmareController != null)
        {
            targetDirection = Vector3.zero;
        }

        transform.position = target.transform.position + targetDirection;
    }
}
