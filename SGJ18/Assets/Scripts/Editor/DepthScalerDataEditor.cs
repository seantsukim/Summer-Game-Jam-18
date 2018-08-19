using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DepthScalerData))]
public class DepthScalerDataEditor : Editor
{
    DepthScalerData depthScalerData;
    Vector3 line1Point1, line1Point2, line1Midpoint,
            line2Point1, line2Point2, line2Midpoint;

    void OnEnable()
    {
        depthScalerData = target as DepthScalerData;

        float frontPlaneWorldHeight = Camera.main.ScreenToWorldPoint(new Vector3(0f, depthScalerData.frontPlanePixelHeight, 0f)).y;
        float backPlaneWorldHeight = Camera.main.ScreenToWorldPoint(new Vector3(0f, depthScalerData.backPlanePixelHeight, 0f)).y;
        float worldLeft = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        float worldRight = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0f, 0f)).x;

        line1Point1.x = worldLeft;
        line1Point1.y = frontPlaneWorldHeight;
        line1Point1.z = 0f;
        line1Point2.x = worldRight;
        line1Point2.y = frontPlaneWorldHeight;
        line1Point2.z = 0f;
        line1Midpoint.x = (line1Point1.x + line1Point2.x) / 2f;
        line1Midpoint.y = frontPlaneWorldHeight;
        line1Midpoint.z = 0f;
        line2Point1.x = worldLeft;
        line2Point1.y = backPlaneWorldHeight;
        line2Point1.z = 0f;
        line2Point2.x = worldRight;
        line2Point2.y = backPlaneWorldHeight;
        line2Point2.z = 0f;
        line2Midpoint.x = (line2Point1.x + line2Point2.x) / 2f;
        line2Midpoint.y = backPlaneWorldHeight;
        line2Midpoint.z = 0f;

        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    void OnDisable()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    void OnSceneGUI(SceneView sceneView)
    {
        Color originalColor = Handles.color;
        Handles.color = Color.red;

        Handles.DrawLine(line1Point1, line1Point2);
        EditorGUI.BeginChangeCheck();
        line1Midpoint = Handles.Slider(line1Midpoint, Vector3.up);
        if (EditorGUI.EndChangeCheck())
        {
            line1Point1.y = line1Midpoint.y;
            line1Point2.y = line1Midpoint.y;

            Undo.RecordObject(depthScalerData, "Move front plane pixel height");
            depthScalerData.frontPlanePixelHeight = Camera.main.WorldToScreenPoint(line1Midpoint).y;
        }

        Handles.DrawLine(line2Point1, line2Point2);
        EditorGUI.BeginChangeCheck();
        line2Midpoint = Handles.Slider(line2Midpoint, Vector3.up);
        if (EditorGUI.EndChangeCheck())
        {
            line2Point1.y = line2Midpoint.y;
            line2Point2.y = line2Midpoint.y;

            Undo.RecordObject(depthScalerData, "Move back plane pixel height");
            depthScalerData.backPlanePixelHeight = Camera.main.WorldToScreenPoint(line2Midpoint).y;
        }

        Handles.color = originalColor;
    }
}
