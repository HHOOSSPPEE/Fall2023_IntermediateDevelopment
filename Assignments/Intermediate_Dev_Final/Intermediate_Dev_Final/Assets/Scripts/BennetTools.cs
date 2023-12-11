using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;

namespace Bennet
{
    public static class Tools
    {
        public static string RGBtoHexString(UnityEngine.Color color, bool needSharp)
        {
            int r = Mathf.RoundToInt(color.r * 255);
            int g = Mathf.RoundToInt(color.g * 255);
            int b = Mathf.RoundToInt(color.b * 255);
            string hex = needSharp ? "#" : "";
            hex += string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
            return hex;
        }
        public static Vector2 ScreenToTexturePointInImage(Camera camera, UnityEngine.UI.Image image, Vector2 screenPoint)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(image.rectTransform, Input.mousePosition, camera, out var localPos))
                throw new UnexpectedInputException("Screen to local point conversion failed.");

            var rectWidth = image.rectTransform.rect.width;
            var rectHeight = image.rectTransform.rect.height;
            localPos = new Vector2(localPos.x + rectWidth / 2, localPos.y + rectHeight / 2);
            var relativePos = localPos / image.rectTransform.rect.size;
            var texWidth = image.mainTexture.width;
            var texHeight = image.mainTexture.height;
            var texturePos = new Vector2(relativePos.x * texWidth, relativePos.y * texHeight);

            return texturePos;
        }
        public static Vector2 ScreenToTexturePointInRawImage(Camera camera, UnityEngine.UI.RawImage rawImage, Vector2 screenPoint)
        {
            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImage.rectTransform, Input.mousePosition, camera, out var localPos))
                throw new UnexpectedInputException("Screen to local point conversion failed.");

            var rectWidth = rawImage.rectTransform.rect.width;
            var rectHeight = rawImage.rectTransform.rect.height;
            localPos = new Vector2(localPos.x + rectWidth / 2, localPos.y + rectHeight / 2);
            var relativePos = localPos / rawImage.rectTransform.rect.size;
            var texWidth = rawImage.mainTexture.width;
            var texHeight = rawImage.mainTexture.height;
            var texturePos = new Vector2(relativePos.x * texWidth, relativePos.y * texHeight);

            return texturePos;
        }
    }
    public static class ExtensionMethods
    {
        #region Texture2D
        /// <summary>Beaware, this don't apply on original texture</summary>
        public static Texture2D CropTransparentPixels(this Texture2D texture)
        {
            Color32[] pixels = texture.GetPixels32();
            int width = texture.width;
            int height = texture.height;
            int minX = width;
            int minY = height;
            int maxX = 0;
            int maxY = 0;

            // Get Min and Max Values
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

            // Does any non-transparent pixel exist
            if (minX > maxX || minY > maxY)
            {
                Debug.LogWarning("No non-transparent pixels found.");
                return null;
            }

            // Crop and Set properties
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
            croppedTexture.alphaIsTransparency = texture.alphaIsTransparency;
            croppedTexture.filterMode = texture.filterMode;
            croppedTexture.wrapMode = texture.wrapMode;
            //and more but not necessary
            croppedTexture.Apply(); //may costy I don't care

            return croppedTexture;
        }
        public static Texture2D Clone(this Texture2D texture)
        {
            byte[] rawTextureData = texture.GetRawTextureData();
            Texture2D clonedTexture = new Texture2D(texture.width, texture.height, texture.format, texture.mipmapCount > 1);
            clonedTexture.LoadRawTextureData(rawTextureData);
            clonedTexture.Apply();

            return clonedTexture;
        }
        /// <summary>Generate a new Sprite based on texture information</summary>
        public static Sprite CreateSprite(this Texture2D texture2D)
        {
            return Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one / 2);
        }
        public static RenderTexture CreateRenderTexture(this Texture2D texture2d)
        {
            var renderTextrue = new RenderTexture(texture2d.width, texture2d.height, 0,RenderTextureFormat.ARGB32);
            renderTextrue.enableRandomWrite = true;
            Graphics.Blit(texture2d, renderTextrue);
            renderTextrue.Create();
            return renderTextrue;
        }
        #endregion

        #region UI related
        public static void CopyPropertiesFrom(this RectTransform self, RectTransform sourceRectTransform)
        {
            self.sizeDelta = sourceRectTransform.sizeDelta;
            self.pivot = sourceRectTransform.pivot;
            self.anchorMin = sourceRectTransform.anchorMin;
            self.anchorMax = sourceRectTransform.anchorMax;
            self.anchoredPosition3D = sourceRectTransform.anchoredPosition3D;
            self.offsetMin = sourceRectTransform.offsetMin;
            self.offsetMax = sourceRectTransform.offsetMax;
            self.rotation = sourceRectTransform.rotation;
            self.localScale = sourceRectTransform.localScale;
        }

        #endregion

        #region Conversion


        #endregion

        #region Compute Shader

        public static void SimpleDispatch(this ComputeShader self, RenderTexture itsRenderTexture)
        {
            int kernelIndex = self.FindKernel("CSMain");
            self.GetKernelThreadGroupSizes(kernelIndex, out uint x, out uint y, out uint z);
            int width = Mathf.CeilToInt((float)itsRenderTexture.width / x);
            int height = Mathf.CeilToInt((float)itsRenderTexture.height / y);
            int depth = (int)z;
            self.Dispatch(kernelIndex,width, height, 1);
        }

        #endregion
    }
    /// <summary>Legal input but cannot return any meaningful value. It is goint to return null.</summary>
    public class UnexpectedInputException : Exception
    {
        public UnexpectedInputException() : base("Unable to proceed because the Input.")
        {
        }
        public UnexpectedInputException(string message) : base(message)
        {
        }
        public UnexpectedInputException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}