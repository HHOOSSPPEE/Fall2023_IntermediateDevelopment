using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public weapon playerWeapon;
    public int playerAttack;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = playerWeapon.weaponPower + 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
