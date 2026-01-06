using UnityEngine;

public class VectorSubtractionVisualiser : VectorOperationVisualiserBase
{
    [Header("Subtraction Settings")]
    public bool showNegativeBOnA;

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b) => a - b;

    protected override string GetOperationName() => "A - B";


    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {

        if (showNegativeBOnA)
        {
            Gizmos.color = vectorB.displayColour;
            Gizmos.DrawLine(a, a - b);
            Gizmos.DrawSphere(a - b, resultSphereRadius * 0.5f);
        }
    }

}