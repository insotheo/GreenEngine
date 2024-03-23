using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;


namespace DemoGame
{
    public class Game : RendererGameWindow
    {
        public Game() : base(new Vector2D(800, 600),
            "Test game",
            new ColorClass(35, 40, 80),
            GameCanvas.WindowStyles.FixedSingle) { }


    }
}
