using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    abstract class GameObject
    {

        public string objectName { get; set; }
        public Sprite body;
        public RectangleShape collisionBox;
        public bool gravityCollision;
        protected float speed;
        protected Vector2f velocity;
        protected Vector2f size;
        public GameObject()
        { 
            Console.WriteLine("I am empty and desire sustinance");
            
        }

        public GameObject(string objectName)
        {
            this.objectName = objectName;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(body);
        }

        protected abstract void Update();
        public abstract void Update(float deltaTime);

        public abstract Collider GetCollider();

        public override string ToString()
        {
            string result = "GameObject: " + objectName + ", body: " + body.ToString();
            return result;
        }

        public void SetOrigin(float x, float y)
        {
            body.Origin = new Vector2f(x, y);
        }

        public void SetOrigin(Vector2f origin)
        {
            body.Origin = origin;
        }

        public void SetTexture(string texture)
        {
            body.Texture = new Texture(texture);
            
        }

    }
}
