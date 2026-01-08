using UnityEditor;
using UnityEngine;

public class SceneAxis : MonoBehaviour
{
    [Header("Axis Settings")]
    public float axisLength = 5f;      // Length in each direction
    public bool extendNegative = true; // Extend axes in negative directions
    public bool showAxes = true;       // Toggle axes on/off
    public bool showAxesLabels = true;
    public Color axisColor = Color.white;

    private void OnDrawGizmos()
    {
        if (!showAxes) return;

        // Draw each axis
        DrawAxis(Vector3.right, axisLength, "x");
        DrawAxis(Vector3.up, axisLength, "y");
        DrawAxis(Vector3.forward, axisLength, "z");
    }

    private void DrawAxis(Vector3 direction, float length, string axisLabel)
    {
        Color faint = axisColor;
        faint.a = 0.2f;
        Gizmos.color = faint;


        // Positive direction
        Gizmos.DrawLine(Vector3.zero, direction * length);
        
        if (showAxesLabels)
        {
        #if UNITY_EDITOR

            Handles.Label(
            direction * (length + 1),
            $"{axisLabel}"
        );
        #endif
        }

        // Negative direction (if enabled)
        if (extendNegative)
        {
            Gizmos.DrawLine(Vector3.zero, -direction * length);
            if (showAxesLabels)
            {
            #if UNITY_EDITOR

                Handles.Label(
                -direction * (length + 1),
                $"-{axisLabel}"
            );
            #endif
            }
        }

    }
}