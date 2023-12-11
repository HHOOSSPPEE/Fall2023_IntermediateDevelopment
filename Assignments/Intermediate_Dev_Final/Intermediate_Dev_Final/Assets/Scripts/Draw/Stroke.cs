using Bennet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Stroke : MonoBehaviour
{
    private RectTransform rectTransform;
    DrawManager drawManager;
    public bool startDrawing = false;
    private Image image;
    public Color color;
    public int width;
    public Texture2D texture;
    public Sprite sprite;
    private Color32[] currentColors;

    private Vector2 pMousePosition;
    private float currentDragLength = 0f;
    private int brushIntervalPercentage = 1;
    private float brushDotsInterval;

    private void Start()
    {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        drawManager = DrawManager.Instance;
        color = drawManager.strokeColor;
        width = drawManager.strokeWidth;
        pMousePosition = Input.mousePosition;
        brushDotsInterval = (float)brushIntervalPercentage / 100 * width;

        //create new transparent texture
        
        /*
        texture = new Texture2D(drawManager.CanvasSize.x, drawManager.CanvasSize.y,TextureFormat.RGBA32,false);
        currentColors = new Color32[drawManager.CanvasSize.x * drawManager.CanvasSize.y];
        for (int i = currentColors.Length - 1; i >= 0; --i)
            currentColors[i] = Color.clear;

        texture.SetPixels32(currentColors);
        texture.alphaIsTransparency = true;
        texture.filterMode = FilterMode.Point;
        texture.name = "tempTexture";
        texture.Apply();
        */
        sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.one * 0.5f);
        image.sprite = sprite;
        sprite.name = "tempSprite";

        rectTransform.anchoredPosition3D = Vector3.zero;
        rectTransform.anchorMin = Vector2.zero;
        rectTransform.anchorMax = Vector2.one;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.localScale = Vector3.one;
    }
    private void Update()
    {
        if (startDrawing)
        {
            //if end drawing
            currentDragLength += Vector2.Distance(Input.mousePosition, pMousePosition);

            if (currentDragLength > brushDotsInterval)
                ApplyBrushOnPath(pMousePosition, Input.mousePosition, width, color);
            else
                ApplyBrush(Input.mousePosition);
            currentDragLength = 0;
            pMousePosition = Input.mousePosition;

        }
    }
    public void EndStroke()
    {
        CropTransparentPixelsAndSet();
        drawManager.AssignStrokeToLayer(gameObject);
        Destroy(this);
    }

    private void ApplyBrush(Vector2 screenPosition)
    {
        Vector2 texturePosition = Tools.ScreenToTexturePointInImage(Camera.main, image, screenPosition);
        ApplyColorOnPixelsWithBrush(texturePosition, width, color);
    }
    private void ApplyBrushOnPath(Vector2 start, Vector2 end, int width, Color color)
    {
        start = Tools.ScreenToTexturePointInImage(Camera.main, image, start);
        end = Tools.ScreenToTexturePointInImage(Camera.main, image, end);

        float distance = Vector2.Distance(start, end);
        Vector2 direction = (start - end).normalized;
        Vector2 drawPosition = start;
        float lerpStep = brushDotsInterval;
        for (float lerp = 0; lerp <= 1; lerp += brushDotsInterval)
        {
            drawPosition = Vector2.Lerp(start, end, lerp);
            ApplyColorOnPixelsWithBrush(drawPosition, width, color);
        }
    }

    private void ApplyColorOnPixelsWithBrush(Vector2 centerPixel, int brushWidth, Color color)
    {
        for (int x = (int)centerPixel.x - brushWidth; x <= (int)centerPixel.x + brushWidth; x++)
        {
            if (x >= (int)sprite.rect.width || x < 0)
                continue;
            for (int y = (int)centerPixel.y - brushWidth; y <= (int) centerPixel.y + brushWidth; y++)
            {
                if (y >(int)sprite.rect.height || y < 0)
                    continue;
                if (Vector2.Distance(new Vector2(x,y),centerPixel) < width)
                    ChangeColorOnPixel(x,y,color);
            }
        }
        texture.SetPixels32(currentColors);
        texture.Apply();
    }
    /// <summary></summary>
    private void ChangeColorOnPixel(int x, int y, Color color)
    {
        int index = y * (int)sprite.rect.width + x;

        if (index > currentColors.Length - 1 || index < 0)
            return; 
        currentColors[index] = color;
    }

    public void CropTransparentPixelsAndSet()
    {
        //find min and max values
        Color32[] pixels = texture.GetPixels32();
        int width = texture.width;
        int height = texture.height;
        int minX = width;
        int minY = height;
        int maxX = 0;
        int maxY = 0;
        for (int y = 0; y < texture.height; y++) 
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color32 pixel = pixels[y * texture.width + x];
                if (pixel.a != 0)
                {
                    minX = Mathf.Min(minX, x);
                    minY = Mathf.Min(minY, y);
                    maxX = Mathf.Max(maxX, x);
                    maxY = Mathf.Max(maxY, y);
                }
            }
        }

        // if no non-transparent pixel. According to logic, this should not happen, but I still should write an exception here
        if (minX > maxX || minY > maxY)
            throw new UnexpectedInputException();

        // Create new Texture to Store the value
        int newWidth = maxX - minX + 1;
        int newHeight = maxY - minY + 1;
        Texture2D croppedTexture = new Texture2D(newWidth, newHeight);
        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                Color32 pixel = pixels[y * width + x];
                croppedTexture.SetPixel(x - minX, y - minY, pixel);
            }
        }

        //Set properties
        croppedTexture.alphaIsTransparency = texture.alphaIsTransparency;
        croppedTexture.filterMode = texture.filterMode;
        croppedTexture.wrapMode = texture.wrapMode;
        croppedTexture.Apply();

        croppedTexture.name = "Drawn Stroke";
        image.sprite = Sprite.Create(croppedTexture, new Rect(0, 0, croppedTexture.width, croppedTexture.height), Vector2.one / 2); // Bye old temp Sprite
        image.sprite.name = "Drawn Stroke Sprite";


        //set RectTransform properties
        rectTransform.pivot = Vector2.one / 2;
        rectTransform.anchorMin = new Vector2((float)minX / (float)texture.width, (float)minY / (float)texture.height);
        rectTransform.anchorMax = new Vector2((float)maxX / (float)texture.width, (float)maxY / (float)texture.height);
        rectTransform.anchoredPosition3D = Vector3.zero;
    }
}

public struct CroppedTextureInfo
{
    public Texture2D texture;
    public RectTransformInfo rectTransformInfo;

    public CroppedTextureInfo(Texture2D texture, RectTransformInfo rectTransformInfo)
    {
        this.texture = texture;
        this.rectTransformInfo = rectTransformInfo;
    }
}
public struct RectTransformInfo
{
    public Vector2 pivot;
    public Vector2 anchorMin;
    public Vector2 anchorMax;
    public Vector3 anchoredPosition3D;
    public RectTransformInfo(Vector2 pivot, Vector2 anchorMin, Vector2 anchorMax, Vector3 anchoredPosition3D)
    {
        this.pivot = pivot;
        this.anchorMin = anchorMin;
        this.anchorMax = anchorMax;
        this.anchoredPosition3D = anchoredPosition3D;
    }
}