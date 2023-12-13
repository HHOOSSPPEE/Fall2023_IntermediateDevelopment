using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

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
        /// <summary>Not useable since it won't change the reference</summary>
        public static void AsyncTextureCropCropTexture(RenderTexture source, Texture2D target)
        {
            AsyncGPUReadback.Request(source, 0, TextureFormat.RGBA32, (request) => OnReadbackComplete(request, source, target));
        }
        /// <summary>Not useable since it won't change the reference</summary>
        private static void OnReadbackComplete(AsyncGPUReadbackRequest request, RenderTexture source, Texture2D croppedTexture)
        {
            if (request.hasError)
                throw new Exception("GPU readback error detected.");

            NativeArray<Color32> dataArray = request.GetData<Color32>();
            croppedTexture = CropTransparentPixels(dataArray, source);

            dataArray.Dispose();
        }
        /// <summary>Not useable since it won't change the reference</summary>
        public static Texture2D CropTransparentPixels(NativeArray<Color32> dataArray, Texture originalTexture)
        {
            int2 size = new int2(originalTexture.width, originalTexture.height);
            int2 min = new int2(size.x, size.y);
            int2 max = new int2(0, 0);
            for (int y = 0; y < originalTexture.height; y++)
            {
                for (int x = 0; x < originalTexture.width; x++)
                {
                    if (dataArray[y * originalTexture.width + x].a != 0)
                    {
                        min.x = Mathf.Min(min.x, x);
                        min.y = Mathf.Min(min.y, y);
                        max.x = Mathf.Max(max.x, x);
                        max.y = Mathf.Max(max.y, y);
                    }
                }
            }
            if (min.x > max.x || min.y > max.y)
                throw new Exception("There's no non-transparent pixel in the renderTexture");

            int2 newSize = new int2(max.x - min.x + 1, max.y - min.y + 1);
            var croppedTexture = new Texture2D(newSize.x, newSize.y, TextureFormat.ARGB32, false);
            for (int y = min.y; y <= max.y; y++)
            {
                for (int x = min.x; x <= max.x; x++)
                {
                    var pixel = dataArray[y * originalTexture.width + x];
                    croppedTexture.SetPixel(x - min.x, y - min.y, pixel);
                }
            }
            croppedTexture.name = "Cropped Texture";
            croppedTexture.Apply();
            croppedTexture.filterMode = originalTexture.filterMode;
            croppedTexture.wrapMode = originalTexture.wrapMode;
            //and more but not necessary
            croppedTexture.Apply(); //may costy I don't care

            return croppedTexture;
        }
    }
    public static class ExtensionMethods
    {
        #region Texture2D

        /// <summary>erhaps will cause a little precision lost?</summary>
        public static Texture2D CropTransparentPixels32(this Texture2D texture)
        {
            Color32[] pixels = texture.GetPixels32();
            return pixels.CropTransparentPixels32(texture);
        }

        /// <summary>Four times the memory usage of the CropTransparentPixels32 method, is it worth it for a little precision?</summary>
        public static Texture2D CropTransparentPixels(this Texture2D texture)
        {
            UnityEngine.Color[] pixels = texture.GetPixels();
            return pixels.CropTransparentPixels(texture);
        }

        /// <summary>erhaps will cause a little precision lost?</summary>
        public static Texture2D CropTransparentPixels32(this Color32[] pixels, Texture2D origin)
        {
            int2 size = new int2(origin.width, origin.height);
            int2 min = new int2(size.x, size.y);
            int2 max = new int2(0, 0);
            for (int y = 0; y < origin.height; y++)
            {
                for (int x = 0; x < origin.width; x++)
                {
                    if (pixels[y * origin.width + x].a != 0)
                    {
                        min.x = Mathf.Min(min.x, x);
                        min.y = Mathf.Min(min.y, y);
                        max.x = Mathf.Max(max.x, x);
                        max.y = Mathf.Max(max.y, y);
                    }
                }
            }
            if (min.x > max.x || min.y > max.y)
                throw new Exception("There's no non-transparent pixel in the renderTexture");

            int2 newSize = new int2(max.x - min.x + 1, max.y - min.y + 1);
            var croppedTexture = new Texture2D(newSize.x, newSize.y, TextureFormat.ARGB32, false);
            for (int y = min.y; y <= max.y; y++)
            {
                for (int x = min.x; x <= max.x; x++)
                {
                    var pixel = pixels[y * origin.width + x];
                    croppedTexture.SetPixel(x - min.x, y - min.y, pixel);
                }
            }
            croppedTexture.name = "Cropped Texture";
            croppedTexture.Apply();
            croppedTexture.filterMode = origin.filterMode;
            croppedTexture.wrapMode = origin.wrapMode;
            //and more but not necessary
            croppedTexture.Apply(); //may costy I don't care

            return croppedTexture;
        }

        /// <summary>Four times the memory usage of the CropTransparentPixels32 method, is it worth it for a little precision?</summary>
        public static Texture2D CropTransparentPixels(this UnityEngine.Color[] pixels, Texture2D originalTexture)
        {
            int2 size = new int2(originalTexture.width, originalTexture.height);
            int2 min = new int2(size.x, size.y);
            int2 max = new int2(0, 0);
            for (int y = 0; y < originalTexture.height; y++)
            {
                for (int x = 0; x < originalTexture.width; x++)
                {
                    if (pixels[y * originalTexture.width + x].a != 0)
                    {
                        min.x = Mathf.Min(min.x, x);
                        min.y = Mathf.Min(min.y, y);
                        max.x = Mathf.Max(max.x, x);
                        max.y = Mathf.Max(max.y, y);
                    }
                }
            }
            if (min.x > max.x || min.y > max.y)
                throw new Exception("There's no non-transparent pixel in the renderTexture");

            int2 newSize = new int2(max.x - min.x + 1, max.y - min.y + 1);
            var croppedTexture = new Texture2D(newSize.x, newSize.y, TextureFormat.ARGB32, false);
            for (int y = min.y; y <= max.y; y++)
            {
                for (int x = min.x; x <= max.x; x++)
                {
                    var pixel = pixels[y * originalTexture.width + x];
                    croppedTexture.SetPixel(x - min.x, y - min.y, pixel);
                }
            }
            croppedTexture.name = "Cropped Texture";
            croppedTexture.Apply();
            croppedTexture.filterMode = originalTexture.filterMode;
            croppedTexture.wrapMode = originalTexture.wrapMode;
            //and more but not necessary
            croppedTexture.Apply(); //may costy I don't care

            return croppedTexture;
        }


        /// <summary>Generate a new Sprite based on texture information</summary>
        public static Sprite CreateSprite(this Texture2D texture2D) => Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.one / 2);

        /// <summary>By default the RenderTextureFormat is ARGB32</summary>
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
        public static void SetTextureAndResizeRect(this RawImage self, Texture texture)
        {
            self.texture = texture;
            self.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(texture.width, texture.height);
        }
        #endregion

        #region Conversion


        #endregion

        #region Compute Shader

        public static void SimpleDispatch(this ComputeShader self, RenderTexture Result)
        {
            int kernelIndex = self.FindKernel("CSMain");
            self.GetKernelThreadGroupSizes(kernelIndex, out uint x, out uint y, out uint z);
            int width = Mathf.CeilToInt((float)Result.width / x);
            int height = Mathf.CeilToInt((float)Result.height / y);
            int depth = (int)z;
            RenderTexture previousActive = RenderTexture.active;
            RenderTexture.active = Result;
            self.Dispatch(kernelIndex, width, height, depth);
            RenderTexture.active = previousActive;
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