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

        public List<Bullet> Bullets;
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

            for (int i = Bullets.Count - 1; i >= 0; i--)
            {
                if (Bullets[i].Active == true)
                {
                    Bullets[i].Update(gameTime);

                    //find out if upper boundary of bullet touches upper boundary of player
                    if (Bullets[i].isPlayerBullet == false)
                    {
                        if (Bullets[i].Bounds.X >= player.Bounds.X &&
                        Bullets[i].Bounds.X <= player.Bounds.X + player.entityWidth)
                        {
                            if (Bullets[i].Bounds.Y >= player.Bounds.Y &&
                                Bullets[i].Bounds.Y <= player.Bounds.Y + player.entityHeight)
                                player.IsHit(gameTime);
                        }
                    }
                }
                else
                {
                    Bullets.RemoveAt(i);
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
