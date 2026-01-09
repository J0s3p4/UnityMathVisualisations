using UnityEngine;
using UnityEditor;

public class SineWaveVisualiser : FunctionVisualiserBase
{
    protected override float CalculateY(float x) =>
            amplitude * Mathf.Sin(frequency * x + (t * Mathf.PI * 2));
}