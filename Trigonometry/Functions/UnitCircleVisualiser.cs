using UnityEditor;
using UnityEngine;

public class UnitCircleVisualiser : VisualiserBase
{
    [Header("Connected Graph")]
    public FunctionVisualiserBase connectedGraph;

    [Header("Settings")]
    public float radius = 1f;
    public Color circleColor = new Color(1, 1, 1, 0.2f);
    public Color vectorColor = Color.yellow;
    public bool showConnectorLine = true;

    private void OnValidate()
    {
        SyncGraph();
    }

    private void SyncGraph()
    {
        if (connectedGraph == null)
            return;

        // Sync time
        connectedGraph.t = t;

        // Sync amplitude to circle radius
        if (connectedGraph is FunctionVisualiserBase)
        {
            connectedGraph.amplitude = radius;
        }
    }

    protected override void Draw()
    {
#if UNITY_EDITOR
        SyncGraph();

        Vector3 center = transform.position;

        // Draw the circle
        Handles.color = circleColor;
        Handles.DrawWireDisc(center, Vector3.forward, radius);

        // Calculate current state
        float angle = t * Mathf.PI * 2f;
        float cosVal = Mathf.Cos(angle);
        float sinVal = Mathf.Sin(angle);

        Vector3 tip = center + new Vector3(cosVal * radius, sinVal * radius, 0f);

        // Draw main rotating vector
        Handles.color = vectorColor;
        Handles.DrawLine(center, tip);
        Gizmos.color = vectorColor;
        Gizmos.DrawSphere(tip, 0.05f);

        if (showConnectorLine && connectedGraph != null)
        {
            float value;

            if (connectedGraph is SineWaveVisualiser)
                value = sinVal;
            else if (connectedGraph is CosineVisualiser)
                value = cosVal;
            else
                return;

            Quaternion graphRotation =
                Quaternion.Euler(0, 0, connectedGraph.zRotation);

            Vector3 localProjection = new Vector3(0f, value * radius, 0f);
            Vector3 rotatedProjection = graphRotation * localProjection;

            Vector3 graphPoint =
                connectedGraph.transform.position + rotatedProjection;

            Handles.color = Color.green;
            Handles.DrawDottedLine(tip, graphPoint, 4f);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(graphPoint, 0.05f);
        }
#endif
    }
}