using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{

    [Header("Set Up")]
    public Transform GoToPoint;
    public int itemID, requiredItemID;

    [Header("Success")]
    public GameObject[] objectsToRemove;
    public Sprite itemSlotSprite;

    [Header("Failure")]
    public string objectName;
    public Vector2 nameTagSize = new Vector2(3, 0.65f);
    [TextArea(3,3)]
    public string hintMessage;
    public Vector2 hintBoxSize = new Vector2(4, 0.65f);
    [Header("To Do List")]
    public string toDoList;
    public Vector2 toDoListSize = new Vector2(3, 0.65f);


}
