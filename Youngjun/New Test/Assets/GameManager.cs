using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Texture2D customCursor;

    void Start()
    {
        Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
