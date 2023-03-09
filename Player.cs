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
    internal class Player
    {

        Vector2 position;
        float speed = 4.0f;
        bool regularSpeed;
        private double _timeSinceLastSpeedChange = 0;
        private double _speedChangeInterval = 0.5;


        public Texture2D Texture { get; set; }
        public Rectangle Bounds;

        private int entityWidth;
        private int entityHeight;
        private int screenHeight;
        private int screenWidth;




        public Player(Texture2D texture, int inpScreenWidth, int inpScreenHeight)
        {
            Texture = texture;
            regularSpeed = true;
            
            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            screenHeight = inpScreenHeight;
            screenWidth = inpScreenWidth;


        position = new Vector2(screenWidth / 2 - entityWidth / 2, screenHeight - entityHeight);

            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            _timeSinceLastSpeedChange += gameTime.ElapsedGameTime.TotalSeconds;

            if (keyState.IsKeyDown(Keys.Tab) && _timeSinceLastSpeedChange >= _speedChangeInterval) 
            {
                if (regularSpeed == true)
                {
                    regularSpeed = false;
                    speed = 2.0f;
                }
                else
                {
                    regularSpeed = true;
                    speed = 4.0f;
                }
            }

            if (keyState.IsKeyDown(Keys.Up) && position.Y > 0)
            {
                position.Y -= speed;
            }
            if (keyState.IsKeyDown(Keys.Down) && position.Y < (screenHeight - entityHeight))
            {
                position.Y += speed;
            }
            if (keyState.IsKeyDown(Keys.Left) && position.X > 0)
            {
                position.X -= speed;
            }
            if (keyState.IsKeyDown(Keys.Right) && position.X < (screenWidth - entityWidth))
            {
                position.X += speed;
            }
            if (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Left))
            {
                if (position.X > 0)
                {
                    position.X -= speed * 0.5f;
                }
                if (position.Y > 0)
                {
                    position.Y -= speed * 0.5f;
                }
            }
            if (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Right))
            {
                if (position.X < (screenWidth - entityWidth))
                {
                    position.X += speed * 0.5f;
                }
                if (position.Y > 0)
                {
                    position.Y -= speed * 0.5f;
                }
            }
            if (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Left))
            {
                if (position.X > 0)
                {
                    position.X -= speed * 0.7f;
                }
                if (position.Y < (screenHeight - entityHeight))
                {
                    position.Y += speed * 0.7f;
                }
                
            }
            if (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Right))
            {
                if (position.X < (screenWidth - entityWidth))
                {
                    position.X += speed * 0.7f;
                }
                if (position.Y < (screenHeight - entityHeight))
                {
                    position.Y += speed * 0.7f;
                }
                    
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

    }
}
