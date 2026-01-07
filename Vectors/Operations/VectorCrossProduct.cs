using UnityEngine;
using UnityEditor;

public class VectorCrossProductVisualiser : VectorOperationVisualiserBase
{
    //ToDo: Display negative cross product values appropriatelt

    // Cross products are non commutative
    public enum CrossProductToCalculate
    {
        AXB,
        BXA
    }

    [Header("Cross Product Settings")]
    public CrossProductToCalculate crossProductToCalculate;
    public bool showArea = true;
    public bool showAreaLabel = true;
    public Color areaColor = new Color(1, 1, 0, 0.2f); // Transparent Yellow

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {

        // The cross product results in a vector perpendicular to both A and B
        return crossProductToCalculate == CrossProductToCalculate.AXB
            ? Vector3.Cross(a, b)
            : Vector3.Cross(b, a); 
    }

    protected override string GetOperationName()
    {
        return crossProductToCalculate == CrossProductToCalculate.AXB
            ? "A x B"
            : "B x A";
    } 

    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {
#if UNITY_EDITOR
        // Draw the Area 
        if (showArea)
        {
            Vector3 corner = a + b;
            Vector3[] verts = new Vector3[] { Vector3.zero, a, corner, b };

            // Create rectangle
            Handles.color = areaColor;
            Handles.DrawSolidRectangleWithOutline(verts, areaColor, new Color(areaColor.r, areaColor.g, areaColor.b, 1f));

            // Draw dotted lines for the far edges of the parallelogram
            Handles.color = Color.white;
            Handles.DrawDottedLine(a, corner, 5f);
            Handles.DrawDottedLine(b, corner, 5f);
        }

        // Draw area value of created shape between tips of vectorA & vectorB
        if (showAreaLabel)
        {
            float area = result.magnitude;
            Vector3 midpoint = (a + b) * 0.5f;
            Handles.Label(midpoint, $"|A x B| (Area) = {area:F2}");
        }
#endif
    }
}