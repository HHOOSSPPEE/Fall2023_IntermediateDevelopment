using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Message : MonoBehaviour
{
    // Start is called before the first frame update
    public Font font;
    public int fontSize = 10;
    [Multiline]//允许多行输入
    public string text = "COlor";

    private bool showText = false;
    private GUIStyle style;

    public void Start()
    {
        style = new GUIStyle("box");
    }

    public void OnPointerEnter2D(PointerEventData eventData)
    {
        showText = true;
    }
    public void OnPointerExit2D(PointerEventData eventData)
    {
        showText = false;
    }
    public void OnGUI()
    {
        Debug.Log("ongui");
        style.font = font;
        style.fontSize = fontSize;
        var vt = style.CalcSize(new GUIContent(text));
        if (showText)
            GUI.Box(new Rect(Input.mousePosition.x, Screen.height - Input.mousePosition.y, vt.x, vt.y), text, style);
    }

}
