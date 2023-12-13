using Bennet;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public ComputeShader apply;
    public RawImage rawImage;
    public Texture2D texture2D;
    public Texture2D tempTexture;
    public RenderTexture renderTexture;


    private void Start()
    {
        /*
        renderTexture = new RenderTexture(texture2D.width, texture2D.height, 0, RenderTextureFormat.ARGB32, 0);
        renderTexture.enableRandomWrite = true;
        renderTexture.filterMode = FilterMode.Point;

        tempTexture = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, false);
        tempTexture.SetPixels(texture2D.GetPixels());

        var pixels = tempTexture.GetPixels();
        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = new Color(Random.value, Random.value, Random.value, Random.value);
        tempTexture.SetPixels(pixels);
        tempTexture.filterMode = FilterMode.Point;

        tempTexture.Apply();
        Graphics.Blit(texture2D, renderTexture);

        apply.SetInt("sizeX", texture2D.width);
        apply.SetInt("sizeY", texture2D.height);
        RenderTexture.active = renderTexture;
        apply.SetTexture(0, "Result", renderTexture);
        apply.SetTexture(0, "tex", tempTexture);
        apply.SimpleDispatch(renderTexture);

        RenderTexture.active = null;
        rawImage = GetComponent<RawImage>();

        rawImage.texture = renderTexture;
        */

        /*
        renderTexture = new RenderTexture(texture2D.width, texture2D.height, 0, RenderTextureFormat.ARGB32, 0);
        renderTexture.enableRandomWrite = true;
        Graphics.Blit(texture2D, renderTexture);

        tempTexture = new Texture2D(texture2D.width, texture2D.height, TextureFormat.ARGB32, false);
        RenderTexture.active = renderTexture;
        Debug.Log($"read pixels start time: {Time.realtimeSinceStartup}");
        tempTexture.ReadPixels(new Rect(0,0,texture2D.width, texture2D.height),0,0);
        tempTexture.Apply();
        Debug.Log($"read pixels end time: {Time.realtimeSinceStartup}");


        Debug.Log($"Async start time: {Time.realtimeSinceStartup}");
        Tools.AsyncTextureCropCropTexture(renderTexture, tempTexture,null);
        rawImage.SetTextureAndResizeRect(tempTexture);
        RenderTexture.active = null;
        */

    }

    /// <summary>It is async anyway, so I combined requesting data from gpu and cropping data together</summary>
    
    
}
