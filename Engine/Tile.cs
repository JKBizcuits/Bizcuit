using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    class Tile : GameObject
    {
        Animation animation;
        public Vector2i selectedTexture;
        bool faceRight;

        public Tile(int column, int row, bool faceRight)
        {
            this.faceRight = faceRight;
            body = new Sprite(new Texture(@"..\..\Textures\TileSheet.png"));
            this.objectName = objectName;// set name of object
            animation = new Animation(body.Texture, new Vector2u(5, 4));//create animation object divided by columns and rows
            selectedTexture = new Vector2i(column, row);//this should be the currently selected texture position?
            body.TextureRect = new IntRect(selectedTexture, new Vector2i(animation.uvRect.Width, animation.uvRect.Height));//this sets the actual texture square being used
            body.Position = new Vector2f(0, 0);//sets position of sprite in window
            SetOrigin(body.TextureRect.Width / 2, body.TextureRect.Height/2);//sets origin of sprite
            animation.Update(selectedTexture, faceRight);
            body.TextureRect = animation.uvRect;
            collisionBox = new RectangleShape(new Vector2f(body.TextureRect.Width, 1.0f));
            collisionBox.Origin = body.Origin;
            collisionBox.Position = body.Position;
            collisionBox.OutlineColor = Color.Red;
            collisionBox.FillColor = Color.Yellow;
        }

        public override void Update(float deltaTime)
        {
            throw new NotImplementedException();
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
