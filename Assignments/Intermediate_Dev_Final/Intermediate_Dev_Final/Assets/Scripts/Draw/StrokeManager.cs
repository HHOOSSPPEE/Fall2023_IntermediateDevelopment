using Bennet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrokeManager : MonoBehaviour
{
    private Color color;
    public float width;
    private Texture2D texture2d;
    private ComputeShader clear;
    private ComputeShader stroke;
    private RenderTexture renderTexture;
    private bool isDrawing = false;
    private RawImage rawImage;
    private void Awake()
    {
        clear = Resources.Load<ComputeShader>("ComputeShaders/Clear");
        stroke = Resources.Load<ComputeShader>("ComputeShaders/Stroke");
        rawImage = GetComponent<RawImage>();
    }
    private void Start()
    {
        UpdateRenderTexutre();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartNewStoke();
        if (Input.GetMouseButtonUp(0))
            EndStroke();
        if (isDrawing)
        {

        }

        var mousePos = Tools.ScreenToTexturePointInRawImage(Camera.main, rawImage, Input.mousePosition);
        Debug.Log(mousePos);
    }
    private void UpdateRenderTexutre()
    {
        var canvasSize = DrawManager.Instance.CanvasSize;
        renderTexture = new RenderTexture(canvasSize.x, canvasSize.y, 0, RenderTextureFormat.ARGB32);
        renderTexture.enableRandomWrite = true;
        rawImage.texture = renderTexture;
        RenderTexture.active = renderTexture;
        clear.SetTexture(0, "Result", renderTexture);
        clear.SimpleDispatch(renderTexture);
        RenderTexture.active = null;
    }
    private void ClearCanvas()
    {
        clear.SimpleDispatch(renderTexture);
    }
    private void StartNewStoke()
    {
        ColorPicker.Instance.color = color;
        stroke.SetFloat("radius", width);
        stroke.SetVector("brushColor",new Vector4(color.r, color.g, color.b, color.a));
        isDrawing = true;
    }
    private void EndStroke()
    {

    }
    private void ApplyStroke()
    {
    }
}
