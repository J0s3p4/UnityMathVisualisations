using UnityEngine;

public class VectorAdditionVisualiser : VectorOperationVisualiserBase
{
    [Header("Addition Settings")]
    public bool showHeadToTailAOnB;
    public bool showHeadToTailBOnA;

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b) => a + b;

    protected override string GetOperationName() => "A + B";

    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {
        // Unique "Head to Tail" visuals for addition
        if (showHeadToTailAOnB)
        {
            Gizmos.color = vectorA.displayColour;
            Gizmos.DrawLine(b, b + a);
            Gizmos.DrawSphere(b + a, resultSphereRadius * 0.5f);
        }

        if (showHeadToTailBOnA)
        {
            Gizmos.color = vectorB.displayColour;
            Gizmos.DrawLine(a, a + b);
            Gizmos.DrawSphere(a + b, resultSphereRadius * 0.5f);
        }
    }
}