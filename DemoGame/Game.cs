using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;


namespace DemoGame
{
    public class Game : RendererGameWindow
    {
        public Game() : base(new Vector2D(700, 600),
            "Test game",
            GameCanvas.WindowStyles.FixedSingle) { }


    }
}
