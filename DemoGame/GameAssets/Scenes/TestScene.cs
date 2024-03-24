using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;
using System.Collections.Generic;

namespace DemoGame.GameAssets.Scenes
{
    public class TestScene : Scene2D
    {
        public Sprite2D Sprite;

        public TestScene() : base(new ColorClass("#FFFFFF"),
            new Camera2D(new Vector2D(), Vector2D.OneVector2D(), 0), 
            new List<RendererObject2D>())
        { }

        public override void OnLoad()
        {
            Sprite = new Sprite2D(new Vector2D(200, 200), new Vector2D(50, 50), "GameAssets\\InsotheoLogo.png", "IMAGE");
        }

        public override void OnUpdate()
        {

        }
    }
}
