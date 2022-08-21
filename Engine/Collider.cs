using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    class Collider
    {
        private RectangleShape body;
        private GameObject GO;

        public Collider(GameObject GO)
        {
            this.GO = GO;
            body = GO.collisionBox;
        }

        public bool CheckCollision(Collider other, ref Vector2f direction, float push)
        {

            Vector2f otherPosition = other.GetPosition();
            Vector2f OtherHalfSize = other.GetHalfSize();
            Vector2f thisPosition = GetPosition();
            Vector2f thisHalfSize = GetHalfSize();

            float deltaX = otherPosition.X - thisPosition.X;
            float deltaY = otherPosition.Y - thisPosition.Y;

            float intersectX = Math.Abs(deltaX) - (OtherHalfSize.X + thisHalfSize.X);
            float intersectY = Math.Abs(deltaY) - (OtherHalfSize.Y + thisHalfSize.Y);

            if (intersectX < 0.0f && intersectY < 0.0f)
            {
                Console.WriteLine("COLLIDE");
                push = Math.Min(Math.Max(push, 0.0f), 1.0f);//clamping

                if (intersectX > intersectY)
                {

                    if (deltaX > 0.0f)
                    {
                        Console.WriteLine("Check1");
                        Move(intersectX * (1.0f - push), 0.0f);
                        other.Move(-intersectX * push, 0.0f);
                        direction.X = 1.0f;
                        direction.Y = 0.0f;
                    }
                    else
                    {
                        Console.WriteLine("Check2");
                        Console.WriteLine(push);
                        Move(-intersectX * (1.0f - push), 0.0f);
                        other.Move(intersectX * push, 0.0f);
                        direction.X = -1.0f;
                        direction.Y = 0.0f;
                    }
                }
                else
                {
                    if (deltaY > 0.0f)
                    {
                        Console.WriteLine("Check3");
                        Move(0.0f, intersectY * (1.0f - push));
                        other.Move(0.0f, -intersectY * push);

                        direction.X = 0.0f;
                        direction.Y = 1.0f;
                    }
                    else
                    {
                        Console.WriteLine("Check4");
                        Move(0.0f, -intersectY * (1.0f - push));
                        other.Move(0.0f, intersectY * push);
                        direction.X = 0.0f;
                        direction.Y = -1.0f;
                    }
                }
                Console.WriteLine(direction + "1");
                return true;
            }
            Console.WriteLine(direction + "2");
            return false;

        }

        public Vector2f GetPosition()
        {
            return body.Position;
        }

        public Vector2f GetHalfSize()
        {
            return body.Size / 2.0f;
        }

        public void Move(float dx, float dy)
        {
            Console.WriteLine("testing2:" + body.Position.ToString());
            body.Position = new Vector2f(body.Position.X + dx, body.Position.Y + dy);
            GO.body.Position = body.Position;
            Console.WriteLine("testing2:" + body.Position.ToString());
            Console.WriteLine("moving");
            Console.WriteLine(dx);
            
            
        }
    }
}

