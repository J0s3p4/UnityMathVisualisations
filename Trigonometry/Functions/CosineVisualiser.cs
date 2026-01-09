using UnityEngine;

public class CosineVisualiser : FunctionVisualiserBase
{
    protected override float CalculateY(float x) =>
        amplitude * Mathf.Cos(frequency * x + (t * Mathf.PI * 2));
}
