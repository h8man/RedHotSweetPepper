using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfect : MonoBehaviour {
    public int refHight;
    public int PPU;
    // Use this for initialization
    void Start() {
        //var camera = GetComponent<Camera>();
        int PPUScale = Math.Max(Screen.height / refHight, 1);
        //camera.orthographicSize = Screen.height / (float)(PPUScale * PPU) * 0.5f;
        var cinema = GetComponent<Camera>();
        if (cinema !=null)
        { 
            cinema.orthographicSize = Screen.height / (float)(PPUScale * PPU) * 0.5f;
        }
    }
}
