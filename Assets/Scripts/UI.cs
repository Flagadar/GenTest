using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public int frameRate;
    void Update()
    {
        float current = 0f;
        current = (int)(1f / Time.unscaledDeltaTime);
        frameRate = (int)current;
    }
    void OnGUI() 
    {
    GUI.Label(new Rect(10, 10, 100, 20), frameRate.ToString() + " FPS");
    }
}
