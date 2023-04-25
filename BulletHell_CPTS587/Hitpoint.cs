using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    public class Hitpoint
    {
        Vector2 position;
        public Texture2D Texture;
        public GraphicsDevice gd;
        private int sub;

        public Hitpoint(GraphicsDevice gd, Vector2 positionInput, int sub)
        {
            this.sub = sub;
            Texture2D hitPointBox = new Texture2D(gd, sub, sub);
            setColor(hitPointBox, sub);
            position = positionInput;
            Texture = hitPointBox;
        }

        private static void setColor(Texture2D hitPointBox, int sub)
        {
            Color[] data = new Color[sub * sub];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            hitPointBox.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public int getSub()
        {
            return sub;
        }

    }
}
