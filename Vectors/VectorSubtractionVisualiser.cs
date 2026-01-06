using UnityEngine;

public class VectorSubtractionVisualiser : VectorOperationVisualiserBase
{

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b) => a - b;

    protected override string GetOperationName() => "A - B";


}