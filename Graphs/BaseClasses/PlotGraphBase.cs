using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlotGraphBase : VisualiserBase
{

    public Vector3[] pointArray;

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
                Gizmos.DrawSphere(pointArray[i], pointSphereRadius);

                if (i == 0)
                {
                    previousPoint = pointArray[i]; // Previous point not set, set current as previous

                }
                else
                {
                    //draw line from previous to current and then set current as previous
                    Gizmos.DrawLine(previousPoint, pointArray[i]);
                    previousPoint = pointArray[i];
                }

            }
        }

    }


}
