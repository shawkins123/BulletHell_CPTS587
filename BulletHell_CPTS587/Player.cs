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
    public class Player : ISubject
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

        private GameOver gameOver;

        private List<IObserver> _observers = new List<IObserver>();

        public Player(Texture2D texture, int inpScreenWidth, int inpScreenHeight, GameOver gameOver)
        {
            Texture = texture;

            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            screenHeight = inpScreenHeight;
            screenWidth = inpScreenWidth;
            lives = 4;
            isAlive = true;
            setPosition();
        //    this.gameOver = gameOver ?? throw new ArgumentNullException(nameof(gameOver), "Object cannot be null.");
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        private void setPosition()
        {
            position = new Vector2(screenWidth / 2 - entityWidth / 2, screenHeight - entityHeight);          
        }

        //deliverable = after player is hit, must respawn and gain invincibility for short time
        public void Update(GameTime gameTime)
        {
            playerTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
           

            //Debug.WriteLine("playerTimer =" + playerTimer);

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
                //end game code here
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public void IsHit(GameTime gameTime)
        {
            if(isInvincible == false)
            {               
                lives -= 1;
                this.Notify();

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
        public int getLives()
        {
            return lives;
        }

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void addLife()
        {
            if(lives <= 3)
            { 
                lives += 1;
                this.Notify();
            }

        }
    }
}
