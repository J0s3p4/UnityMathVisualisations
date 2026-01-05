using UnityEngine;

public class VectorVisualiser : VisualiserBase
{
    public Vector3 vector = new Vector3(2, 1, 0);

    [Header("Options")]
    public bool normalised;
    public bool multiplyByT;
    public Color displayColour = Color.red;


    protected override void Draw()
    {
        Vector3 displayVector = vector; // v -> f(v)

        if (normalised)
        {
            displayVector = displayVector.normalized;
        }
        if (multiplyByT)
        {
            displayVector *= t;
        }

        Gizmos.color = displayColour;
        Gizmos.DrawLine(Vector3.zero, displayVector);
        Gizmos.DrawSphere(displayVector, 0.1f);
    }
}