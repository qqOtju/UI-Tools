using System;
using UnityEngine;
 
public class ShowFPS : MonoBehaviour {
 
    public static float fps;

    private void Awake()
    {
        Application.targetFrameRate = 120;
    }

    void OnGUI()
    {
        fps = 1.0f / Time.deltaTime;
        GUI.skin.label.fontSize = 40;
        GUILayout.Label("FPS: " + (int)fps);
    }
}