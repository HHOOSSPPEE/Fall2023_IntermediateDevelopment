using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName ="ScriptableObject/Weapon")]

public class weapon : ScriptableObject
{
    public enum WeaponType
    {
        //adding attributes, can use in if statements
        //makes more readable
        Physical,
        Magic
    }
    //properites of weapon that might be in the game
    public string weaponName;

    //using enum
    public WeaponType weaponType = WeaponType.Physical;


    //possible values to be checked by game
    public int weaponPower;
    public int weaponrequiredstrength;
}
