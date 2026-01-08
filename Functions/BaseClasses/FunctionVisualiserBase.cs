using UnityEditor;
using UnityEngine;

public abstract class FunctionVisualiserBase : VisualiserBase
{
    [Header("Graph Settings")]
    public float range = 10f;
    public int resolution = 100;
    public Color graphColour = Color.blue;
    public float amplitude = 1f;
    public float frequency = 1f;
    [Range(0, 360)]
    public float zRotation = 0f;

    protected override void Draw()
    {

      #if UNITY_EDITOR
            Vector3[] points = new Vector3[resolution];
            float step = (range * 2) / (resolution - 1);

        // Create a rotation offset based on our variable
        Quaternion rotation = Quaternion.Euler(0, 0, zRotation);

        for (int i = 0; i < resolution; i++)
        {
            float x = -range + (i * step);
            float y = CalculateY(x);

            // Calculate the raw local point
            Vector3 localPoint = new Vector3(x, y, 0);

            // Rotate that point before adding it to the world position
            Vector3 rotatedPoint = rotation * localPoint;

            points[i] = transform.position + rotatedPoint;
        }

        Handles.color = graphColour;
            Handles.DrawPolyLine(points);
       #endif
    }

    // Child class calculates y
    protected abstract float CalculateY(float x);
}