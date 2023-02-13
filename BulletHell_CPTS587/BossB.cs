﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CPTS587.Entities
{
    public class BossB
    {
        private ContentManager content;
        Vector2 position;
        public Texture2D Texture;
        Texture2D BulletTextureA;
        Texture2D BulletTextureB;
        public Rectangle Bounds;
        public Vector2 Velocity;
        float speed = 150.0f;
        int screenWidth;

        int entityWidth;
        int entityHeight;
        int direction; // 1 is right, 2 is left

        private double spawnTime;
        private double leaveTime;
        public bool Active = true;

        private BulletManager _bulletManager;
        private float bulletTimer;
        private float bulletInterval = 0.75f; // 1 second


        public BossB(Texture2D texture, Texture2D bulletTextureA, Texture2D bulletTextureB, BulletManager inpBulletManager, Vector2 inpPosition, int inpScreenWidth, GameTime gameTime)
        {
            this.Texture = texture;
            this.BulletTextureA = bulletTextureA;
            this.BulletTextureB = bulletTextureB;
            _bulletManager = inpBulletManager;


            position = inpPosition;
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);

            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            direction = 1;

            screenWidth = inpScreenWidth;
            spawnTime = gameTime.TotalGameTime.TotalSeconds;
            leaveTime = spawnTime + 20;
        }

        public BossB(ContentManager content)
        {
            LoadContent(content);
        }

        public void LoadContent(ContentManager content)
        {
            //this.texture = content.Load<Texture2D>("TextureName");
        }

        public void Update(GameTime gameTime)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (bulletTimer >= bulletInterval)
            {

                Vector2 laserPosition = position;

                laserPosition.X -= 5;
                _bulletManager.AddEntity_Bullet(new Bullet(BulletTextureA, laserPosition, new Vector2(-5, 10)));

                laserPosition.X += 10;
                _bulletManager.AddEntity_Bullet(new Bullet(BulletTextureA, laserPosition, new Vector2(5, 10)));

                laserPosition.X -= 5;
                _bulletManager.AddEntity_Bullet(new Bullet(BulletTextureB, laserPosition, new Vector2(0, 3)));

                laserPosition.X += 10;
                _bulletManager.AddEntity_Bullet(new Bullet(BulletTextureB, laserPosition, new Vector2(0, 3)));

                bulletTimer = 0;
            }

            float newX;

            if (direction == 1)
            {
                newX = position.X + speed * elapsedTime;
            }
            else
            {
                newX = position.X - speed * elapsedTime;
            }

            if (newX > (screenWidth - entityWidth))
            {
                direction = 0;
            }
            if (newX < 0)
            {
                direction = 1;
            }
            
            position.X = newX;


            //Position += Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Bounds.X = (int)position.X;
            Bounds.Y = (int)position.Y;

            double totalTime = gameTime.TotalGameTime.TotalSeconds;
            if (totalTime > leaveTime)
            {
                Active = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

    }
}