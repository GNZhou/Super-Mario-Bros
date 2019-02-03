using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class StaticSprite : ISprite
    {

        public int Columns { get; set; }
        public int Rows { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle SourceRectangle { get; set; }
        private Vector2 destination;


        public StaticSprite(Texture2D texture, Rectangle sourceRectangle, Vector2 destination)
        {
            Columns = 1;
            Rows = 1;

            Texture = texture;
            SourceRectangle = sourceRectangle;
            this.destination = destination;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)destination.X,
                                                           (int)destination.Y,
                                                           SourceRectangle.Width,
                                                           SourceRectangle.Height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, SourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void Update()
        {
        }
    }
}
