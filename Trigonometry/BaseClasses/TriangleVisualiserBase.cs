using UnityEngine;

public abstract class TriangleVisualiserBase : VisualiserBase
{

    [Header("Triangle Settings")]
    public Color triangleColor = Color.yellow;
    // Label sides?


    protected override void Draw()
    {
        CalculateVertices();

        //Draw Lines
        // Line A a -> b
        // Line B b -> c
        // Line C c -> d

        //Draw Angles

    }

    // Each solver will calculate vertices
    protected abstract void CalculateVertices();

}
