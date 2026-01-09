using UnityEngine;

public class TriangleSSSVisualiser : TriangleVisualiserBase
{
    [Header("Side Lengths")]
    public float sideA; // p1 > p2 side A
    public float sideB; // p2 > p3 side B
    public float sideC; // p3 > p1 side C

    protected override void CalculateVertices()
    {
        // One side should not be longer than the other two combined
        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
        {
            // if it is just draw points at zero
            p1 = Vector3.zero;
            p2 = Vector3.zero;
            p3 = Vector3.zero;
            return;
        }

        p1 = Vector3.zero; // p1 at origin
        p2 = new Vector3(sideA, 0, 0); 

        //  Use Law of Cosines to find Angle alpha at p1
        float cosAlpha = (sideB * sideB + sideC * sideC - sideA * sideA) / (2 * sideB * sideC);

        // Get the angle in Radians (Clamp between -1 and 1)
        float alphaRadians = Mathf.Acos(Mathf.Clamp(cosAlpha, -1f, 1f));

        // Polar to Cartesian conversion to find p3
        p3 = new Vector3(
            Mathf.Cos(alphaRadians) * sideB,
            Mathf.Sin(alphaRadians) * sideB,
            0
        );
    }
}