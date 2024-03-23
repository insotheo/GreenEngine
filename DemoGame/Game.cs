﻿using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;


namespace DemoGame
{
    public class Game : RendererGameWindow
    {
        public Game() : base(new Vector2D(800, 600),
            "Test game",
            new ColorClass(35, 40, 80),
            GameCanvas.WindowStyles.Sizable) { }

        protected override void OnGameLoad()
        {
            Sprite2D player = new Sprite2D(new Vector2D(400, 300), new Vector2D(50, 50), "GameAssets\\InsotheoLogo.png", "player");
        }

    }
}
