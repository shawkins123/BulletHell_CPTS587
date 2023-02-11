using BulletHell_CPTS587.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587.Entities
{
    public class Boss : IGameEntity
    {
        private Sprite sprite;
        public Vector2 position; //figure out way to set to private??
        public Vector2 Position { get; set; }
        public Sprite Sprite { get; }

        public const int MLB_DEFAULT_SPRITE_X = 40;
        public const int MLB_DEFAULT_SPRITE_Y = 48;
        public const int MLB_DEFAULT_SPRITE_W = 30;
        public const int MLB_DEFAULT_SPRITE_H = 22;

        public const int ELB_DEFAULT_SPRITE_X = 40;
        public const int ELB_DEFAULT_SPRITE_Y = 0;
        public const int ELB_DEFAULT_SPRITE_W = 30;
        public const int ELB_DEFAULT_SPRITE_H = 22;
        private EntityManager _entityManager = new EntityManager();
        public int drawOrder { get; set; }
        bool isAlive = true;
        private int spawnPoint;
        public int SpawnPoint { get; set; }

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public Boss(Vector2 position, Sprite sprite)
        {
            Position = position;
            Sprite = sprite;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            Sprite.Draw(spriteBatch, Position);
       }



    }
}
