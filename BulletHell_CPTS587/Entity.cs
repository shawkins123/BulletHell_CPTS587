using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BulletHell_CPTS587;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace CPTS587.Entities
{

    public interface Entity
    {
        int getHealth();
        void takeDamage(int amount);
    }

    public class Ship : Entity
    {
        private List<Laser> Lasers = new List<Laser>();
        private int shipHealth;
        private string shipName;


        public Microsoft.Xna.Framework.Vector2 position; //set to private
        public float elapsedTime; //set to private
        public Texture2D Texture;
        public Rectangle Bounds;


        public Microsoft.Xna.Framework.Vector2 Velocity;
        public float speed = 200.0f; //set to private
        int screenWidth;

        public int entityWidth;
        public int entityHeight;
        int direction; // 1 is right, 2 is left
        private double spawnTime;
        private double leaveTime;
        public bool Active = true;

        private float zigZag = 0.0f;
        private float zigTime = 0;
        bool moveUp = false;

        private Movement _movement;


        public Ship(int health, string name, Texture2D texture, Microsoft.Xna.Framework.Vector2 inpPosition, int inpScreenWidth, GameTime gameTime, float zigZag = 0.0f)
        {
            this.Texture = texture;
            this.shipHealth = health;
            this.shipName = name;

            position = inpPosition;
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);

            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            direction = 1;

            screenWidth = inpScreenWidth;
            spawnTime = gameTime.TotalGameTime.TotalSeconds;
            leaveTime = spawnTime + 10;

            Movement movement = new Movement();

            _movement = movement;
            this.zigZag = zigZag;
            
        }

        public void AddLaser(Laser laser)
        {
            Lasers.Add(laser);
        }

        public void RemoveLaser(Laser item)
        {
            Lasers.Remove(item);
        }

        public int getHealth()
        {
            int totalHealth = shipHealth;
            foreach (Laser item in Lasers)
            {
                totalHealth += item.getHealth();
            }
            return totalHealth;
        }

        public void takeDamage(int inpDamage)
        {
            int currDamage = inpDamage;

            // while current damage is greater than zero AND lasers are more than zero
            // we use AND here so that if currDamage > 0 and laser count < 0, it bypasses the while
            while (Lasers.Count > 0 && currDamage > 0) 
            {

                Random rand = new Random();

                // Choose a random item from the list
                Laser randomLaser = Lasers[rand.Next(Lasers.Count)];

                if (randomLaser.getHealth() > 0)
                {

                    if (currDamage >= randomLaser.getHealth())
                    {
                        currDamage -= randomLaser.getHealth();
                        RemoveLaser(randomLaser);
                    }
                    else
                    {
                        randomLaser.takeDamage(currDamage);
                        return;
                    }
                }
            }

            for (int i = 0; i < Lasers.Count; i++)
            {
                if (Lasers[i].getHealth() > 0)
                {

                    if (currDamage >= Lasers[i].getHealth())
                    {
                        currDamage -= Lasers[i].getHealth();
                        RemoveLaser(Lasers[i]);
                        i--;
                    }
                    else
                    {
                        Lasers[i].takeDamage(currDamage);
                        return;
                    }
                }
            }
            shipHealth -= currDamage;

            if (shipHealth <= 0)
            {
                Active = false;
            }
        }

        public void Update(GameTime gameTime, BulletManager _bulletManager)
        {
            elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _movement.updatePosition(position, elapsedTime, speed);
            move(gameTime);

            Bounds.X = (int)position.X;
            Bounds.Y = (int)position.Y;


            // shoot lasers!!!!
            if (Lasers.Count > 0)
            {
                foreach (Laser laser in Lasers)
                {
                    laser.update(gameTime, position, _bulletManager);
                }
            }

            double totalTime = gameTime.TotalGameTime.TotalSeconds;
            if (totalTime > leaveTime)
            {
                Active = false;
            }
        }

        private void move(GameTime gameTime)
        {
            if (direction == 1)
                position.X = _movement.moveRight(position.X);
            else
                position.X = _movement.moveLeft(position.X);

            if (position.X > screenWidth - entityWidth)
                direction = 2;
            else if (position.X < entityWidth)
                direction = 1;

            if (zigZag > 0)
            {
                zigTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (zigTime > zigZag)
                {
                    if (moveUp == false)
                    {
                        moveUp = true;
                    }
                    else
                    {
                        moveUp = false;
                    }

                    zigTime = 0;
                }

                if (moveUp == true)
                {
                    position.Y = _movement.moveUp(position.Y);
                }
                else
                {
                    position.Y = _movement.moveDown(position.Y);
                }

            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active == true)
            {
                spriteBatch.Draw(Texture, position, Color.White);
            }

        }
    }

    [Serializable]
    public class Laser : Entity
    {
        private int laserHealth; // health of the laser
        private string laserName; //  name of the laser
        Texture2D LaserTexture; // texture to use for the laser

        //TODO: Make one timer in the entity manager and pass it by reference?
        public float bulletTimer; // timer for the laser to keep track of current game time
        public float bulletInterval; // how often the laser fires, 1.0f is 1 second
        Microsoft.Xna.Framework.Vector2 laserPosition; // location of laser on entity
        Microsoft.Xna.Framework.Vector2 laserVector; // direction of laser fire
        bool PlayerLaser = false; // whether the laser belongs to the player or not
        float laserDelay = 0;
        float beginTime = 0;

        public Laser(int health, 
            string name, 
            Texture2D laserTexture, 
            float bulletInterval, 
            Microsoft.Xna.Framework.Vector2 laserPosition,
            Microsoft.Xna.Framework.Vector2 laserVector,
            bool PlayerLaser,
            float LaserDelay = 0
            )
        {
            this.laserHealth = health;
            this.laserName = name;
            this.LaserTexture = laserTexture;
            this.bulletInterval = bulletInterval;
            this.laserPosition = laserPosition;
            this.laserVector = laserVector;
            this.PlayerLaser = PlayerLaser;
            this.laserDelay = LaserDelay;
        }

        public int getHealth()
        {
            return laserHealth;
        }

        public void update(GameTime gameTime, Microsoft.Xna.Framework.Vector2 position, BulletManager _bulletManager)
        {
            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (laserDelay > 0)
            {
                if (bulletTimer > laserDelay)
                {
                    laserDelay = 0;
                    bulletTimer = 0;
                }
                else
                {
                    return;
                }
            }

            Microsoft.Xna.Framework.Vector2 laserFirePos = new Microsoft.Xna.Framework.Vector2(position.X + laserPosition.X, position.Y + laserPosition.Y);

            if (bulletTimer >= bulletInterval)
            {
                _bulletManager.AddEntity_Bullet(new Bullet(LaserTexture, laserFirePos, laserVector, PlayerLaser));
                bulletTimer = 0;
            }
        }

        public string GetName()
        {
            return laserName;
        }

        public void takeDamage(int amount)
        {
            laserHealth -= amount;
        }
    }

}