using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicking : MonoBehaviour
{
    // Start is called before the first frame update
    public Color chooseColor;
    public PencilCode pncl;
    public Gradient gradient = new Gradient();
    public bool clrChange = false;

    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        var colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(chooseColor, 0.0f);
        colors[1] = new GradientColorKey(chooseColor, 1.0f);

        // Blend alpha from opaque at 0% to transparent at 100%
        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(0.0f, 1.0f);

        gradient.SetKeys(colors, alphas);


        if (Input.GetMouseButtonDown(0))
        {
            gradient.SetKeys(colors, alphas);
        }
    }
}
