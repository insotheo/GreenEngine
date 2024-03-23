namespace GreenEngineAPI.Graphics
{
    public class Sprite2D : RendererObject2D
    {
        public Sprite2D(Vector2D position, Vector2D scale, string pathToFile, string tag) :
            base(position, scale, pathToFile, tag) { }

        public Sprite2D(ref Texture2D texture, string tag) : base(ref texture, tag) { }

    }
}
