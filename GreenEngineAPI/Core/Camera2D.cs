using GreenEngineAPI.Graphics;

namespace GreenEngineAPI.Core
{
    public class Camera2D
    {
        public Vector2D Position;
        public Vector2D Scale;
        public float RotationAngle;

        public Camera2D(Vector2D position, Vector2D scale, float rotationAngle)
        {
            Position = position;
            Scale = scale;
            RotationAngle = rotationAngle;
        }
    }
}
