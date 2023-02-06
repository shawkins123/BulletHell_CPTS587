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
    public class Grunts : IGameEntity
    {
        private Sprite sprite;
        public Vector2 position; //figure out way to set to private??
        public Vector2 Position { get; set; }
        public Sprite Sprite { get; }

        public const int GA_DEFAULT_SPRITE_X = 70;
        public const int GA_DEFAULT_SPRITE_Y = 40;
        public const int GA_DEFAULT_SPRITE_W = 20;
        public const int GA_DEFAULT_SPRITE_H = 15;

        public const int GB_DEFAULT_SPRITE_X = 70;
        public const int GB_DEFAULT_SPRITE_Y = 0;
        public const int GB_DEFAULT_SPRITE_W = 18;
        public const int GB_DEFAULT_SPRITE_H = 15;
        public int drawOrder { get; set; } 

        public Grunts(Vector2 position, Sprite sprite)
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


        /*
        public const int GA_DEFAULT_SPRITE_X = 70;
        public const int GA_DEFAULT_SPRITE_Y = 40;
        public const int GA_DEFAULT_SPRITE_W = 20;
        public const int GA_DEFAULT_SPRITE_H = 15;

        private float speed;

        public float Speed
        {
            get { return Speed; }
            set { Speed = value; }
        }

        private bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
        }

        public GruntA(Texture2D _spriteSheetTexture, Vector2 position)
        {
            Sprite = new Sprite(_spriteSheetTexture, GA_DEFAULT_SPRITE_X, GA_DEFAULT_SPRITE_Y, GA_DEFAULT_SPRITE_W, GA_DEFAULT_SPRITE_H);
            Position = position;
        }

     
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Sprite.Draw(spriteBatch, this.Position);
        }

        public int drawOrder => throw new NotImplementedException();
        public int DrawOrder { get; set; }
        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public bool Die()
        {

            return false;
        }
        */

    }
}
