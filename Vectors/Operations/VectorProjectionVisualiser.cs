using UnityEngine;
using static VectorProjectionVisualiser;

public class VectorProjectionVisualiser : VectorOperationVisualiserBase
{


  
    public enum ProjectionMode
    {
        drawProjectedAOnB,
        drawProjectedBOnA
    }
    
    [Header("Projection Settings")]
    public ProjectionMode vectorToProject;

    // Draw Projected vectors for rule A.B = |A||projB(onA)| = |B||projA(onB)|

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {

        switch (vectorToProject)
        {
            case ProjectionMode.drawProjectedAOnB:
                return Vector3.Project(a, b);

            case ProjectionMode.drawProjectedBOnA:
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
