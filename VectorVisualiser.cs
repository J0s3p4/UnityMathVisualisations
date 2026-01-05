using UnityEngine;

public class VectorVisualiser : VisualiserBase
{
    public Vector3 vector = new Vector3(2, 1, 0);

    [Header("Options")]
    public bool normalised;
    public bool multiplyByT;
    public bool showAxisLines;
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

        // Draw the main vector
        Gizmos.color = displayColour;
        Gizmos.DrawLine(Vector3.zero, displayVector);
        Gizmos.DrawSphere(displayVector, 0.1f);


        // Draw faint axis lines if enabled
        if (showAxisLines)
        {
            // Make a faint version of the display colour
            Color faint = displayColour;
            faint.a = 0.2f; // Opacity
            Gizmos.color = faint;

            // X component line 
            Gizmos.DrawLine(new Vector3(displayVector.x, 0f, 0f), displayVector);

            // Y component line 
            Gizmos.DrawLine(new Vector3(0f, displayVector.y, 0f), displayVector);

            // Z component line 
            Gizmos.DrawLine(new Vector3(0f, 0f, displayVector.z), displayVector);
        }
    }


}