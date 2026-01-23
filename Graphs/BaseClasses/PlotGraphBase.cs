using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlotGraphBase : VisualiserBase
{
    [Header("Point Array")]
    public Vector3[] pointArray;

    [Header("Graph Settings")]
    public bool drawPoints = true;
    public bool drawLines = true;
    public float pointSphereRadius = 0.1f;
    public Color displayColour = Color.red;

    protected override void Draw()
    {
        if (pointArray != null) // If point array populated
        {
            for (int i = 0; i < pointArray.Length; i++) // Plot graph
            {
                Gizmos.color = displayColour;
                if (drawPoints)
                {
                    Gizmos.DrawSphere(pointArray[i], pointSphereRadius);
                }

                if (drawLines && i != 0)
                {
                        Gizmos.DrawLine(pointArray[i - 1], pointArray[i]);
                }
            }
        }

    }


}
