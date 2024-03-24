using GreenEngineAPI.Graphics;
using System.Collections.Generic;

namespace GreenEngineAPI.Core
{
    public class Scene2D
    {
        public ColorClass Color;
        public List<RendererObject2D> SceneRendererObjects;
        public Camera2D Camera;

        public Scene2D(ColorClass backgroudnColor, Camera2D camera, List<RendererObject2D> objectsOnScene)
        {
            Color = backgroudnColor;
            Camera = camera;
            SceneRendererObjects = objectsOnScene;
        }


        public virtual void OnLoad() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }

    }
}
