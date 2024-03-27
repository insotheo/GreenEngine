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
        public float R;
        public float FrictionForce;
        public float FallForce;
        public float GettingForce;
        public float Friction;
        public Vector2D ForceDirection;
        public Vector2D Acceleration;
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
            Mass = 1;
            ColliderRadius = 1;
            HasCollision = true;
            BodyType = PhysicsConstants.BodyType2D.Static;
            Acceleration = new Vector2D();
            ForceDirection = new Vector2D(0, 0);
            R = 0;
            FrictionForce = 0;
            FallForce = 0;
            Friction = 1.6f;
            GettingForce = 0;
        }
        public void SimulatePhysics(float deltaTime)
        {
            if (BodyType != PhysicsConstants.BodyType2D.Static)
            {
                Acceleration.Y -= 1;

                FallForce = Mass * PhysicsConstants.g; //F = mg
                FrictionForce = Acceleration.Y != 0 && Acceleration.X != 0 ? Friction * Mass * PhysicsConstants.g * -1 : 0;


                R = FrictionForce + FallForce + GettingForce;
            }
            if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count - 1 > 0)
            {
                for(int i = 0; i < RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count; i++)
                {
                    if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i] != this)
                    {
                        if (IsCollided(RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i]))
                        {
                            InteractCollidedObject(RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects[i], new Vector2D(-Acceleration.X, -Acceleration.Y), deltaTime / 10);
                        }
                    }
                }
            }
            deltaTime /= 10;
            Position.X += R * deltaTime * Acceleration.X;
            Position.Y += R * deltaTime * Acceleration.Y;
            GettingForce = GettingForce <= 0 ? 0 : GettingForce - deltaTime;
            Acceleration = Vector2D.ZeroVector2D();
        }

        public void AddForce(Vector2D direction, float deltaTime, float deltaVelocity)
        {
            if(deltaTime != 0){
                GettingForce = (((float)Math.Pow(Mass, -1) + 1 * deltaVelocity) / deltaTime);
                Acceleration.X += GettingForce * direction.X;
                if(Acceleration.X != 0)
                {
                    Acceleration.X += direction.X;
                }
                Acceleration.Y += GettingForce * -direction.Y;
            }
        }

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
            foreach(var body in RendererGameWindow.SceneManager.GetCurrentScene().SceneRendererObjects)
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

        private void InteractCollidedObject(GameObject obj, Vector2D interactionVector, float deltaTime)
        {
            if (obj.BodyType == PhysicsConstants.BodyType2D.Kinematic && BodyType == PhysicsConstants.BodyType2D.Kinematic)
            {
                obj.Position.X += (Mass * obj.Mass * GettingForce + obj.ColliderRadius * ColliderRadius * 2) * -interactionVector.X;
                obj.Position.Y += (Mass * obj.Mass * GettingForce + obj.ColliderRadius * ColliderRadius * 2) * interactionVector.Y;
            }
            else if (obj.BodyType == PhysicsConstants.BodyType2D.Static)
            {
                Acceleration.X = -interactionVector.X * PhysicsConstants.ColliderK;
                Acceleration.Y = interactionVector.Y * PhysicsConstants.ColliderK;
                FallForce = 0;
            }
        }
    }
}
