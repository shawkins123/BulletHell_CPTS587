using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BulletHell_CPTS587;

namespace CPTS587
{
    public class Player
    {
        public Vector2 position;

        public Texture2D Texture { get; set; }
        public Rectangle Bounds;

        public int entityWidth; //set to private
        public int entityHeight; //set to private
        private int screenHeight;
        private int screenWidth;

        private bool isAlive;
        private int lives;
        private bool isInvincible;

        private float endTime;

        public bool isCheating; //cheat mode

        public Player(Texture2D texture, int inpScreenWidth, int inpScreenHeight, HealthBar healthBarInput)
        {
            Texture = texture;

            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            screenHeight = inpScreenHeight;
            screenWidth = inpScreenWidth;
            lives = 4;
            isAlive = true;
            setPosition();
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        private void setPosition()
        {
            position = new Vector2(screenWidth / 2 - entityWidth / 2, screenHeight - entityHeight);          
        }

        //deliverable = after player is hit, must respawn and gain invincibility for short time
        public void Update(GameTime gameTime)
        {
            if(isAlive == true)
            {            
                if(isInvincible == true && (float)gameTime.ElapsedGameTime.TotalSeconds == endTime)
                {
                    isInvincible = false;
                }          

                //for collision detection
                Bounds.X = (int)position.X;
                Bounds.Y = (int)position.Y;
            }
            else
            {
                //end game code here
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public int getLives()
        {
            return lives;
        }

        public void IsHit(GameTime gameTime) //activate cheat mode here
        {
            if(isCheating == false) 
            { 
                if(isInvincible == false)
                { 
                    lives -= 1;

                    if (lives == 0)
                        Die();

                 //   isInvincible = true;
                    endTime = (float)gameTime.ElapsedGameTime.TotalSeconds + 10;
                    setPosition();
                }
            }
        }

        public void Die()
        {
            isAlive = false;
        }

    }
}
