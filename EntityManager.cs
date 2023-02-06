using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587.Entities
{
    public class EntityManager
    {
        private readonly List<IGameEntity> _entities = new List<IGameEntity>();
        private readonly List<IGameEntity> _entitiesToAdd = new List<IGameEntity>();
        private readonly List<IGameEntity> _entitiesToRemove = new List<IGameEntity>();

        public IEnumerable<IGameEntity> Entities => new ReadOnlyCollection<IGameEntity>(_entities);

        public void Update(GameTime gameTime)
        {
            foreach(IGameEntity entity in _entities)
            {
                entity.Update(gameTime);
            }

            foreach(IGameEntity entity in _entitiesToAdd)
            {
                _entities.Add(entity);
            }

            foreach (IGameEntity entity in _entitiesToRemove)
            {
                _entities.Remove(entity);
            }

            _entitiesToAdd.Clear();
            _entitiesToRemove.Clear();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (IGameEntity entity in _entities.OrderBy(e => e.drawOrder))
            {
                entity.Draw(spriteBatch, gameTime);
            }

        }
            public void addEntity(IGameEntity entity)
            {
                if(entity is null)
                {
              //      throw new ArgumentNullException(nameof(entity), "error");
                }

                _entitiesToAdd.Add(entity);
            }

            public void removeEntity(IGameEntity entity)
            {
                if (entity is null)
                {
                    throw new ArgumentNullException(nameof(entity), "error");
                }

                _entitiesToRemove.Add(entity);
            }

            public void Clear()
            {
                 _entitiesToRemove.AddRange(_entities);
            }
    }
}
