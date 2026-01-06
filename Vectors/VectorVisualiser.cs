using UnityEngine;

public class VectorVisualiser : VectorVisualiserBase
{
    public Vector3 vector = new Vector3(2, 1, 0);

    // Adds variables under "settings header in base"
    public bool normalised;
    public bool multiplyByT;
    public bool isVectorA;
    public Color displayColour = Color.red;

    protected override void Draw()
    {
        Vector3 displayVector = Value;

        string label = isVectorA ? "Vector A" : "Vector B";

        // Draws vector using visualiser base
        DrawVector(Vector3.zero, displayVector, displayColour, label);
    }

    public Vector3 Value
    {
        get
        {
            Vector3 v = vector;
            if (normalised) v = v.normalized;
            if (multiplyByT) v *= t;
            return v;
        }
    }
}