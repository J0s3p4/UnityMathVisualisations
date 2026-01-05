using UnityEngine;

public abstract class VisualiserBase : MonoBehaviour
{
    [Range(0f, 1f)]
    public float t;

    protected virtual void OnDrawGizmos()
    {
        Draw();
    }

    protected abstract void Draw();
}