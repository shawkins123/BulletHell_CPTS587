using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Net.NetworkInformation;

namespace CPTS587.Entities
{
    public class EntityManager
    {
        private List<Ship> ShipList = new List<Ship>();
        private List<Bullet> Bullets;

        private BulletManager _bulletManager;

        public EntityManager(BulletManager bulletManager)
        {
            _bulletManager = bulletManager;
        }

        public void AddShip(Ship ship)
        {
            ShipList.Add(ship);
        }

        public void AddEntity_Bullet(Bullet entity)
        {
            Bullets.Add(entity);
        }

        public void Update(GameTime gameTime)
        {
            manageShips(gameTime);
        }

        private void manageShips(GameTime gameTime)
        {
            for (int i = 0; i < ShipList.Count; i++)
            {
                if (ShipList[i].Active == true)
                {
                    foreach (Bullet bullet in _bulletManager.Bullets)
                    {
                        if (bullet.Active == true)
                        {

                            //find out if any player bullets hit enemies
                            if (bullet.isPlayerBullet == true)
                            {
                                if (bullet.Bounds.X >= ShipList[i].Bounds.X &&
                                bullet.Bounds.X <= ShipList[i].Bounds.X + ShipList[i].entityWidth)
                                {
                                    if (bullet.Bounds.Y >= ShipList[i].Bounds.Y &&
                                        bullet.Bounds.Y <= ShipList[i].Bounds.Y + ShipList[i].entityHeight)
                                    {
                                        //ShipList[i].isHit();
                                        ShipList[i].takeDamage(25);
                                        bullet.Active = false;
                                    }

                                }
                            }

                        }
                    }

                    ShipList[i].Update(gameTime, _bulletManager);
                }

                else
                {
                    ShipList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            foreach (Ship ship in ShipList)
            {
                ship.Draw(spriteBatch);
            }

            foreach (Bullet entity in _bulletManager.Bullets)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
