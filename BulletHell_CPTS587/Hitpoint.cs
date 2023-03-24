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


        public Hitpoint(GraphicsDevice gd, Vector2 positionInput)
        {
            Texture2D hitPoint = new Texture2D(gd, 20, 20);
            setColor(hitPoint);
            Vector2 position = positionInput;
        }

        private static void setColor(Texture2D hitPoint)
        {
            Color[] data = new Color[20 * 20];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            hitPoint.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }
        /*
        Texture2D rectangleX;



        Texture2D rectangle = new Texture2D(GraphicsDevice, 20, 20);
        rectangleX = rectangle; 

        Color[] data = new Color[20 * 20];
            for (int i = 0; i<data.Length; ++i) data[i] = Color.Chocolate;
            rectangleX.SetData(data);

            Microsoft.Xna.Framework.Vector2 coor = new Microsoft.Xna.Framework.Vector2(20, 20);
        spriteBatch.Draw(rectangleX, coor, Color.White);

        */

    }
}
