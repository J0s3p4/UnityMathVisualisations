using UnityEngine;

public class VectorAdditionVisualiser : VisualiserBase
{
    [Header("Input Vectors")]
    public VectorVisualiser vectorA;
    public VectorVisualiser vectorB;

    [Header("Options")]
    public bool showAxisLines;
    public Color displayColour = Color.green;
    public float resultSphereRadius = 0.1f;

    protected override void Draw()
    {
        if (vectorA == null || vectorB == null)
            return;

        Vector3 a = vectorA.Value;
        Vector3 b = vectorB.Value;

        Vector3 sum = a + b;

        //Draw Vector
        Gizmos.color = displayColour;
        Gizmos.DrawLine(Vector3.zero, sum);
        Gizmos.DrawSphere(sum, resultSphereRadius);

        // Draw faint axis lines if enabled
        if (showAxisLines)
        {
            // Faint version of the display colour
            Color faint = displayColour;
            faint.a = 0.2f; // Opacity
            Gizmos.color = faint;

            // X component line 
            Gizmos.DrawLine(new Vector3(sum.x, 0f, 0f), sum);

            // Y component line 
            Gizmos.DrawLine(new Vector3(0f, sum.y, 0f), sum);

            // Z component line 
            Gizmos.DrawLine(new Vector3(0f, 0f, sum.z), sum);
        }
    }
}