using Bennet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public ComputeShader eraser;
    public ComputeShader brush;
    private Image image;
    public RenderTexture renderTexture;
    public Texture2D texture2d;
    public int eraserSize = 5;
    private void Awake()
    {
        image = GetComponent<Image>();
        var rect = image.rectTransform.rect;
        texture2d = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.ARGB32, false);
        renderTexture = new RenderTexture((int)rect.width, (int)rect.height, 0, RenderTextureFormat.ARGB32);
        renderTexture.enableRandomWrite = true;
        ComputeShader clear = Resources.Load<ComputeShader>("ComputeShaders/Clear");
        clear.SetTexture(0, "Result", renderTexture);
        clear.Dispatch(0, Mathf.CeilToInt((float)renderTexture.width / 32), Mathf.CeilToInt((float)renderTexture.height / 32), 1);
        Graphics.CopyTexture(renderTexture, texture2d);
        image.material.mainTexture = texture2d;
        image.color = Color.white;

        /*
        texture2d = new Texture2D(sourceTexture.width, sourceTexture.height, TextureFormat.ARGB32, false);
        texture2d.name = "texture2d";

        renderTexture = new RenderTexture(sourceTexture.width, sourceTexture.height, 0, RenderTextureFormat.ARGB32);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();
        RenderTexture.active = renderTexture;
        Graphics.Blit(sourceTexture, renderTexture);
        image.sprite = Sprite.Create(texture2d, new Rect(0, 0, texture2d.width, texture2d.height), new Vector2(.5f, .5f));

        image.material.mainTexture = texture2d;
        */
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            SetupEraser();
        if (Input.GetMouseButtonDown(0))
            SetUpBrush();
        if (Input.GetMouseButton(1))
            ApplyEraser();
        if (Input.GetMouseButton(0))
            ApplyBrush();
    }

    private void ApplyBrush()
    {
        var mouseTexPos = Tools.ScreenToTexturePointInImage(Camera.main, image, Input.mousePosition);
        brush.SetFloat("positionX", mouseTexPos.x);
        brush.SetFloat("positionY", mouseTexPos.y);

        brush.Dispatch(0, Mathf.CeilToInt((float)renderTexture.width / 32), Mathf.CeilToInt((float)renderTexture.height / 32), 1);

        Graphics.CopyTexture(renderTexture, texture2d);
        image.material.mainTexture = texture2d;
    }

    private void ApplyEraser()
    {
        var mouseTexPos = Tools.ScreenToTexturePointInImage(Camera.main, image, Input.mousePosition);
        eraser.SetFloat("positionX", mouseTexPos.x);
        eraser.SetFloat("positionY", mouseTexPos.y);

        eraser.Dispatch(0, Mathf.CeilToInt((float)renderTexture.width / 32), Mathf.CeilToInt((float)renderTexture.height / 32), 1);

        Graphics.CopyTexture(renderTexture, texture2d);
        image.material.mainTexture = texture2d;
    }

    private void SetupEraser()
    {
        eraser.SetTexture(0, "Result", renderTexture);
        eraser.SetFloat("radius", eraserSize / 2);
    }

    private void SetUpBrush()
    {
        brush.SetFloat("radius", eraserSize / 2);
        brush.SetVector("brushColor", new Vector4(1, .5f, 1, .5f));
        brush.SetTexture(0, "Result", renderTexture);
    }

    public Texture2D GetRenderedImage()
    {
        Texture2D texture = new Texture2D(renderTexture.width,renderTexture.height);
        RenderTexture.active = renderTexture;
        texture2d.ReadPixels(new Rect(0,0,renderTexture.width,renderTexture.height),0,0);
        texture2d.Apply();
        return texture2d;
    }
}
