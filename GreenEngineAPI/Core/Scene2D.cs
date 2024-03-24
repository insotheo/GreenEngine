using GreenEngineAPI.Graphics;
using System.Collections.Generic;
using GreenEngineAPI.Input;
using GreenEngineAPI.Physics;

namespace GreenEngineAPI.Core
{
    public class Scene2D
    {
        public ColorClass Color;
        public List<RendererObject2D> SceneRendererObjects;
        public Camera2D Camera;
        public List<GameObject> PhysicsObjects;

        public float deltaTime;

        public Scene2D(ColorClass backgroundColor, Camera2D camera, List<RendererObject2D> objectsOnScene)
        {
            Color = backgroundColor;
            Camera = camera;
            SceneRendererObjects = objectsOnScene;
            PhysicsObjects = new List<GameObject>();
            if(SceneRendererObjects.Count > 0)
            {
                foreach(var obj in SceneRendererObjects)
                {
                    if(obj is GameObject)
                    {
                        PhysicsObjects.Add(obj as GameObject);
                    }
                }
            }
        }

        public virtual void OnLoad() { }
        public virtual void OnUpdate() { }
        public virtual void OnDraw() { }
        public virtual void OnKeyDown(KeyEventArg e) { }
        public virtual void OnKeyUp(KeyEventArg e) { }

        public void OnPhysics()
        {
            foreach(GameObject gameObject in PhysicsObjects)
            {
                gameObject.SimulatePhysics(deltaTime);
            }
        }

    }
}
