using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public bool activated;
    private Color colorEnabled = new Color(1f, 1f, 1f, 1f);
    private Color colorDisabled = new Color(1f, 1f, 1f, 1f);


    void Start()
    {
        colorDisabled = Color.white; 
        colorEnabled = ColorUtility.TryParseHtmlString("#E27396", out Color convertedColor) ? convertedColor : Color.white;
        //colorDisabled = ColorUtility.TryParseHtmlString("#CE3072", out Color convertedColor) ? convertedColor : Color.white;

        colorEnabled.a = 1f;
        colorDisabled.a = 0.01f;
    }

    private void Update()
    {
        if (activated)
        {
            EnableRecursively(transform);
        }
        else DisableRecursively(transform);
    }

    void EnableRecursively(Transform currentTransform)
    {
        SpriteRenderer spriteRenderer = currentTransform.GetComponent<SpriteRenderer>();
        CircleCollider2D circleCollider2D = currentTransform.GetComponent<CircleCollider2D>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = colorEnabled;
        }

        if (circleCollider2D != null)
        {
            circleCollider2D.enabled = true;
        }

        for (int i = 0; i < currentTransform.childCount; i++)
        {
            EnableRecursively(currentTransform.GetChild(i));
        }
    }
    void DisableRecursively(Transform currentTransform)
    {
        SpriteRenderer spriteRenderer = currentTransform.GetComponent<SpriteRenderer>();
        CircleCollider2D circleCollider2D = currentTransform.GetComponent<CircleCollider2D>();
        PolygonCollider2D polygonCollider2D = currentTransform.GetComponent <PolygonCollider2D>();

        if (circleCollider2D != null)
        {
            circleCollider2D.enabled = false;

            if (spriteRenderer != null)
            {
                spriteRenderer.color = colorDisabled;
            }
        }

        if (polygonCollider2D != null)
        {
            polygonCollider2D.enabled = false;

            if (spriteRenderer != null)
            {
                spriteRenderer.color = colorDisabled;
            }
        }

        for (int i = 0; i < currentTransform.childCount; i++)
        {
            DisableRecursively(currentTransform.GetChild(i));
        }
    }

}
