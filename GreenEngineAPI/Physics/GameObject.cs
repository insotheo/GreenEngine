using GreenEngineAPI.Graphics;
using GreenEngineAPI.Core;
using System;


namespace GreenEngineAPI.Physics
{
    public class GameObject : RendererObject2D
    {
        //string tag
        //bool IsInRender
        //Bitmap Sprite

        //Vector2D Position
        //Vector2D Scale
        public float Mass;
        public bool IsSimulatePhysics;
        public float ColliderRadius;
        public bool HasCollision;
        public float Friction;
        public Vector2D Velocity;
        public PhysicsConstants.BodyType2D BodyType; //Static Kinematic

        public GameObject(Vector2D position, Vector2D scale, string pathToFile, string tag) 
            : base(position, scale, pathToFile, tag)
        {
            SetDefaultPhysicsSettings();
        }

        public GameObject(ref Texture2D texture, string tag)
            : base (ref texture, tag) 
        {
            SetDefaultPhysicsSettings(); 
        }

        private void SetDefaultPhysicsSettings()
        {
            Mass = 1f;
            ColliderRadius = 1f;
            HasCollision = true;
            Friction = 1.6f;
            BodyType = PhysicsConstants.BodyType2D.Static;
            Velocity = new Vector2D();
        }
        public void SimulatePhysics(float deltaTime)
        {
            if (BodyType != PhysicsConstants.BodyType2D.Static)
            {
                Vector2D gravityForce = new Vector2D(0, Mass * PhysicsConstants.g);
                Vector2D frictionForce = Velocity * (-Friction);
                Vector2D totalForce = gravityForce + frictionForce;
                Vector2D acceleration = totalForce / Mass;
                Velocity += acceleration * deltaTime;
                Vector2D newPosition = Position + Velocity * deltaTime;
                if (CheckCollision(newPosition))
                {
                    Velocity = Vector2D.ZeroVector2D();
                }
                else
                {
                    Position = newPosition;
                }
            }
            if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count - 1 > 0)
            {
                for(int i = 0; i < RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count; i++)
                {
                    if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i] != this)
                    {
                        if (IsCollided(RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i]))
                        {
                            InteractCollidedObject(RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i]);
                        }
                    }
                }
            }
        }

        public void AddForce(Vector2D direction, float deltaTime, float deltaVelocity)
        {
            Vector2D force = direction * deltaVelocity;
            Velocity += force / Mass * deltaTime;
        }

        private void InteractCollidedObject(GameObject body)
        {
            float deltaX = Position.X - body.Position.X;
            float deltaY = Position.Y - body.Position.Y;
            if(Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    Position.X = body.Position.X + body.Scale.X / 2 + Scale.X / 2;
                }
                else
                {
                    Position.X = body.Position.X - body.Scale.X / 2 - Scale.X / 2;
                }
            }
            else
            {
                if(deltaY > 0)
                {
                    Position.Y = body.Position.Y + body.Scale.Y / 2 + Scale.Y / 2;
                }
                else
                {
                    Position.Y = body.Position.Y - body.Scale.Y / 2 - Scale.Y / 2;
                }
            }
        }


        //Collision checkers
        private bool IsCollided(GameObject body)
        {
            if (!body.HasCollision || !HasCollision) { return false; }
            else
            {
                if (this.Position.X + ColliderRadius <= body.Position.X + body.Scale.X &&
                        this.Position.X + this.Scale.X - ColliderRadius >= body.Position.X &&
                        this.Position.Y + ColliderRadius <= body.Position.Y + body.Scale.Y &&
                        this.Position.Y + this.Scale.Y - ColliderRadius >= body.Position.Y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsColliding(string tag)
        {
            foreach (var body in RendererGameWindow.SceneManager.GetCurrentScene().SceneRendererObjects)
            {
                if (this.Position.X + ColliderRadius <= body.Position.X + body.Scale.X &&
                    this.Position.X + this.Scale.X - ColliderRadius >= body.Position.X &&
                    this.Position.Y + ColliderRadius <= body.Position.Y + body.Scale.Y &&
                    this.Position.Y + this.Scale.Y - ColliderRadius >= body.Position.Y)
                {
                    return true;
                }
                else
                {
                    continue;
                }
            }
            return false;
        }

        private bool CheckCollision(Vector2D newPosition)
        {
            if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count - 1 > 0)
            {
                for (int i = 0; i < RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count; i++)
                {
                    if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i] != this)
                    {
                        if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i].Position == newPosition)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
