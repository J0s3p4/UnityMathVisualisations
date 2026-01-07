using UnityEditor;
using UnityEngine;

public class VectorDotProductVisualiser : VectorOperationVisualiserBase
{
    private float dot;


    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {

        // Calculate dot product
        dot = Vector3.Dot(a, b);
        
        // Tell the base not to draw the label, axis lines or result sphere
        showValue = false;
        showMagnitude = false;
        showAxisLines = false;
        resultSphereRadius = 0;



        // Return zero, no vector
        return Vector3.zero;

    }

    protected override string GetOperationName() => "A . B";

    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {
    #if UNITY_EDITOR
        // Draw dot product between tips of vectorA & vectorB
        Vector3 midpoint = (a + b) * 0.5f;
        Handles.Label(
            midpoint,
            $"A · B = {dot:F2}"
        );
    #endif
    }
}