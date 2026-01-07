using Unity.VisualScripting;
using UnityEngine;

public class VectorSubtractionVisualiser : VectorOperationVisualiserBase
{

    public enum SubtractionToCalculate
    {
        ASubtractB,
        BSubtractA
    }

    [Header("Subtraction Settings")]
    public SubtractionToCalculate subtractiontocalulate;
    public bool showSubtractingVectorLine;

    protected override Vector3 PerformOperation(Vector3 a, Vector3 b)
    {
        return subtractiontocalulate == SubtractionToCalculate.ASubtractB
            ? a - b
            : b - a;
    } 

  
    protected override string GetOperationName()
    {
        return subtractiontocalulate == SubtractionToCalculate.ASubtractB
            ? "A - B"
            : "B - A";
    }



    protected override void DrawExtraVisuals(Vector3 a, Vector3 b, Vector3 result)
    {

        if (showSubtractingVectorLine)
        {

            if (subtractiontocalulate == SubtractionToCalculate.ASubtractB)
            {
                Gizmos.color = vectorB.displayColour;
                UnityEditor.Handles.color = vectorB.displayColour;
                UnityEditor.Handles.DrawDottedLine(a, a - b, 5f);
                Gizmos.DrawSphere(a - b, resultSphereRadius * 0.5f);

            }
            if (subtractiontocalulate == SubtractionToCalculate.BSubtractA)
            {
                Gizmos.color = vectorA.displayColour;
                UnityEditor.Handles.color = vectorA.displayColour;
                UnityEditor.Handles.DrawDottedLine(b, b - a, 5f);
                Gizmos.DrawSphere(b - a, resultSphereRadius * 0.5f);
            }

        }
    }

}