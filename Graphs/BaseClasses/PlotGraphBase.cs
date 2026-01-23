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

    private Vector3 previousPoint;

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

                if (drawLines)
                {
                    if (i == 0)
                    {
                        previousPoint = pointArray[i]; // Previous point not set for i==0, set current as previous

                    }
                    else
                    {
                        // Draw line from previous to current and then set current as previous
                        Gizmos.DrawLine(previousPoint, pointArray[i]);
                        previousPoint = pointArray[i];
                    }
                }
            }
        }

    }


}
