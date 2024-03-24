using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;
using System.Collections.Generic;

namespace DemoGame.GameAssets.Scenes
{
    public class TestScene : Scene2D
    {
        public Sprite2D Sprite;
        bool a = true;


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
            if(Sprite.Position.X < 500)
            {
                Sprite.Position.X += 1;
            }
            else
            {
                if (a)
                {
                    RendererGameWindow.LoadScene(0);
                    a = false;
                    Game.BACK();
                }
                Sprite.Position.Y += 1;
            }
            Camera.Position.X += 2;
        }
    }
}
