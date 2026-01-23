using UnityEngine;

public class PlotGraphBase : VisualiserBase
{

    public Vector3[] pointArray;

    public float pointSphereRadius = 0.1f;

    protected override void Draw()
    {
        if (pointArray != null) // No values return
        {
            return;
        }

        for (int i = 0; i < pointArray.Length; i++) // Plot graph
        {
            Gizmos.DrawSphere(pointArray[i], pointSphereRadius);
        }

    }

}
