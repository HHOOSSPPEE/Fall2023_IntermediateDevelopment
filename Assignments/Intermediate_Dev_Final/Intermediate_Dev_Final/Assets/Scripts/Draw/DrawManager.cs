using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bennet;


public class DrawManager : MonoBehaviour
{
    [SerializeField] private Vector2 _canvasSize;
    public Vector2 CanvasSize
    {
        get => _canvasSize;
        set
        {
            try
            {
                if (value.x <= 0 || value.y <= 0)
                    throw new SpriteSizeException();
                _canvasSize = value;
            }
            catch { }
        }
    }
    public enum BackgroundType { WhiteBackground, BlackBackground, TransparentDarkBackground, TransparentLightBackground }
    [SerializeField] private BackgroundType _backgroundType;
    public BackgroundType backgroundType { get => _backgroundType; private set => _backgroundType = value; }

    private void Start()
    {
        SetCanvasSize(_canvasSize);
        SetCanvasBackground(BackgroundType.WhiteBackground);
    }
    private void Update()
    {
        SetCanvasSize(_canvasSize);
    }
    private void SetCanvasSize(Vector2 size)
    {
        try
        {
            CanvasSize = size;
            GetComponent<SpriteRenderer>().size = CanvasSize;
        }
        catch (SpriteSizeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private void SetCanvasBackground(BackgroundType backgroundType)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/Draw/" + backgroundType.ToString());
    }
}

public class SpriteSizeException : Exception
{
    public SpriteSizeException() : base("Sprite Size cannot be smaller or equal to 0") { }
}
