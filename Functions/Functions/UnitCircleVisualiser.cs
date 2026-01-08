using UnityEditor;
using UnityEngine;

public class UnitCircleVisualiser : VisualiserBase
{
    [Header("Connected Graph")]
    public FunctionVisualiserBase connectedGraph;

    [Header("Settings")]
    public float radius = 2f;
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

        // Sync amplitude to circle radius only if it's a Sine wave
        if (connectedGraph is SineWaveVisualiser)
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

        // Draw connector line to sine graph
        if (showConnectorLine && connectedGraph is SineWaveVisualiser)
        {
            Vector3 graphPoint =
                connectedGraph.transform.position + new Vector3(0f, sinVal * radius, 0f);

            Handles.color = new Color(1f, 0f, 0f, 0.5f);
            Handles.DrawDottedLine(tip, graphPoint, 4f);

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(graphPoint, 0.05f);
        }
#endif
    }
}