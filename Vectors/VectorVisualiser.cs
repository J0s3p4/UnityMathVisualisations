using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class VectorVisualiser : VisualiserBase
{
    public Vector3 vector = new Vector3(2, 1, 0);

    [Header("Options")]
    public bool showValue;
    public bool normalised;
    public bool multiplyByT;
    public bool showAxisLines;
    public Color displayColour = Color.red;
    public float resultSphereRadius = 0.1f;

    protected override void Draw()
    {
        Vector3 displayVector = vector; // v -> f(v)

        if (normalised)
        {
            displayVector = displayVector.normalized;
        }
        if (multiplyByT)
        {
            displayVector *= t;
        }

        // Draw the main vector
        Gizmos.color = displayColour;
        Gizmos.DrawLine(Vector3.zero, displayVector);
        Gizmos.DrawSphere(displayVector, resultSphereRadius);

        if (showValue)
        {
        #if UNITY_EDITOR
            DrawVectorLabel(displayVector, displayVector);
        #endif
        }

        // Draw faint axis lines if enabled
        if (showAxisLines)
        {
            // Faint version of the display colour
            Color faint = displayColour;
            faint.a = 0.2f; // Opacity
            Gizmos.color = faint;

            // X component line 
            Gizmos.DrawLine(new Vector3(displayVector.x, 0f, 0f), displayVector);

            // Y component line 
            Gizmos.DrawLine(new Vector3(0f, displayVector.y, 0f), displayVector);

            // Z component line 
            Gizmos.DrawLine(new Vector3(0f, 0f, displayVector.z), displayVector);
        }
    }

    // Draws Vector Value (Editor only)
#if UNITY_EDITOR
    private void DrawVectorLabel(Vector3 position, Vector3 value)
    {
        Vector3 labelOffset = Vector3.up * 0.2f;

        string label =
            $"[ {value.x:F2}\n" +
            $"  {value.y:F2}\n" +
            $"  {value.z:F2} ]";

        Handles.Label(position + labelOffset, label);
    }
#endif

    // Returns value of vector
    public Vector3 Value
    {
        get
        {
            Vector3 v = vector;

            if (normalised)
                v = v.normalized;

            if (multiplyByT)
                v *= t;

            return v;
        }
    }

}