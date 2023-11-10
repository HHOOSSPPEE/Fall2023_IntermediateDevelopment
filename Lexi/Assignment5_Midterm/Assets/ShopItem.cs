using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    public GameObject target;
    public void AddObjectToDisplay()
    {
        TypingText typingText = FindObjectOfType<TypingText>();
        ShopPalette shopPalette = FindObjectOfType<ShopPalette>();

        if (typingText != null)
        {
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
