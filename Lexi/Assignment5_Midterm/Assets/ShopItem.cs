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

            // ����һ�����������洢���º�Ķ���
            GameObject[] updatedObjects = new GameObject[typingText.displayObjects.Length + 1];

            // �����ж����Ƶ���������
            for (int i = 0; i < typingText.displayObjects.Length; i++)
            {
                updatedObjects[i] = typingText.displayObjects[i];
            }

            // ���¶�����ӵ������ĩβ
            updatedObjects[updatedObjects.Length - 1] = target;

            // ʹ�ø��º������������TypingText�ű���displayObjects
            typingText.displayObjects = updatedObjects;
            shopPalette.AddObject(target);
            

        }
    }
}
