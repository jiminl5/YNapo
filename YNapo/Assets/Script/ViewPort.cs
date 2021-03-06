﻿using UnityEngine;
using System.Collections;

public class ViewPort : MonoBehaviour
{

    public Camera cam;
    public float aspect;
    public static bool default_ratio;
    // Use this for initialization
    void Awake()
    {
        default_ratio = false;
        aspect = cam.aspect;

        //1.5 - 16:10, 1.7 - 16:9
        if (aspect >= 1.5 && aspect < 1.7)
        {
            default_ratio = true;
        }

        PlayerPrefs.SetInt("EngageMode", 0); // 0 is false, 1 is true
    }


    // Use this for initialization
    void Start()
    {
        if (default_ratio)
        {
            float targetaspect = 16.0f / 9.0f;

            // determine the game window's current aspect ratio
            float windowaspect = (float)Screen.width / (float)Screen.height;

            // current viewport height should be scaled by this amount
            float scaleheight = windowaspect / targetaspect;

            // obtain camera component so we can modify its viewport
            Camera camera = GetComponent<Camera>();

            // if scaled height is less than current height, add letterbox
            if (scaleheight < 1.0f)
            {
                Rect rect = camera.rect;

                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f - scaleheight) / 2.0f;

                camera.rect = rect;
            }
            else // add pillarbox
            {
                float scalewidth = 1.0f / scaleheight;

                Rect rect = camera.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

                camera.rect = rect;
            }
        }
    }
}