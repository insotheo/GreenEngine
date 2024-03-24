namespace GreenEngineAPI.Graphics
{
    public class Vector2D
    {
        public float X, Y;

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Vector2D()
        {
            X = ZeroVector2D().X;
            Y = ZeroVector2D().Y;
        }

        public static Vector2D ZeroVector2D()
        {
            return new Vector2D(0, 0);
        }

        public static Vector2D OneVector2D()
        {
            return new Vector2D(1, 1);
        }
    }
}
