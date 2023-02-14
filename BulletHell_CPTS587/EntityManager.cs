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

        public EntityManager()
        {
            entitiesA = new List<EnemyA>();
            BossA = new List<BossA>();
            entitiesB = new List<EnemyB>();
            BossB = new List<BossB>();
            Bullets = new List<Bullet>();
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

            for (int i = 0; i < entitiesA.Count; i++)
            {
                if (!entitiesA[i].Active)
                {
                    entitiesA.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < BossA.Count; i++)
            {
                if (!BossA[i].Active)
                {
                    BossA.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < entitiesB.Count; i++)
            {
                if (!entitiesB[i].Active)
                {
                    entitiesB.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < BossB.Count; i++)
            {
                if (!BossB[i].Active)
                {
                    BossB.RemoveAt(i);
                    i--;
                }
            }


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
