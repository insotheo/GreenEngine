using System.Drawing;
using System.IO;

namespace GreenEngineAPI.Graphics
{
    public class Texture2D
    {
        public Vector2D Position;
        public Vector2D Scale;
        public Bitmap Sprite;
        public string PathToFile;

        public Texture2D(Vector2D position, Vector2D scale, string pathToFile)
        {
            Position = position;
            Scale = scale;
            PathToFile = pathToFile;
            Image temp = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), pathToFile));
            Sprite = new Bitmap(temp, (int)Scale.X, (int)Scale.Y);
        }
    }
}
