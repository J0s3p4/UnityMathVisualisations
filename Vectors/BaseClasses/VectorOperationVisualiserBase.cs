using UnityEngine;
using UnityEditor;

public abstract class VectorOperationVisualiserBase : VectorVisualiserBase
{
    public VectorVisualiser vectorA;
    public VectorVisualiser vectorB;
    public Color operationColor = Color.green;

    protected override void Draw()
    {
        if (vectorA == null || vectorB == null) return;

        Vector3 a = vectorA.Value;
        Vector3 b = vectorB.Value;

        Vector3 result = PerformOperation(a, b);

        // Draw the result using the base helper
        DrawVector(Vector3.zero, result, operationColor, GetOperationName());

        // Let specific scripts draw "extras" (like the head-to-tail lines used in addition)
        DrawExtraVisuals(a, b, result);
    }

    protected abstract Vector3 PerformOperation(Vector3 a, Vector3 b);
    protected virtual string GetOperationName() => "Result";
    protected virtual void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result) { }
}