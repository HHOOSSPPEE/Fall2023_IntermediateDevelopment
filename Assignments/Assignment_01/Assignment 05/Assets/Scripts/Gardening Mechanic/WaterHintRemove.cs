using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterHintRemove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public ItemData item;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        item = FindObjectOfType<ItemData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.wateringFull)
        {
            Debug.Log("hide");
            item.hintMessage = " ";
        }
    }


}
