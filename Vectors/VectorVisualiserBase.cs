using UnityEngine;
using UnityEditor;

public abstract class VectorVisualiserBase : VisualiserBase
{
    [Header("Visual Settings")]
    public float resultSphereRadius = 0.1f;
    public bool showValue = true;
    public bool showAxisLines = false;

    // A helper method any child can call to draw a vector
    protected void DrawVector(Vector3 start, Vector3 end, Color color, string labelPrefix = "")
    {
        Gizmos.color = color;
        Gizmos.DrawLine(start, end);
        Gizmos.DrawSphere(end, resultSphereRadius);

        if (showValue)
        {
            DrawVectorLabel(end, end - start, labelPrefix);
        }

        if (showAxisLines)
        {
            DrawAxisLines(end, color);
        }
    }

    // Draws lines to the axis
    private void DrawAxisLines(Vector3 pos, Color color)
    {
        Color faint = color;
        faint.a = 0.2f;
        Gizmos.color = faint;
        Gizmos.DrawLine(new Vector3(pos.x, 0, 0), pos);
        Gizmos.DrawLine(new Vector3(0, pos.y, 0), pos);
        Gizmos.DrawLine(new Vector3(0, 0, pos.z), pos);
    }

    // Draws a label on the vector
    private void DrawVectorLabel(Vector3 position, Vector3 value, string prefix)
    {
#if UNITY_EDITOR
        Vector3 labelOffset = Vector3.up * 0.2f;
        string label = $"{prefix}\n[{value.x:F2}, {value.y:F2}, {value.z:F2}]";
        Handles.Label(position + labelOffset, label);
#endif
    }
}