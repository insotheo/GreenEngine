using DemoGame.GameAssets.Scenes;
using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;


namespace DemoGame
{
    public class Game : RendererGameWindow
    {
        static TestScene testScene;

        public Game() : base(new Vector2D(1280, 720),
            "Test game",
            new ColorClass(35, 40, 80),
            GameCanvas.WindowStyles.Sizable) { }

        protected override void OnGameLoad()
        {
            testScene = new TestScene();
            SceneManager.AddScene(testScene);
            SceneManager.LoadScene(1);
        }



    }
}
