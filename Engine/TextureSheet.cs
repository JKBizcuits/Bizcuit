using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    class TextureSheet
    {
        //Texture[] textureList;
        IntRect[,] textureList;
        int columns;
        int rows;
        Sprite thing;
        Texture OriginalTexture;
        public TextureSheet(string textureFilePath)
        {

            OriginalTexture = new Texture(textureFilePath);
        }

        public TextureSheet(Texture texture)
        {
            OriginalTexture = texture;
        }

        public TextureSheet(string textureFilePath, int width, int height)
        {
            this.columns = width;
            this.rows = height;
            textureList = new IntRect[height, width];
            OriginalTexture = new Texture(textureFilePath);

        
        }

        public TextureSheet(Texture texture, int width, int height)
        {
            this.columns = width;
            this.rows = height;
            textureList = new IntRect[height, width];
            OriginalTexture = texture;


        }
    }
}
