﻿using GreenEngineAPI.Graphics;
using System;
using GreenEngineAPI.Core;
using System.Security.Policy;

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
        public float ColliderRadius;
        public bool HasCollision;
        public float R;
        public float FrictionForce;
        public float FallForce;
        public float GettingForce;
        public float Friction;
        public Vector2D ForceDirection;
        public Vector2D Acceleration;
        public PhysicsConstants.BodyType2D BodyType; //Static Kinematic Rigid

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
            if (RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects.Count - 1 > 0)
            {
                foreach (GameObject obj in RendererGameWindow.SceneManager.GetCurrentScene().PhysicsObjects)
                {
                    if (obj != this)
                    {
                        if (IsCollided(obj))
                        {
                            Log.Info("On collided");
                        }
                    }
                }
            }
            if(BodyType != PhysicsConstants.BodyType2D.Static)
            {
                if (Acceleration.Y > 0)
                {
                    Acceleration.Y += deltaTime;
                }
                else
                {
                    Acceleration.Y -= deltaTime;
                }
                FallForce = Mass * PhysicsConstants.g; //F = mg
                FrictionForce = Acceleration.Y != 0 && Acceleration.X != 0 ? Friction * Mass * PhysicsConstants.g * -1 : 0;


                R = FrictionForce + FallForce + GettingForce;

                deltaTime /= 10;
                Position.X += R * deltaTime * Acceleration.X;
                Position.Y += R * deltaTime * Acceleration.Y;
                GettingForce = GettingForce <= 0 ? 0 : GettingForce - deltaTime;
                Acceleration = Vector2D.ZeroVector2D();
            }
        }

        public void AddForce(Vector2D direction, float deltaTime, float deltaVelocity)
        {
            GettingForce = ((Mass * deltaVelocity) / deltaTime);
            Acceleration.X += GettingForce * direction.X;
            if(Acceleration.X != 0)
            {
                Acceleration.X += direction.X;
            }
            Acceleration.Y += GettingForce * -direction.Y;
        }

        public bool IsCollided(GameObject body)
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

        public void InteractCollidedObject(GameObject obj, Vector2D interactionVector)
        {

        }
    }
}
