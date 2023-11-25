using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    private Vector3 offset;
    public Transform spriteTransform; // 您要跟随鼠标的Sprite的Transform
    public BoxCollider2D targetCollider;

    public SpriteRenderer spriteRenderer;

    Sprite spr_brush;
    Sprite spr_default;

    SpriteRenderer childSpriteRenderer;
    public Sprite[] sprites;

    private void Start()
    {
        spr_brush = sprites[0];
        spr_default = sprites[1];

        /*
        childSpriteRenderer = GetChildSpriteRendererByName("CursorChild");


        childSpriteRenderer.sprite = spr_brush;

        if (spriteTransform == null)
        {
            // 如果没有指定要跟随鼠标的Sprite的Transform，请使用本身的Transform
            spriteTransform = transform;
        }
        */

        ChangeChildImage(spr_brush);

        // 禁用鼠标光标
        Cursor.visible = false;
    }

    private void Update()
    {
        // 获取鼠标当前位置
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosition = Input.mousePosition;

        // 设置Sprite的位置为鼠标位置
        //spriteTransform.position = new Vector3(mousePosition.x, mousePosition.y, spriteTransform.position.z);
        spriteTransform.position = new Vector3(mousePosition.x, mousePosition.y, -1f);
        
        if (mousePosition.x >= 1050)
        {
            //childSpriteRenderer.sprite = spr_default;
            ChangeChildImage(spr_default);
        }
        else ChangeChildImage(spr_brush);


    }

    /*
    SpriteRenderer GetChildSpriteRendererByName(string childObjectName)
    {
        Transform childTransform = transform.Find(childObjectName);

        if (childTransform != null)
        {
            SpriteRenderer childSpriteRenderer = childTransform.GetComponent<SpriteRenderer>();
            return childSpriteRenderer;
        }

        return null;
    }
    */

    void ChangeChildImage(Sprite sprite)
    {
        Image imageComponent = null;

        foreach(Transform child in transform)
        {
            imageComponent = child.GetComponent<Image>();
            if (imageComponent != null)
            {
                break;
            }
        }

        if (imageComponent != null)
        {
            imageComponent.sprite = sprite;
        }

        
    }
}
