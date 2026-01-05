using UnityEngine;

public class VectorVisualiser : VisualiserBase
{
    public Vector3 vector = new Vector3(2, 1, 0);

    protected override void Draw()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, vector);
        Gizmos.DrawSphere(vector, 0.1f);
    }
}