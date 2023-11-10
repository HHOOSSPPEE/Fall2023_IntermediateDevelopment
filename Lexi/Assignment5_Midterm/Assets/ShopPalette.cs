using System.Collections.Generic;
using UnityEngine;

public class ShopPalette : MonoBehaviour
{
    public List<GameObject> purchasedList = new List<GameObject>();

    void Update()
    {
        foreach (GameObject obj in purchasedList)
        {
            obj.SetActive(true);
        }
    }
    public void AddObject(GameObject target)
    {
        purchasedList.Add(target);
    }
}
