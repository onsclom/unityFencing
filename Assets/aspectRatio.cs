using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspectRatio : MonoBehaviour
{
    private int lastWidth;
    private int lastHeight;
    // Start is called before the first frame update
    void Start () {
        lastWidth = 0;
        lastHeight = 0;
    }

    void Update ()
    {
        int width = Screen.width;
        int height = Screen.height;

        if (width != lastWidth)
        {
            Screen.SetResolution(width, Mathf.FloorToInt((float)width * (float)(9.0f/16.0f)), false, 0);
            lastWidth = width;

            //Screen.height = Mathf.FloorToInt((float)width * (float)(9.0f/16.0f));
        }

/*
        if(lastWidth != width) // if the user is changing the width
        {
            // update the height
            var heightAccordingToWidth = (width / 16.0f * 9.0f);
            Screen.SetResolution((int)Math.Floor(width), (int)Mathf.Round(heightAccordingToWidth), false, (int)0);
        }
        else if(lastHeight != height) // if the user is changing the height
        {
            // update the width
            var widthAccordingToHeight = (int)(height / 9.0 * 16.0);
            Screen.SetResolution(Mathf.Round(widthAccordingToHeight), height, false, 0);
        }

        lastWidth = width;
        lastHeight = height;
    */
    }


}

