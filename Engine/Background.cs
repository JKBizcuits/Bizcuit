using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    class Background : GameObject
    {
        float duration;
        bool canJump;
        bool crouch;
        bool faceRight;
        float jumpHeight;
        Animation animation;
        Vector2i selectedTexture;
        public Background(string objectName)
        {
            body = new Sprite(new Texture(@"..\..\Textures\MoonBackground.png"));
            this.objectName = objectName;// set name of object

            //animation = new Animation(body.Texture, new Vector2u(6, 4));//create animation object divided by columns and rows
            selectedTexture = new Vector2i(0, 0);//this should be the currently selected texture position?
            //body.TextureRect = new IntRect(selectedTexture, new Vector2i(animation.uvRect.Width, animation.uvRect.Height));//this sets the actual texture square being used
            body.Position = new Vector2f(0, 0);//sets position of sprite in window
            SetOrigin(body.TextureRect.Width / 2, body.TextureRect.Height / 4 * 3);//sets origin of sprite
            crouch = false;
            faceRight = true;//checks if sprite faces right or left
            duration = 0;
            speed = 1;
            jumpHeight = 10;

        }

        public override void Update(float deltaTime)
        {
            
        }
        protected override void Update()
        {

        }

        public override Collider GetCollider()
        {
            return new Collider(this);
        }

    }
}
