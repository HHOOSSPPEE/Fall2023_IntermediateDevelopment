using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCloser : MonoBehaviour
{
    public Image Characters;
    public void closeImage()
    {
        Characters.enabled = false;
    }

    public void openImage()
    {
        Characters.enabled = true;
    }
}
