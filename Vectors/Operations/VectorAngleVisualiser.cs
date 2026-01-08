using UnityEngine;
using UnityEditor;

public class VectorAngleVisualiser : VectorOperationVisualiserBase
{
    [Header("Angle Settings")]
    public Color angleColor = new Color(1, 1, 0, 0.2f); // Transparent Yellow
    public float arcRadiusScale = 0.5f;
    public bool showAngleLabel = true;

    private float angle;

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {
        // Angle in degrees
        angle = Vector3.Angle(a, b);

        // Scalar result, no vector
        showMagnitude = false;
        showValue = false;
        showAxisLines = false;
        resultSphereRadius = 0f;

        return Vector3.zero;
    }

    protected override string GetOperationName() => "Angle";

    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {
#if UNITY_EDITOR
        // Guard against degenerate vectors (near 0 length)
        if (a.sqrMagnitude < 0.0001f || b.sqrMagnitude < 0.0001f)
            return;

        Vector3 aDir = a.normalized;
        Vector3 bDir = b.normalized;

        Vector3 normal = Vector3.Cross(aDir, bDir);

        normal.Normalize();

        float radius = Mathf.Min(a.magnitude, b.magnitude) * arcRadiusScale;

        Handles.color = angleColor;

        // Draw arc from A toward B
        Handles.DrawWireArc(
            Vector3.zero,
            normal,
            aDir,
            angle,
            radius
        );

        if (showAngleLabel)
        {
            Vector3 midDir = Quaternion.AngleAxis(angle * 0.5f, normal) * aDir;
            Vector3 labelPos = midDir * radius;

            Handles.Label(labelPos, $"{angle:F1}°");
        }
#endif
    }
}