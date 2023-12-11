using Bennet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AnotherTest : MonoBehaviour
{
    public Test test;
    RawImage image;
    public Texture2D texture;
    public RenderTexture renderTexture;
    public ComputeShader fill;

    void Start()
    {
        renderTexture = texture.CreateRenderTexture();
        GetComponent<RawImage>().texture = renderTexture;

        fill.SetTexture(0, "Result", renderTexture);
        fill.Dispatch(0, Mathf.CeilToInt((float)renderTexture.width / 32), Mathf.CeilToInt((float)renderTexture.width / 32), 1);
    }

    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            apply.SetTexture(0, "Result", renderTexture);
            apply.SetTexture(0, "a", a);
            apply.SetTexture(0, "b", a);
            int[] size = { 256, 256 };
            apply.SetInts("textureSize", size);
            apply.Dispatch(0, Mathf.CeilToInt(renderTexture.width / 32f), Mathf.CeilToInt(renderTexture.height / 32f), 1);
            
            var tex = new Texture2D(renderTexture.width,renderTexture.height,TextureFormat.ARGB32,false);
            Graphics.CopyTexture(renderTexture, tex);
            image.sprite = tex.GenerateSprite();

        }
        */
    }
}
