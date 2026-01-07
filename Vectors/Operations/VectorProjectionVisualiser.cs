using UnityEngine;
using static VectorProjectionVisualiser;

public class VectorProjectionVisualiser : VectorOperationVisualiserBase
{


    // Draw Projected vectors, useful for the rule: A.B = |A||projB(onA)| = |B||projA(onB)|

    public enum ProjectionMode
    {
        drawProjectedAOnB,
        drawProjectedBOnA
    }
    
    [Header("Projection Settings")]
    public ProjectionMode vectorToProject;

    
    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {

        switch (vectorToProject)
        {
            case ProjectionMode.drawProjectedAOnB:
                operationColor = vectorA.displayColour;
                return Vector3.Project(a, b);

            case ProjectionMode.drawProjectedBOnA:
                operationColor = vectorB.displayColour;
                return Vector3.Project(b, a);
        }


        return Vector3.zero;
    }

    protected override string GetOperationName()
    {
        return vectorToProject == ProjectionMode.drawProjectedAOnB
            ? "proj|A| on B"
            : "proj|B| on A";
    }

}
