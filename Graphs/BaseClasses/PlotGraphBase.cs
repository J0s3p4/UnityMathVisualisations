using UnityEngine;

public class PlotGraphBase : VisualiserBase
{

    private Vector3[] pointArray;

    public float pointSphereRadius;

    protected override void Draw()
    {
        for (int i = 0; i < pointArray.Length; i++)
        {
            Gizmos.DrawSphere(pointArray[i], pointSphereRadius);
        }

    }

}
