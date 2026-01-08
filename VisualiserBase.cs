using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public abstract class VisualiserBase : MonoBehaviour
{
    [Range(0f, 1f)]
    public float t;

    [Header("Animation Settings")]
    public bool animate = false;
    [Min(0f)] // Prevents speed from being negative 
    public float speed = 0.1f;
    public bool reverse = false;
    public bool pauseOnEnd = false;

    protected virtual void Update()
    {
        if (animate)
        {
            // Determine direction: 1 for forward, -1 for reverse
            float direction = reverse ? -1f : 1f;

            // Increment/Decrement t
            t += Time.deltaTime * speed * direction;

            // Handle Boundaries
            if (reverse)
            {
                if (t <= 0f)
                {
                    if (pauseOnEnd)
                    {
                        t = 0f;
                        animate = false;
                    }
                    else
                    {
                        t = 1f; // Loop back to the end
                    }
                }
            }
            else // Forward
            {
                if (t >= 1f)
                {
                    if (pauseOnEnd)
                    {
                        t = 1f;
                        animate = false;
                    }
                    else
                    {
                        t = 0f; // Loop back to the start
                    }
                }
            }
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Draw();
    }

    protected abstract void Draw();
}