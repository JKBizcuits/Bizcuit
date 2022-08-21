using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizcuit_Engine.Engine
{
    class Animation
    {
         public IntRect uvRect;

        public Animation(Texture texture, Vector2u imageCount)
        {
            uvRect.Width = (int)(texture.Size.X / imageCount.X);
            uvRect.Height = (int)(texture.Size.Y / imageCount.Y);
        }

        public void Update(int column, int row, bool faceRight)
        {

            uvRect.Top = row * uvRect.Height;

            if (faceRight)
            {
                uvRect.Left = column * uvRect.Width;
                uvRect.Width = Math.Abs(uvRect.Width);
            }
            else
            {
                uvRect.Left = (column + 1) * Math.Abs(uvRect.Width);
                uvRect.Width = -Math.Abs(uvRect.Width);
            }
        }

        public void Update(Vector2i position, bool faceRight)
        {
            uvRect.Top = position.Y * uvRect.Height;

            if (faceRight)
            {
                uvRect.Left = position.X * uvRect.Width;
                uvRect.Width = Math.Abs(uvRect.Width);
            }
            else
            {
                uvRect.Left = (position.X + 1) * Math.Abs(uvRect.Width);
                uvRect.Width = -Math.Abs(uvRect.Width);
            }
        }
    }
}
