using Bennet;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
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
        Debug.Log($"Start time is: {Time.timeSinceLevelLoadAsDouble}");
        rawImage = GetComponent<RawImage>();
        var texData = EncodeAndSend(texture2D);
        Debug.Log($"data array size is: {System.Buffer.ByteLength(texData)}");
        if (Tools.LoadTextureFromBytes(texData, out Texture2D tempTexture))
        {
            rawImage.SetTextureAndResizeRect(tempTexture);
        }
        else
            Debug.Log("Conversion failed");
        Debug.Log($"End time is: {Time.timeSinceLevelLoadAsDouble}");
    }
    byte[] EncodeAndSend(Texture2D texture2D)
    {
        byte[] bytes = ImageConversion.EncodeToPNG(texture2D);
        //send bytes here

        return bytes;
    }
    

}
