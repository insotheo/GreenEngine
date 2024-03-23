using System.Drawing;

namespace GreenEngineAPI.Graphics
{
    public class ColorClass
    {
        public Color color;

        public ColorClass(string HEX)
        {
            color = ColorTranslator.FromHtml(HEX);
        }

        public ColorClass(int R, int G, int B)
        {
            color = Color.FromArgb(R, G, B);
        }
    }
}
