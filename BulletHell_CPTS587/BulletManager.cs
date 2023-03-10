using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS587.Entities
{
    public class BulletManager
    {

        private List<Bullet> Bullets;

        public BulletManager()
        {
            Bullets = new List<Bullet>();
        }

        public void AddEntity_Bullet(Bullet entity)
        {
            Bullets.Add(entity);
        }

        public void Update(GameTime gameTime)
        {

            foreach (Bullet entity in Bullets)
            {
                if (entity.Active == true)
                {
                    entity.Update(gameTime);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet entity in Bullets)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
