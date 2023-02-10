using BulletHell_CPTS587.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587.Entities
{
    public class EnemyManager : IGameEntity
    {
        private const float g_p_Y = 300;
        private const float g_p_X = 300;

        private Sprite _enemySpriteA;
        private Sprite _enemySpriteB;

        private Vector2 positionE;
        private Vector2 positionD;
        private Vector2 positionC;

        private Vector2 positionCStart;

        private float midPoint = 300f;
        public Vector2 Position { get; set; }

        private const int spriteCoord = 0; 

        private Texture2D _spriteSheet;

        private readonly EntityManager _entityManager;

        private readonly List<Grunts> _enemySprites;
        private readonly List<Grunts> _enemySpritesB;
        private readonly List<Grunts> _enemySpritesC;

        private float enemySpeed = 1f;

        private Random _random;

        private int max = 5;


        public float EnemySpeed { get; set; } = 150;

        public EnemyManager(Texture2D spriteSheet, EntityManager entityManager)
        {
            _spriteSheet = spriteSheet;
            _enemySprites = new List<Grunts>();
            _enemySpritesB = new List<Grunts>();
            _enemySpritesC = new List<Grunts>();
            _entityManager = entityManager;

            _enemySpriteA = new Sprite(spriteSheet, Grunts.GA_DEFAULT_SPRITE_X, Grunts.GA_DEFAULT_SPRITE_Y, Grunts.GA_DEFAULT_SPRITE_W, Grunts.GA_DEFAULT_SPRITE_H);
            _enemySpriteB = new Sprite(spriteSheet, Grunts.GB_DEFAULT_SPRITE_X, Grunts.GB_DEFAULT_SPRITE_Y, Grunts.GB_DEFAULT_SPRITE_W, Grunts.GB_DEFAULT_SPRITE_H);

            _random = new Random();
        }


        public int drawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
   
        }

        private Grunts CreateGruntA()
        {
            Vector2 vector2 = new Vector2();

            Grunts gruntA = new Grunts(vector2, _enemySpriteA);
            return gruntA;
        }

        private Grunts CreateGruntB()
        {
            Vector2 vector2 = new Vector2();

            Grunts gruntB = new Grunts(vector2, _enemySpriteB);
            return gruntB;
        }


        public void Initialize()
        {
            positionCStart.X = 500f;
            positionCStart.Y = 0;

            spawnGrunt();
            spawnGruntB();
            spawnGruntC();
        }
        
        //REMOVE POINT
        public async void Update(GameTime gameTime)
        {
            List<Grunts> gruntsToRemove = new List<Grunts>();

            if(_enemySprites.Count <= 1)
            {
                if (_enemySprites[0].position.Y > midPoint || _enemySprites[0].IsAlive == true) //need to figure out how to spawn when killed
                    spawnGrunt();
            }
            else if (_enemySpritesB.Count <= 1)
            {
                if (_enemySpritesB[0].position.Y > midPoint || _enemySpritesB[0].IsAlive == true) //need to figure out how to spawn when killed
                    spawnGruntB();
            }
            else if (_enemySpritesC.Count <= 1)
            {
                if (_enemySpritesC[0].position.X > midPoint || _enemySpritesC[0].IsAlive == true) //need to figure out how to spawn when killed
                    spawnGruntC();
            }


            foreach (Grunts grunt in _enemySprites)
            {
                updatePosition(gameTime, grunt);
                gruntsToRemove = assignPosition(gameTime, grunt, gruntsToRemove);                   
            }

            foreach (Grunts grunt in gruntsToRemove)
            {
                _enemySprites.Remove(grunt);
            }

            foreach (Grunts grunt in _enemySpritesB)
            {
                updatePositionB(gameTime, grunt);
                gruntsToRemove = assignPositionB(gameTime, grunt, gruntsToRemove);
            }

            foreach (Grunts grunt in gruntsToRemove)
            {
                _enemySpritesB.Remove(grunt);
            }

            foreach (Grunts grunt in _enemySpritesC)
            {
                updatePositionC(gameTime, grunt);
                gruntsToRemove = assignPositionC(gameTime, grunt, gruntsToRemove);
            }

            foreach (Grunts grunt in gruntsToRemove)
            {
                _enemySpritesC.Remove(grunt);

            }

        }

        private void spawnGrunt()
        {
            double randomNumber = _random.NextDouble();

            Grunts grunt;

            if(randomNumber > .5)
            {
                grunt = CreateGruntA();
            }
            else
            {
                grunt = CreateGruntB(); 
            }

            _entityManager.addEntity(grunt);
            _enemySprites.Add(grunt);

           
        }

        private void spawnGruntB()
        {
            double randomNumber = _random.NextDouble();

            Grunts grunt;

            if (randomNumber > .5)
            {
                grunt = CreateGruntA();
            }
            else
            {
                grunt = CreateGruntB();
            }

            _entityManager.addEntity(grunt);
            _enemySpritesB.Add(grunt);
        }

        private void spawnGruntC()
        {
            double randomNumber = _random.NextDouble();

            Grunts grunt;

            if (randomNumber > .5)
            {
                grunt = CreateGruntA();
            }
            else
            {
                grunt = CreateGruntB();
            }

            _entityManager.addEntity(grunt);
            _enemySpritesC.Add(grunt);
        }

        public List<Grunts> assignPosition(GameTime gameTime, Grunts grunt,
                                           List<Grunts> gruntsToRemove)
        {

            grunt.Position = positionE;

            if (positionE.X > 600 || positionE.Y > 600 )
            {
                _entityManager.removeEntity(grunt);
                gruntsToRemove.Add(grunt);
            }

            return gruntsToRemove;
        }

        public void updatePosition(GameTime gameTime, Grunts grunt)
        {

            grunt.position.X += enemySpeed / 2;
            grunt.position.Y += enemySpeed;

            positionE.X = grunt.position.X;
            positionE.Y = grunt.position.Y;
        }


        public List<Grunts> assignPositionB(GameTime gameTime, Grunts grunt,
                                       List<Grunts> gruntsToRemove)
        {

            grunt.Position = positionD;

            if (positionD.X > 600 || positionD.Y > 600)
            {
                _entityManager.removeEntity(grunt);
                gruntsToRemove.Add(grunt);
            }

            return gruntsToRemove;
        }

        public void updatePositionB(GameTime gameTime, Grunts grunt)
        {

            grunt.position.X += enemySpeed;
            grunt.position.Y += enemySpeed;

            positionD.X = grunt.position.X;
            positionD.Y = grunt.position.Y;
        }


        public List<Grunts> assignPositionC(GameTime gameTime, Grunts grunt,
                                      List<Grunts> gruntsToRemove)
        {
                 
            grunt.Position = positionC;

            if (positionC.X > 600 || positionC.Y > 600)
            {
                _entityManager.removeEntity(grunt);
                gruntsToRemove.Add(grunt);
            }

            return gruntsToRemove;
        }

        public void updatePositionC(GameTime gameTime, Grunts grunt)
        {

            grunt.position.X += enemySpeed;
            grunt.position.Y += enemySpeed/2;

            positionC.X = positionCStart.X - grunt.position.X;
            positionC.Y = grunt.position.Y;

        }
    }
}
