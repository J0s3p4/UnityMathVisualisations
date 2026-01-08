using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static VectorProjectionVisualiser;

public class VectorProjectionVisualiser : VectorOperationVisualiserBase
{

    // Draw Projected vectors, useful for the rule: A.B = |A||projB(onA)| = |B||projA(onB)|
    // Inspired by: https://youtu.be/LyGKycYT2v0?t=87

    public enum ProjectionMode
    {
        drawProjectedAOnB,
        drawProjectedBOnA
    }
    
    [Header("Projection Settings")]
    public ProjectionMode vectorToProject;
    public bool drawLineToProjection;
    
    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {

        switch (vectorToProject)
        {
            case ProjectionMode.drawProjectedAOnB:
                operationColor = MakeTransparent(vectorA.displayColour, 0.3f);
                return Vector3.Project(a, b);

            case ProjectionMode.drawProjectedBOnA:
                operationColor = MakeTransparent(vectorB.displayColour, 0.3f);
                return Vector3.Project(b, a);
        }


        return Vector3.zero;
    }

    // Could be used elsewhere
    Color MakeTransparent(Color c, float alpha)
    {
        return new Color(c.r, c.g, c.b, alpha);
    }

    protected override string GetOperationName()
    {
        return vectorToProject == ProjectionMode.drawProjectedAOnB
            ? "proj|A| on B"
            : "proj|B| on A";
    }

    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {
#if UNITY_EDITOR
        // Draw line between vector being projected and its projection
        if(drawLineToProjection) {
            if (vectorToProject == ProjectionMode.drawProjectedBOnA)
            {
            UnityEditor.Handles.color = operationColor;
            UnityEditor.Handles.DrawDottedLine(b, result, 5f);
            }

            if (vectorToProject == ProjectionMode.drawProjectedAOnB)
            {
            UnityEditor.Handles.color = operationColor;
            UnityEditor.Handles.DrawDottedLine(a, result, 5f);
        }
        }
#endif
    }
}
