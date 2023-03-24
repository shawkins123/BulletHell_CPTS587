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
        private Player player;

        public BulletManager(Player player)
        {
            Bullets = new List<Bullet>();
            this.player = player;   
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
                    //find out if upper boundary of bullet touches upper boundary of player
                    if(entity.Bounds.X >= player.Bounds.X &&
                       entity.Bounds.X <= player.Bounds.X + player.entityWidth)
                    {
                        if (entity.Bounds.Y >= player.Bounds.Y &&
                            entity.Bounds.Y <= player.Bounds.Y + player.entityHeight)
                            player.IsHit(gameTime);
                    }
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
