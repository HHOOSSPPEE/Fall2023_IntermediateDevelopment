using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public GameObject target;
    public TextMeshProUGUI textUI;
    public int price;
    private string label = "";

    private void Start()
    {
        textUI = GameObject.Find("Label").GetComponent<TextMeshProUGUI>();
        BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>(); 
        boxCollider2D.size = new Vector2(2f, 2f);
        boxCollider2D.offset = new Vector2(0f, 0f);
        boxCollider2D.isTrigger = true;
    }
    private void OnMouseOver()
    {
        
    }
    public void isMoneyEnough()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager.money >= price)
        {
            gameManager.money -= price;
            AddObjectToDisplay();
            gameObject.SetActive(false);
        }
    }
    private void AddObjectToDisplay()
    {
        TypingText typingText = FindObjectOfType<TypingText>();
        ShopPalette shopPalette = FindObjectOfType<ShopPalette>();

        if (typingText != null)
        {
            label = target.name;
            textUI.text = label;

            // 创建一个新数组来存储更新后的对象
            GameObject[] updatedObjects = new GameObject[typingText.displayObjects.Length + 1];

            // 将现有对象复制到新数组中
            for (int i = 0; i < typingText.displayObjects.Length; i++)
            {
                updatedObjects[i] = typingText.displayObjects[i];
            }

            // 将新对象添加到数组的末尾
            updatedObjects[updatedObjects.Length - 1] = target;

            // 使用更新后的数组来更新TypingText脚本的displayObjects
            typingText.displayObjects = updatedObjects;
            shopPalette.AddObject(target);
            

        }
    }
}
