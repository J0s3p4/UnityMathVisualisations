# Unity Math Visualisations
Attach scripts to empty GameObjects in scene.

## Global / Non-Exclusive
- SceneAxis: Creates an axis in scene.

## Vectors
- VectorVisualiser: Creates a vector in 3D space, for operations create two, set one to be Vector A and the other to Vector B in inspector.

- VectorAdditionVisualiser: Takes a reference to Vector A and Vector B, displays a vector as a result of their addition (A + B).

- VectorSubtractionVisualiser: Takes a reference to Vector A and Vector B, displays a vector as a result of their subtraction (A - B or B - A).

- VectorAngleVisualiser: Takes a reference to Vector A and Vector B, displays the angle between them in either degrees or radians.

- VectorDotProductVisualiser: Takes a reference to Vector A and Vector B, calculates and displays their dot product (A . B).

- VectorProjectionVisualiser: Takes a reference to Vector A and Vector B, and displays A projected on B or vice versa. Inspired by the visualisaton used in this video: https://youtu.be/LyGKycYT2v0?t=87

- VectorCrossProductVisualiser: Takes a reference to Vector A and Vector B, calculates and displays their cross product and area (A x B or B x A).

## Trigonometry

### Functions
- SineWaveVisualiser: Displays a Sine wave in scene.

- CosineWaveVisualiser: Displays a Cosine wave in scene.

- UnitCircleVisualiser: Displays a unit circle in the scene. Takes a reference to a Sine or Cosine visualiser and draws a connector line between the circle and the graph. Enabling Animate animates both the unit circle and the connected graph. Inspired by the visualisation used in this video: https://youtu.be/ZU-cIz8dvqU?t=426

### Triangles
- TriangleSASVisualiser: Takes in values for Side A, Side B and an Angle and creates a triangle in scene based on these values.

- TriangleSSSVisualiser: Takes in values for sides A, B and C, and creates a triangle in scene based on these values.