﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletHell_CPTS587;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CPTS587.Entities
{
    public class EnemyA
    {
        private ContentManager content;
        public Vector2 position; //set to private
        public float elapsedTime; //set to private
        public Texture2D Texture;
        Texture2D BulletTexture;
        public Rectangle Bounds;
        public Vector2 Velocity;
        public float speed = 200.0f; //set to private
        int screenWidth;

        int entityWidth;
        int entityHeight;
        int direction; // 1 is right, 2 is left
        private double spawnTime;
        private double leaveTime;
        public bool Active = true;

        private BulletManager _bulletManager;
        private float bulletTimer;
        private float bulletInterval = 1.0f; // 1 second

        private Movement _movement;


        public EnemyA(Texture2D texture, Texture2D bulletTexture, BulletManager inpBulletManager, Vector2 inpPosition, int inpScreenWidth, GameTime gameTime)
        {
            this.Texture = texture;
            this.BulletTexture = bulletTexture;
            _bulletManager = inpBulletManager;

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
        }

        public EnemyA(ContentManager content)
        {
            LoadContent(content);
        }

        public void LoadContent(ContentManager content)
        {
            //this.texture = content.Load<Texture2D>("TextureName");
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (bulletTimer >= bulletInterval)
            {

                _bulletManager.AddEntity_Bullet(new Bullet(BulletTexture, position, new Vector2(0, 5)));

                bulletTimer = 0;
            }


            _movement.updatePosition(position, elapsedTime, speed);
            move();

            Bounds.X = (int)position.X;
            Bounds.Y = (int)position.Y;

            double totalTime = gameTime.TotalGameTime.TotalSeconds;
            if (totalTime > leaveTime)
            {
                Active = false;
            }
        }

        private void move()
        {
            if (direction == 1)
                position.X = _movement.moveRight(position.X);
            else
                position.X = _movement.moveLeft(position.X);

            if (position.X > screenWidth - entityWidth)
                direction = 2;
            else if (position.X < entityWidth)
                direction = 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (Active == true)
            {
                spriteBatch.Draw(Texture, position, Color.White);
            }
            
        }

    }
}
