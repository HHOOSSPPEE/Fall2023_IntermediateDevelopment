using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    private Vector3 offset;
    public Transform spriteTransform; // 您要跟随鼠标的Sprite的Transform
    public BoxCollider2D targetCollider;

    private void Start()
    {
        if (spriteTransform == null)
        {
            // 如果没有指定要跟随鼠标的Sprite的Transform，请使用本身的Transform
            spriteTransform = transform;
        }

        // 禁用鼠标光标
        Cursor.visible = false;
    }

    private void Update()
    {
        // 获取鼠标当前位置
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 设置Sprite的位置为鼠标位置
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
