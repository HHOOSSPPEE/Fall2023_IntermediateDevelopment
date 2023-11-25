using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    private Vector3 offset;
    public Transform spriteTransform; // ��Ҫ��������Sprite��Transform
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
            // ���û��ָ��Ҫ��������Sprite��Transform����ʹ�ñ����Transform
            spriteTransform = transform;
        }
        */

        ChangeChildImage(spr_brush);

        // ���������
        Cursor.visible = false;
    }

    private void Update()
    {
        // ��ȡ��굱ǰλ��
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePosition = Input.mousePosition;

        // ����Sprite��λ��Ϊ���λ��
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
