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
        public GameObject go2;
        float speed = 2;


        public TestScene() : base(new ColorClass("#FFFFFF"),
            new Camera2D(new Vector2D(), Vector2D.OneVector2D(), 0), 
            new List<RendererObject2D>())
        { }

        public override void OnLoad()
        {
            go = new GameObject(new Vector2D(100, 500), new Vector2D(50, 50), "GameAssets\\InsotheoLogo.png", "a");
            go2 = new GameObject(new Vector2D(400, 400), new Vector2D(50, 50), "GameAssets\\InsotheoLogo.png", "a");
            go2.HasCollision = true;
            go.HasCollision = false;
            go.BodyType = PhysicsConstants.BodyType2D.Rigid;
            go.Mass = 1.25f;
            
        }

        public override void OnKeyDown(KeyEventArg e)
        {
            if(e.Key == Key.KeyCode.W)
            {
                go.AddForce(new Vector2D(0, -speed), deltaTime, 2);
            }
            else if(e.Key == Key.KeyCode.S)
            {
                go.AddForce(new Vector2D(0, speed), deltaTime, 2);
            }
            else if(e.Key == Key.KeyCode.D)
            {
                go.AddForce(new Vector2D(speed, 0), deltaTime, 2);
            }
            else if (e.Key == Key.KeyCode.A)
            {
                go.AddForce(new Vector2D(-speed, 0), deltaTime, 2);
            }
        }
    }
}
