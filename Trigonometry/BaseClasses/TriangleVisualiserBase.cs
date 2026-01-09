using UnityEditor;
using UnityEngine;

public abstract class TriangleVisualiserBase : VisualiserBase
{

    [Header("Triangle Settings")]
    public Color triangleColor = Color.yellow;

    protected Vector3 p1, p2, p3;
    

    protected override void Draw()
    {
        CalculateVertices();

        //Draw Lines
        Gizmos.color = triangleColor;
        Gizmos.DrawLine(p1, p2); //A p1 > p2
        Gizmos.DrawLine(p3, p1); //B p3 > p1
        Gizmos.DrawLine(p2, p3); //C p2 > p3

        # if UNITY_EDITOR
        // Label Lines
        Vector3 midpointA = (p1 + p2) * 0.5f;
        Vector3 midpointB = (p3 + p1) * 0.5f;
        Vector3 midpointC = (p2 + p3) * 0.5f;
        Handles.Label(
            midpointA,
            $"A"
        );
        Handles.Label(
           midpointB,
           $"B"
        );
        Handles.Label(
            midpointC,
           $"C"
        );
        #endif


        //Draw Angles

    }

    // Each solver will calculate vertices
    protected abstract void CalculateVertices();

}
