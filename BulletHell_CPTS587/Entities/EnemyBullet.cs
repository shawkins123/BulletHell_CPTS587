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
    public class EnemyBullet
    {
            private Sprite sprite;

            public const int EB_DEFAULT_SPRITE_X = 0;
            public const int EB_DEFAULT_SPRITE_Y = 112;
            public const int EB_DEFAULT_SPRITE_W = 8;
            public const int EB_DEFAULT_SPRITE_H = 8;

            public Sprite Sprite
            {
                get { return sprite; }
                private set { sprite = value; }
            }

            private float speed;

            public float Speed
            {
                get { return Speed; }
                set { Speed = value; }
            }

            public Vector2 position; //find a way to make this private??

            public Vector2 Position
            {
                get { return position; }
                set { position = value; }
            }

            private bool isAlive;

            public bool IsAlive
            {
                get { return isAlive; }
            }

            public EnemyBullet(Texture2D _spriteSheetTexture, Vector2 position)
            {
                Sprite = new Sprite(_spriteSheetTexture, EB_DEFAULT_SPRITE_X, EB_DEFAULT_SPRITE_Y, EB_DEFAULT_SPRITE_W, EB_DEFAULT_SPRITE_H);
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
    }
}
