using UnityEngine;

public class SceneAxis : MonoBehaviour
{
    [Header("Axis Settings")]
    public float axisLength = 5f;      // Length in each direction
    public bool extendNegative = true; // Extend axes in negative directions
    public bool showAxes = true;       // Toggle axes on/off

    private void OnDrawGizmos()
    {
        if (!showAxes) return;

        // Draw each axis
        DrawAxis(Vector3.right, axisLength);
        DrawAxis(Vector3.up, axisLength);
        DrawAxis(Vector3.forward, axisLength);
    }

    private void DrawAxis(Vector3 direction, float length)
    {
        Gizmos.color = Color.white;

        // Positive direction
        Gizmos.DrawLine(Vector3.zero, direction * length);

        // Negative direction (if enabled)
        if (extendNegative)
            Gizmos.DrawLine(Vector3.zero, -direction * length);

    }
}