using UnityEngine;
using UnityEditor;

public class PlotGraphBase : VisualiserBase
{

    public Vector3[] pointArray;

    public float pointSphereRadius = 0.1f;
    public Color displayColour = Color.red;


    protected override void Draw()
    {
        if (pointArray != null) // If point array populated
        {
            for (int i = 0; i < pointArray.Length; i++) // Plot graph
            {
                Gizmos.color = displayColour;
                Gizmos.DrawSphere(pointArray[i], pointSphereRadius);
            }
        }

    }


}
