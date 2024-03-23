using GreenEngineAPI.Core;
using System.Drawing;
using System.IO;

namespace GreenEngineAPI.Graphics
{
    public abstract class RendererObject2D
    {
        public Vector2D Position;
        public Vector2D Scale;
        public string Tag;
        public Bitmap Sprite;
        public bool IsInRender;

        public RendererObject2D(Vector2D position, Vector2D scale, string pathToFile,string tag)
        {
            Position = position;
            Scale = scale;
            Tag = tag;
            IsInRender = true;
            Image temp = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), pathToFile));
            Sprite = new Bitmap(temp, (int)Scale.X, (int)Scale.Y);
            RendererGameWindow.AddRendererObject(this);
        }

        public RendererObject2D(ref Texture2D texture, string tag)
        {
            Position = texture.Position;
            Scale = texture.Scale;
            Tag = tag;
            IsInRender = true;
            Sprite = texture.Sprite;
            RendererGameWindow.AddRendererObject(this);
        }
    }
}
