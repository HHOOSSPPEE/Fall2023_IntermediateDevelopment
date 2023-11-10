using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    private Vector3 offset;
    public Transform spriteTransform; // ��Ҫ��������Sprite��Transform
    public BoxCollider2D targetCollider;

    private void Start()
    {
        if (spriteTransform == null)
        {
            // ���û��ָ��Ҫ��������Sprite��Transform����ʹ�ñ����Transform
            spriteTransform = transform;
        }

        // ���������
        Cursor.visible = false;
    }

    private void Update()
    {
        // ��ȡ��굱ǰλ��
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ����Sprite��λ��Ϊ���λ��
        //spriteTransform.position = new Vector3(mousePosition.x, mousePosition.y, spriteTransform.position.z);
        spriteTransform.position = new Vector3(mousePosition.x, mousePosition.y, -1f);

    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision = targetCollider)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.isPainting = true;
        }
    }
    */
}
