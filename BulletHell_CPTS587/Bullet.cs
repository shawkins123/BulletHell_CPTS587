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
    public class Bullet
    {
        private ContentManager content;
        Vector2 position;
        public Texture2D Texture;
        public Rectangle Bounds;
        public Vector2 velocity;
        float speed = 400.0f;
        int screenWidth;

        int entityWidth;
        int entityHeight;
        int direction; // 1 is right, 2 is left

        private double spawnTime;
        private double leaveTime;
        public bool Active = true;


        public Bullet(Texture2D texture, Vector2 inpPosition, Vector2 inpVelocity)
        {
            this.Texture = texture;
            position = inpPosition;
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);

            entityWidth = Texture.Width;
            entityHeight = Texture.Height;
            direction = 1;
            this.velocity = inpVelocity;

        }

        public Bullet(ContentManager content)
        {
            LoadContent(content);
        }

        public void LoadContent(ContentManager content)
        {
            //this.texture = content.Load<Texture2D>("TextureName");
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;

            Bounds.X = (int)position.X;
            Bounds.Y = (int)position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

    }
}
