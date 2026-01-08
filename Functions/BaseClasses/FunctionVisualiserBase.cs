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

    protected override void Draw()
    {

      #if UNITY_EDITOR
            Vector3[] points = new Vector3[resolution];
            float step = (range * 2) / (resolution - 1);

            for (int i = 0; i < resolution; i++)
            {
                float x = -range + (i * step);

                // Child class calculates y
                float y = CalculateY(x);

                points[i] = transform.position + new Vector3(x, y, 0);
            }

            Handles.color = graphColour;
            Handles.DrawPolyLine(points);
       #endif
    }

    // Child class calculates y
    protected abstract float CalculateY(float x);
}