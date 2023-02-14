using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CPTS587.Entities
{
    public class EnemyA
    {
        private ContentManager content;
        Vector2 position;
        public Texture2D Texture;
        Texture2D BulletTexture;
        public Rectangle Bounds;
        public Vector2 Velocity;
        float speed = 200.0f;
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
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (bulletTimer >= bulletInterval)
            {

                _bulletManager.AddEntity_Bullet(new Bullet(BulletTexture, position, new Vector2(0, 5)));

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
            if (Active == true)
            {
                spriteBatch.Draw(Texture, position, Color.White);
            }
            
        }

    }
}
