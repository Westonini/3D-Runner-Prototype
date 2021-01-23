using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBLights : MonoBehaviour
{
    Color RGB;
    public float speed = 0.5f;

    void Start()
    {
        //Replace all code instances of RGB to RenderSettings.ambientLight
        RGB.r = 0f; RGB.g = 0.5f; RGB.b = 0f;
    }

    private float SetColorValue(float color, string operation)
    {
        if (operation == "+")
            color += Time.deltaTime * speed;
        else
            color -= Time.deltaTime * speed;

        return color;
    }

    // Update is called once per frame
    void Update()
    {
        if (RGB.r <= 0f && RGB.g >= 0.5f && RGB.b < 0.5f)
        {
            RGB.b = SetColorValue(RGB.b, "+");
        }
        else if (RGB.r <= 0f && RGB.g >= 0 && RGB.b >= 0.5f)
        {
            RGB.g = SetColorValue(RGB.g, "-");
        }
        else if (RGB.r <= 0.5f && RGB.g <= 0 && RGB.b >= 0.5f)
        {
            RGB.r = SetColorValue(RGB.r, "+");
        }
        else if (RGB.r >= 0.5f && RGB.g <= 0 && RGB.b >= 0f)
        {
            RGB.b = SetColorValue(RGB.b, "-");
        }
        else if (RGB.r >= 0.5f && RGB.g <= 0.5f && RGB.b <= 0f)
        {
            RGB.g = SetColorValue(RGB.g, "+");
        }
        else if (RGB.r >= 0f && RGB.g >= 0.5f && RGB.b <= 0f)
        {
            RGB.r = SetColorValue(RGB.r, "-");
        }

        //Debug.Log(RGB.r.ToString() + " , " + RGB.g.ToString() + " , " + RGB.b.ToString());
        RenderSettings.ambientLight = RGB;
    }
}
