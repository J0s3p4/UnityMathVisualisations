using UnityEngine;

public class VectorProjectionVisualiser : VectorOperationVisualiserBase
{


    [Header("Projection Settings")]
    public bool drawProjectedAOnB;
    public bool drawProjectedBOnA;

    // Draw Projected vectors for rule A.B = |A||projB(onA)| = |B||projA(onB)|

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {

        return Vector3.zero;
    }


 }
