using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRendering : MonoBehaviour
{
    public bool wireframeToggle = false;
    void OnPreRender()
    {
        GL.wireframe = wireframeToggle;
    }
    void OnPostRender()
    {
        GL.wireframe = false;
    }
}
