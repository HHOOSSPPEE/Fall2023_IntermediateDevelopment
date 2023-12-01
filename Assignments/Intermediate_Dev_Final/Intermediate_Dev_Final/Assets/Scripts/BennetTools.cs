using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bennet
{
    public static class Tools
    {
        public static Sprite LoadSpriteFromFile(string path)
        {
            byte[] fileData = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(32, 32); // background textures are and should be 32*32
            texture.LoadImage(fileData);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, 32, 32), Vector2.one * .5f);
            return sprite;
        }
    }
}

