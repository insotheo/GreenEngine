using GreenEngineAPI.Graphics;
using System.Collections.Generic;
using GreenEngineAPI.Input;

namespace GreenEngineAPI.Core
{
    public class Scene2D
    {
        public ColorClass Color;
        public List<RendererObject2D> SceneRendererObjects;
        public Camera2D Camera;

        public Scene2D(ColorClass backgroundColor, Camera2D camera, List<RendererObject2D> objectsOnScene)
        {
            Color = backgroundColor;
            Camera = camera;
            SceneRendererObjects = objectsOnScene;
        }

        public virtual void OnLoad() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnKeyDown(KeyEventArg e) { }
        public virtual void OnKeyUp(KeyEventArg e) { }

    }
}
