using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CPTS587
{
    public class Player
    {

        public Vector2 position;

        public Texture2D Texture { get; set; }
        public Rectangle Bounds;

        private int entityWidth;
        private int entityHeight;
        private int screenHeight;
        private int screenWidth;

        public Player(Texture2D texture, int inpScreenWidth, int inpScreenHeight)
        {
            Texture = texture;
            
            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            screenHeight = inpScreenHeight;
            screenWidth = inpScreenWidth;


        position = new Vector2(screenWidth / 2 - entityWidth / 2, screenHeight - entityHeight);

            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

    }
}
