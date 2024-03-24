using GreenEngineAPI.Core;
using GreenEngineAPI.Graphics;
using System.Collections.Generic;
using GreenEngineAPI.Physics;
using GreenEngineAPI.Input;

namespace DemoGame.GameAssets.Scenes
{
    public class TestScene : Scene2D
    {
        public GameObject go;

        public TestScene() : base(new ColorClass("#FFFFFF"),
            new Camera2D(new Vector2D(), Vector2D.OneVector2D(), 0), 
            new List<RendererObject2D>())
        { }

        public override void OnLoad()
        {
            go = new GameObject(new Vector2D(100, 500), new Vector2D(50, 50), "GameAssets\\InsotheoLogo.png", "a");
            go.BodyType = PhysicsConstants.BodyType2D.Rigid;
            go.Mass = 1f;
            
        }

        public override void OnUpdate()
        {
            Log.Warning(go.Position.Y);
        }

        public override void OnKeyDown(KeyEventArg e)
        {
            go.AddForce(new Vector2D(3, 2), deltaTime, 2);
        }
    }
}
