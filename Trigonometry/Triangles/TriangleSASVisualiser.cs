using System.Security.Cryptography;
using UnityEngine;

public class TriangleSASVisualiser : TriangleVisualiserBase
{

    public float sideA;
    public float sideB;
    [Range(0, 360)] public float angle;

    // p1>p2 side A, p2>p3 side B, p3>p1 side C

    protected override void CalculateVertices()
    {
        // side A and B meet at origin, this is where the angle is
        p1 = Vector3.zero;

        p2 = new Vector3(sideA, 0, 0); // Draw side A along x-axis

        // v3 is the end of Side B, calculated using the angle

        // ToDo: take radians or degrees
        float rad = angle * Mathf.Deg2Rad; // Convert degrees to radians

        // Polar to Cartesian conversion
        p3 = new Vector3(
            Mathf.Cos(rad) * sideB,
            Mathf.Sin(rad) * sideB,
            0
        );

        return;
    }
}
