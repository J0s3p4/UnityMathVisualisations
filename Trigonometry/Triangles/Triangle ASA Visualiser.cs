using UnityEngine;

public class TriangleASAVisualiser : TriangleVisualiserBase
{
    [Header("ASA Settings")]
    public float sideC;              // p1 -> p2
    [Range(0, 179)] public float angleAB; // at p1
    [Range(0, 179)] public float angleAC; // at p2

    protected override void CalculateVertices()
    {
        // Validate angles
        if (angleAB + angleAC >= 180f)
        {
            p1 = p2 = p3 = Vector3.zero;
            return;
        }

        // Convert to radians
        float radA = angleAB * Mathf.Deg2Rad;
        float radB = angleAC * Mathf.Deg2Rad;
        float radC = Mathf.PI - radA - radB;

        // Law of Sines
        float sideA = sideC * Mathf.Sin(radA) / Mathf.Sin(radC);
        float sideB = sideC * Mathf.Sin(radB) / Mathf.Sin(radC);

        // Place base
        p1 = Vector3.zero;
        p2 = new Vector3(sideC, 0f, 0f);

        // Polar to Cartesian conversion to find p3
        p3 = new Vector3(
            Mathf.Cos(radA) * sideB,
            Mathf.Sin(radA) * sideB,
            0f
        );
    }
}