using Unity.VisualScripting;
using UnityEngine;

public class VectorSubtractionVisualiser : VectorOperationVisualiserBase
{
    [Header("Subtraction Settings")]
    public bool showSubtractingVectorLine;
    public bool subtractBByA = false;

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b) => subtractBByA ? b - a : a - b;

  
    protected override string GetOperationName() => subtractBByA ? "B - A" : "A - B";


    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {

        if (showSubtractingVectorLine)
        {

            if (subtractBByA)
            {
                Gizmos.color = vectorA.displayColour;
                UnityEditor.Handles.color = vectorA.displayColour;
                UnityEditor.Handles.DrawDottedLine(b, b - a, 5f);
                Gizmos.DrawSphere(b - a, resultSphereRadius * 0.5f);

            }
            else
            {
                Gizmos.color = vectorB.displayColour;
                UnityEditor.Handles.color = vectorB.displayColour;
                UnityEditor.Handles.DrawDottedLine(a, a - b, 5f);
                Gizmos.DrawSphere(a - b, resultSphereRadius * 0.5f);
            }

        }
    }

}