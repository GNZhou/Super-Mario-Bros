using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class AnimatedNotMovingSprite : ISprite
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D Texture { get; set; }
        private Vector2 destination;
        private int currentFrame = 0;
        private readonly int totalFrames;
       

        public AnimatedNotMovingSprite(Texture2D texture, int rows, int columns, Vector2 destination)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
            this.destination = destination;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)destination.X, (int)destination.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
            currentFrame++;

            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

        }
    }
}
