using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPTS587;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input;

namespace CPTS587
{
    public class GameOver
    {

        private SpriteFont myFont;
        private string gameOVer = "GAME OVER";
        private Texture2D Texture;
        private int gWidth;
        private int gHeight;
        private SpriteBatch spriteBatch;
        GraphicsDevice gd;
        public static event EventHandler MethodExecuted;
        private SpriteBatch textSpriteBatch;

        public GameOver(int Height, int Width, SpriteFont Font, SpriteBatch spriteBatch, GraphicsDevice gd)
        {

            this.myFont = Font;
            this.gWidth = ((Width / 2) - 150);
            this.gHeight = Height / 2;
            this.spriteBatch = spriteBatch;
            this.gd = gd;

        }



        public void Draw()
        {

            //spriteBatch.Begin();

            spriteBatch.DrawString(myFont, gameOVer, new Vector2(gWidth, gHeight), Color.White);

            //spriteBatch.End();




        }

    }
}
