using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTS587.Entities
{
    public class EntityManager
    {
        private List<EnemyA> entitiesA;
        private List<BossA> BossA;
        private List<EnemyB> entitiesB;
        private List<BossB> BossB;
        private List<Bullet> Bullets;

        private BulletManager _bulletManager;

        Texture2D BlasterGreen;
        Texture2D BlasterBlue;

        public EntityManager(Texture2D green, Texture2D blue, BulletManager bulletManager)
        {
            entitiesA = new List<EnemyA>();
            BossA = new List<BossA>();
            entitiesB = new List<EnemyB>();
            BossB = new List<BossB>();
            Bullets = new List<Bullet>();

            _bulletManager = bulletManager;
            
            BlasterGreen = green;
            BlasterBlue = blue;
        }

        public void AddEntity_EnemyA(EnemyA entity)
        {
            entitiesA.Add(entity);
        }

        public void AddEntity_BossA(BossA entity)
        {
            BossA.Add(entity);
        }

        public void AddEntity_EnemyB(EnemyB entity)
        {
            entitiesB.Add(entity);
        }
        public void AddEntity_BossB(BossB entity)
        {
            BossB.Add(entity);
        }

        public void AddEntity_Bullet(Bullet entity)
        {
            Bullets.Add(entity);
        }

        public void Update(GameTime gameTime)
        {
            manageXwings(gameTime);

            manageBossA(gameTime);

            manageAWings(gameTime);

            manageBossB(gameTime);

            updateEntities(gameTime);
        }

        private void updateEntities(GameTime gameTime)
        {
            foreach (EnemyA entity in entitiesA)
            {
                if (entity.Active == true)
                {
                    entity.Update(gameTime);
                }
            }

            foreach (BossA entity in BossA)
            {
                if (entity.Active == true)
                {
                    entity.Update(gameTime);
                }
            }

            foreach (EnemyB entity in entitiesB)
            {
                if (entity.Active == true)
                {
                    entity.Update(gameTime);
                }
            }

            foreach (BossB entity in BossB)
            {
                if (entity.Active == true)
                {
                    entity.Update(gameTime);
                }
            }

            foreach (Bullet entity in Bullets)
            {
                if (entity.Active == true)
                {
                    entity.Update(gameTime);
                }
            }
        }

        private void manageBossB(GameTime gameTime)
        {
            for (int i = 0; i < BossB.Count; i++)
            {
                foreach (BossB entity in BossB)
                {
                    if (entity.bulletTimer >= entity.bulletInterval)
                    {
                        entity.bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                        Vector2 laserPosition = entity.position;

                        laserPosition.X -= 5;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterGreen, laserPosition, new Vector2(-5, 10)));

                        laserPosition.X += 10;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterGreen, laserPosition, new Vector2(5, 10)));

                        laserPosition.X -= 5;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterBlue, laserPosition, new Vector2(0, 3)));

                        laserPosition.X += 10;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterBlue, laserPosition, new Vector2(0, 3)));

                        entity.bulletTimer = 0;
                    }
                }

                if (!BossB[i].Active)
                {
                    BossB.RemoveAt(i);
                    i--;
                }
            }
        }

        private void manageAWings(GameTime gameTime)
        {
            for (int i = 0; i < entitiesB.Count; i++)
            {
                foreach (EnemyB entity in entitiesB)
                {
                    if (entity.bulletTimer >= entity.bulletInterval)
                    {
                        entity.bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterBlue, entity.position, new Vector2(0, 2)));
                        entity.bulletTimer = 0;
                    }
                }

                if (!entitiesB[i].Active)
                {
                    entitiesB.RemoveAt(i);
                    i--;
                }
            }
        }

        private void manageBossA(GameTime gameTime)
        {
            for (int i = 0; i < BossA.Count; i++)
            {

                foreach (BossA entity in BossA)
                {
                    if (entity.bulletTimer >= entity.bulletInterval)
                    {
                        entity.bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                        Vector2 laserPosition = entity.position;

                        laserPosition.X -= 5;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterGreen, laserPosition, new Vector2(0, 5)));

                        laserPosition.X += 10;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterGreen, laserPosition, new Vector2(0, 5)));

                        entity.bulletTimer = 0;
                    }
                }

                if (!BossA[i].Active)
                {
                    BossA.RemoveAt(i);
                    i--;
                }
            }
        }

        private void manageXwings(GameTime gameTime)
        {
            for (int i = 0; i < entitiesA.Count; i++)
            {
                foreach (EnemyA entity in entitiesA)
                {
                    if (entity.bulletTimer >= entity.bulletInterval)
                    {
                        entity.bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                        _bulletManager.AddEntity_Bullet(new Bullet(BlasterGreen, entity.position, new Vector2(0, 5)));
                        entity.bulletTimer = 0;
                    }
                }

                if (!entitiesA[i].Active)
                {
                    entitiesA.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (EnemyA entity in entitiesA)
            {
                entity.Draw(spriteBatch);
            }

            foreach (BossA entity in BossA)
            {
                entity.Draw(spriteBatch);
            }

            foreach (EnemyB entity in entitiesB)
            {
                entity.Draw(spriteBatch);
            }

            foreach (BossB entity in BossB)
            {
                entity.Draw(spriteBatch);
            }

            foreach (Bullet entity in Bullets)
            {
                entity.Draw(spriteBatch);
            }
        }
    }
}
