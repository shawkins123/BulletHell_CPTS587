using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587.Graphics
{
    public class Sprite
    {
            private Texture2D texture;

            public Texture2D Texture
            {
                get { return texture; }
                private set { texture = value; }
            }

            private int xField;

            public int XField
            {
                get { return xField; }
                set { xField = value; }
            }

            private int yField;

            public int YField
            {
                get { return yField; }
                set { yField = value; }
            }

            private int width;

            public int Width
            {
                get { return width; }
                set { width = value; }
            }

            private int height;

            public int Height
            {
                get { return height; }
                set { height = value; }
            }

        public Sprite(Texture2D texture, int x, int y, int width, int height)
        {
            Texture = texture;
            XField = x;
            YField = y;
            Width = width;
            Height = height;
        }

            public void Draw(SpriteBatch spriteBatch, Vector2 position)
            {
            spriteBatch.Draw(Texture, position, new Rectangle(XField, YField, Width, Height), Color.White);
            }


        
    }
}
