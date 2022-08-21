using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    class Player : GameObject
    {
        float duration;
        bool canJump;
        bool crouch;
        bool faceRight;
        float jumpHeight;
        Animation animation;
        Vector2i selectedTexture;
        public Player(string objectName)
        {
            body = new Sprite(new Texture(@"..\..\Textures\spriteSheet2.png"));
            this.objectName = objectName;// set name of object
            
            animation = new Animation(body.Texture, new Vector2u(6, 4));//create animation object divided by columns and rows
            selectedTexture = new Vector2i(0, 0);//this should be the currently selected texture position?
            body.TextureRect = new IntRect(selectedTexture, new Vector2i(animation.uvRect.Width, animation.uvRect.Height));//this sets the actual texture square being used
            body.Position = new Vector2f(0, 0);//sets position of sprite in window
            SetOrigin(body.TextureRect.Width/2, body.TextureRect.Height/4*3);//sets origin of sprite
            crouch = false;
            faceRight = true;//checks if sprite faces right or left
            duration = 0;
            speed = 1;
            jumpHeight = 10; 
            collisionBox = new RectangleShape(new Vector2f(body.TextureRect.Width, body.TextureRect.Height));
            collisionBox.Origin = body.Origin;
            collisionBox.Position = body.Position;
            collisionBox.OutlineColor = Color.Green;
            collisionBox.FillColor = Color.Magenta;
        }

        public override void Update(float deltaTime)
        {
            velocity.X = 0.0f;

            if (Keyboard.IsKeyPressed(Keyboard.Key.T))
            {
                Console.WriteLine(body.Position);
                Console.WriteLine(velocity.Y);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                velocity.X -= speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                velocity.X += speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && canJump)
            {
                canJump = false;
                velocity.Y -= (float)Math.Sqrt((double)(2.0f * 9.810f * jumpHeight));
            }
            else if (!canJump)
            {
                velocity.Y += 9.810f * deltaTime;
            }
            if (!Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                crouch = false;
            }
            else
            {
                crouch = true;
            }
            if (velocity.X == 0.0f && crouch == false && velocity.Y == 0.0f)
            {
                selectedTexture = new Vector2i(0, 0);
                duration = 0;
            }
            else if (velocity.X == 0.0f && crouch == true && velocity.Y == 0.0f)
            {
                selectedTexture = new Vector2i(2, 2);
                duration = 0;
            }
            else if (velocity.X != 0.0f && velocity.Y == 0)
            {
                duration += deltaTime;
                selectedTexture.Y = 1;
                if (duration < 0.25f)
                {
                    selectedTexture.X = 0;

                }
                else if (duration >= 0.25f && duration < 0.5f)
                {
                    selectedTexture.X = 1;
                }
                else if (duration >= 0.5f && duration < 0.75f)
                {
                    selectedTexture.X = 2;
                }
                else if (duration >= 0.75f && duration < 1.0f)
                {
                    selectedTexture.X = 3;
                }
                else if (duration >= 1.0f && duration < 1.25f)
                {
                    selectedTexture.X = 4;
                }
                else if (duration >= 1.25f && duration < 1.5f)
                {
                    selectedTexture.X = 5;
                }
                else
                {
                    selectedTexture.X = 0;
                    duration = 0.0f;
                }
            }
            else if (canJump == false)
            {
                if (velocity.Y <= 0.0f)
                {
                    selectedTexture = new Vector2i(0, 2);
                }
                else
                {
                    selectedTexture = new Vector2i(1, 2);
                }
            }
            if (velocity.X > 0.0f)
            {
                faceRight = true;
            }
            else if (velocity.X < 0.0f)
            {
                faceRight = false;
            }
            if (faceRight)
            {
                SetOrigin(body.TextureRect.Width / 2, body.TextureRect.Height / 4 * 3);
            }
            else
            {
                SetOrigin(Math.Abs(body.TextureRect.Width) / 2, body.TextureRect.Height / 4 * 3);
            }
            animation.Update(selectedTexture, faceRight);
            body.TextureRect = animation.uvRect;
            body.Position = new Vector2f(body.Position.X + (velocity.X * deltaTime), body.Position.Y + (velocity.Y * deltaTime));
            collisionBox.Position = body.Position;
        }
        protected override void Update()
        {

        }
       
        public void Move(float x, float y, float deltaTime)
        {
            body.Position = new Vector2f(body.Position.X + (x * deltaTime), body.Position.Y + (y * deltaTime));
            collisionBox.Position = body.Position;
        }

        public override Collider GetCollider()
        {


            return new Collider(this);
        }

        public void OnCollision(Vector2f direction)
        {
            Console.WriteLine(direction);
            if (direction.X < 0.0f)
            {
                velocity.X = 0.0f;
            }
            else if (direction.X > 0.0f)
            {
                velocity.X = 0.0f;
            }
            if (direction.Y < 0.0f)
            {
                Console.WriteLine("directions");
                velocity.Y = 0.0f;
                canJump = true;
            }
            else if (direction.Y > 0.0f)
            {
                Console.WriteLine("directions2");
                velocity.Y = 0.0f;
            }
        }
    }
}
