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
    public class EnemyManager : IGameEntity
    {
        private const float g_p_Y = 500;
        private const float g_p_X = 500;

        private Sprite _enemySpriteA;
        private Sprite _enemySpriteB;

        public Vector2 Position
        {
            get { return Position; }
            set { Position = value; }
        }

        private const int spriteCoord = 0; 

        private Texture2D _spriteSheet;

        private readonly EntityManager _entityManager;

        private readonly List<Grunts> _enemySprites;

        private float enemySpeed;

        public float EnemySpeed { get; set; } = 150;

        public EnemyManager(Texture2D spriteSheet, EntityManager entityManager)
        {
            _spriteSheet = spriteSheet;
            _enemySprites = new List<Grunts>();
            _entityManager = entityManager;

            _enemySpriteA = new Sprite(spriteSheet, Grunts.GA_DEFAULT_SPRITE_X, Grunts.GA_DEFAULT_SPRITE_Y, Grunts.GA_DEFAULT_SPRITE_W, Grunts.GA_DEFAULT_SPRITE_H);
            _enemySpriteB = new Sprite(spriteSheet, Grunts.GB_DEFAULT_SPRITE_X, Grunts.GB_DEFAULT_SPRITE_Y, Grunts.GB_DEFAULT_SPRITE_W, Grunts.GB_DEFAULT_SPRITE_H);
        }


        public int drawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
    
        }

        public void Update(GameTime gameTime)
        {
            

            foreach (Grunts grunt in _enemySprites)
            {
                grunt.position.Y = 300;
                grunt.position.X = 300;

                grunt.position.Y += enemySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                grunt.position.X += enemySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            
        }

        public Vector2 SpawnPoint() //better to create a field/ getset for spawn points
        {
            Random random = new Random();

            int number = random.Next(3);

            Vector2 spawnPoint1 = new Vector2(100f, 10f);
            Vector2 spawnPoint2 = new Vector2(500f, 10f);
            Vector2 spawnPoint3 = new Vector2(300f, 10f);

            if (number == 0 || number == 1)
            {
                return spawnPoint1;
            }
            else if(number == 2)
            {
                return spawnPoint2;
            }
            else
            {
                return spawnPoint3;
            }
            
        }

        private Grunts CreateGruntA()
        {
            Grunts gruntA = new Grunts(SpawnPoint(), _enemySpriteA);
            return gruntA;
        }

        private Grunts CreateGruntB()
        {
            Grunts gruntB = new Grunts(SpawnPoint(), _enemySpriteB);
            return gruntB;
        }


        public void Initialize()
        {
            Grunts gruntA = CreateGruntA();
            _enemySprites.Add(gruntA);
            Grunts gruntB = CreateGruntB();
            _enemySprites.Add(gruntB);

            _entityManager.addEntity(gruntA);
            _entityManager.addEntity(gruntB);
        }
    }
}
