using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using CPTS587.Entities;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using BulletHell_CPTS587;
using System.Diagnostics;

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
        public int Lives { get; set;}

        private float endTime;
        public float playerTimer;

        //   private HealthBar healthBar;
        private GameOver gameOver;

        public Player(Texture2D texture, int inpScreenWidth, int inpScreenHeight, HealthBar healthBarInput, GameOver gameOver)
        {
            Texture = texture;

            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            screenHeight = inpScreenHeight;
            screenWidth = inpScreenWidth;
            lives = 4;
            isAlive = true;
            setPosition();
            //      healthBar = healthBarInput;
            this.gameOver = gameOver ?? throw new ArgumentNullException(nameof(gameOver), "Object cannot be null.");
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        private void setPosition()
        {
     //       healthBar.setupHealthBar();
            position = new Vector2(screenWidth / 2 - entityWidth / 2, screenHeight - entityHeight);          
        }

        //deliverable = after player is hit, must respawn and gain invincibility for short time
        public void Update(GameTime gameTime)
        {
            playerTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            Debug.WriteLine("playerTimer =" + playerTimer);

            if (isAlive == true)
            {            
                if(isInvincible == true && playerTimer >= endTime)
                {
                    isInvincible = false;
                    playerTimer = 0;
                }          

                //for collision detection
                Bounds.X = (int)position.X;
                Bounds.Y = (int)position.Y;
            }
            else
            {
                // Not able to draw the text when calling from here. 
                //gameOver.Draw();

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public void IsHit(GameTime gameTime)
        {
            if (isInvincible == false)
            { 
                lives -= 1;
                Debug.WriteLine ("lives = " + lives);

                if (lives == 0)
                    Die();

                isInvincible = true;
                endTime = (float)gameTime.ElapsedGameTime.TotalSeconds + 10;
                setPosition();
            }
        }

        public void Die()
        {
            isAlive = false;
        }

        public bool IsPlayerAlive()
        {
            return isAlive;
        }

    }
}
