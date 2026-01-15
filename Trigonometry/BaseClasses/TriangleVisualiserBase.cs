using UnityEditor;
using UnityEngine;

public abstract class TriangleVisualiserBase : VisualiserBase
{

    [Header("Triangle Settings")]
    public bool drawAngles = true;
    public bool drawCDotted;
    public bool drawBDotted;
    public Color triangleColor = Color.yellow;
    public Color angleColor = Color.white;

    protected Vector3 p1, p2, p3;


    protected override void Draw()
    {
        CalculateVertices();

        //Draw Lines
        Gizmos.color = triangleColor;

        //A p1 -> p2
        Gizmos.DrawLine(p1, p2); 

        //B p3 -> p1
        if (drawBDotted)
        {
#if UNITY_EDITOR
            UnityEditor.Handles.color = triangleColor;
            UnityEditor.Handles.DrawDottedLine(p3, p1, 5f);
#endif
        }
        else
        {
            Gizmos.DrawLine(p3, p1); 
        }

        //C p2 -> p3
        if (drawCDotted)
        {
#if UNITY_EDITOR
            UnityEditor.Handles.color = triangleColor;
            UnityEditor.Handles.DrawDottedLine(p2, p3, 5f);
#endif
        }
        else
        {
            Gizmos.DrawLine(p2, p3); 
        }

        # if UNITY_EDITOR
        // Label Lines
        Vector3 midpointA = (p1 + p2) * 0.5f;
        Vector3 midpointB = (p3 + p1) * 0.5f;
        Vector3 midpointC = (p2 + p3) * 0.5f;
        Handles.Label(
            midpointA,
            $"A {Vector3.Distance(p1,p2):F2}"
        );
        Handles.Label(
           midpointB,
           $"B {Vector3.Distance(p3, p1):F2}"
        );
        Handles.Label(
            midpointC,
           $"C {Vector3.Distance(p2, p3):F2}"
        );
#endif


        // Draw Angles
        if (drawAngles)
        {
#if UNITY_EDITOR

            float radius = Vector3.Distance(p1, p2) * 0.1f;

            // Angle at p1 (AB)
            DrawAngleArc(
                p1,
                p2,
                p3,
                radius,
                angleColor,
                $"{Vector3.Angle(p2 - p1, p3 - p1):F1}°"
            );

            // Angle at p2 (AC)
            DrawAngleArc(
                p2,
                p1,
                p3,
                radius,
                angleColor,
                $"{Vector3.Angle(p1 - p2, p3 - p2):F1}°"
            );

            // Angle at p3 (BC)
            DrawAngleArc(
                p3,
                p1,
                p2,
                radius,
                angleColor,
                $"{Vector3.Angle(p1 - p3, p2 - p3):F1}°"
            );
#endif
        }

    }


    // Helper function for drawing angles
#if UNITY_EDITOR
    protected void DrawAngleArc(
        Vector3 center,
        Vector3 from,
        Vector3 to,
        float radius,
        Color color,
        string label = null
    )
    {
        Vector3 dirA = (from - center).normalized;
        Vector3 dirB = (to - center).normalized;

        float angle = Vector3.Angle(dirA, dirB);

        Vector3 normal = Vector3.Cross(dirA, dirB).normalized;

        Handles.color = color;
        Handles.DrawWireArc(
            center,
            normal,
            dirA,
            angle,
            radius
        );

        if (!string.IsNullOrEmpty(label))
        {
            Vector3 labelPos =
                center +
                Quaternion.AngleAxis(angle * 0.5f, normal) * dirA * (radius * 1.1f);

            Handles.Label(labelPos, label);
        }
    }
#endif


    // Each solver will calculate vertices
    protected abstract void CalculateVertices();

}
