using Bennet;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class StrokeManager : MonoBehaviour
{
    private Color color;
    public float width;
    private ComputeShader clearCanvas;
    private ComputeShader stroke;
    private ComputeShader eraser;
    public RenderTexture renderTexture;
    public bool isDrawing = false;
    public bool isErasing = false;
    private RawImage rawImage;
    public Texture2D result;
    private Vector2 previousMousePosition;
    private void Awake()
    {
        clearCanvas = Resources.Load<ComputeShader>("ComputeShaders/Clear");
        stroke = Resources.Load<ComputeShader>("ComputeShaders/Stroke");
        rawImage = GetComponent<RawImage>();
    }
    private void Start()
    {
        UpdateRenderTexutre();
        rawImage.texture = renderTexture;
        rawImage.material.mainTexture = renderTexture;
        result = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        RenderTexture.active = renderTexture;
        result.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        RenderTexture.active = null;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartNewStoke();
        if (Input.GetMouseButtonUp(0))
            isDrawing = false;
            //EndStroke();
        if (isDrawing && Input.GetMouseButton(0))
            ApplyStroke();
        if (Input.GetMouseButtonDown(1))
            StartNewErasing();
        if (Input.GetMouseButtonUp(1))
            isErasing = false;
        if (isErasing && Input.GetMouseButton(1))
            ApplyEraser();
        
        if (Input.GetKey(KeyCode.Space))
        {
            //var mousePosition = Tools.ScreenToTexturePointInRawImage(Camera.main, rawImage, Input.mousePosition);
            //Debug.Log(result.GetPixel((int)mousePosition.x, (int)mousePosition.y));
            //result = CropTransparentPixels(renderTexture);
        }
    }
    private void UpdateRenderTexutre()
    {
        var canvasSize = DrawManager.Instance.CanvasSize;
        renderTexture = new RenderTexture(canvasSize.x, canvasSize.y, 0, RenderTextureFormat.ARGB32);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        rawImage.texture = renderTexture;
        RenderTexture.active = renderTexture;
        clearCanvas.SetTexture(0, "Result", renderTexture);
        clearCanvas.SimpleDispatch(renderTexture);
        RenderTexture.active = null;
    }
    private void StartNewStoke()
    {
        stroke.SetFloat("radius", width);
        isDrawing = true;
        previousMousePosition = Input.mousePosition;
    }
    private void EndStroke()
    {
        isDrawing = false;

        var newPivot = CropTransparentPixelsAndGetNewPivot(renderTexture, out var newStepTexture);
        var drawManager = DrawManager.Instance;
        GameObject newStep = Instantiate(Resources.Load<GameObject>("Prefabs/DefaultRawImage"));
        //temporarily
        newStep.transform.SetParent(transform);

        RawImage newStepRawImage = newStep.GetComponent<RawImage>();
        newStepRawImage.texture = newStepTexture;
        //pivot
        newStepRawImage.rectTransform.pivot = newPivot;
        //scale
        var xScale = (float)newStepTexture.width / drawManager.CanvasSize.x;
        var yScale = (float)newStepTexture.height / drawManager.CanvasSize.y;
        newStepRawImage.rectTransform.localScale = new Vector3(xScale, yScale, 1);
        //anchor
        newStepRawImage.rectTransform.anchorMin = Vector2.zero;
        newStepRawImage.rectTransform.anchorMax = Vector2.one;
        newStepRawImage.rectTransform.offsetMin = Vector2.zero;
        newStepRawImage.rectTransform.offsetMax = Vector2.one;
        newStepRawImage.rectTransform.anchoredPosition3D = Vector3.zero;


        //drawManager.AssignNewStepToCurrentLayer(newStep);
        clearCanvas.SimpleDispatch(renderTexture);
    }
    private void ApplyStroke()
    {

        color = ColorPicker.Instance.color;
        RenderTexture.active = renderTexture;
        stroke.SetTexture(0, "Result", renderTexture);
        stroke.SetVector("brushColor", new Vector4(color.r, color.g, color.b, color.a));
        var mousePos = Tools.ScreenToTexturePointInRawImage(Camera.main, rawImage, Input.mousePosition);
        var previousMousePos = Tools.ScreenToTexturePointInRawImage(Camera.main, rawImage, previousMousePosition);
        var distance = Vector2.Distance(mousePos, previousMousePos);

        /*
        Debug.Log($"current mosue pos is {mousePos}. previous mouse pos is {previousMousePos}. The distance should be {distance}");
        if (distance > width /2 )
        {
            var lerpTime = distance / width * 2;
            var increaseAmount = (mousePos - previousMousePos) / lerpTime;
            var currentPosition = mousePos;
            for ( int i = 0; i < lerpTime; i++ )
            {
                stroke.SetVector("position", currentPosition);
                stroke.SimpleDispatch(renderTexture);
                currentPosition += increaseAmount;
            }
        }
        else
        {
            stroke.SetVector("position", mousePos);
            stroke.SimpleDispatch(renderTexture);
        }
        */

        stroke.SetVector("position", mousePos);
        stroke.SimpleDispatch(renderTexture);
        RenderTexture.active = null;

        previousMousePosition = Input.mousePosition;
    }
    private void StartNewErasing()
    {
        isErasing = true;
        stroke.SetFloat("radius", width);
    }
    private void ApplyEraser()
    {
        color = Color.clear;
        RenderTexture.active = renderTexture;
        stroke.SetTexture(0, "Result", renderTexture);
        stroke.SetVector("brushColor", new Vector4(color.r, color.g, color.b, color.a));
        var mousePos = Tools.ScreenToTexturePointInRawImage(Camera.main, rawImage, Input.mousePosition);
        stroke.SetVector("position", mousePos);
        stroke.SimpleDispatch(renderTexture);
        RenderTexture.active = null;

        previousMousePosition = Input.mousePosition;
    }
    /// <summary>Returns the new pivot, out the texture. I'm too lazy to make a struct</summary>
    private Vector2 CropTransparentPixelsAndGetNewPivot(RenderTexture renderTexture, out Texture2D croppedTexture)
    {
        croppedTexture = default(Texture2D);
        var texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        //Graphics.CopyTexture(renderTexture, texture);
        RenderTexture.active = renderTexture;
        texture.ReadPixels(new Rect(0,0,renderTexture.width, renderTexture.height),0,0);
        texture.Apply();
        RenderTexture.active = null;
        var pixels = texture.GetPixels();
        int2 size = new int2(texture.width, texture.height);
        int2 min = new int2(size.x, size.y);
        int2 max = new int2();
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                if (pixels[y * texture.width + x].a != 0)
                {
                    min.x = Mathf.Min(min.x, x);
                    min.y = Mathf.Min(min.y, y);
                    max.x = Mathf.Max(max.x, x);
                    max.y = Mathf.Max(max.y, y);
                }
            }
        }
        if (min.x > max.x || min.y > max.y)
            throw new UnexpectedInputException();

        int2 newSize = new int2(max.x - min.x + 1, max.y - min.y + 1);
        croppedTexture = new Texture2D(newSize.x, newSize.y, TextureFormat.ARGB32, false);
        for (int y = min.y; y <= max.y;y++)
        {
            for (int x = min.x; x <= max.x;x++)
            {
                var pixel = pixels[y * texture.width + x];
                croppedTexture.SetPixel(x - min.x, y - min.y, pixel);
            }
        }
        croppedTexture.filterMode = texture.filterMode;
        croppedTexture.wrapMode = texture.wrapMode;
        croppedTexture.Apply();

        croppedTexture.name = "Drawn Stroke";

        var pivotX = (float)(max.x - min.x) / 2  * (renderTexture.width / newSize.x);
        var pivotY = (float)(max.y - min.y) / 2  * (renderTexture.width / newSize.y);


        Vector2 newPivot = new Vector2(pivotX, pivotY);
        return newPivot;
    }
}
