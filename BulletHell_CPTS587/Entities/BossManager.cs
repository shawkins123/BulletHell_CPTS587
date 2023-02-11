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
    public class BossManager : IGameEntity
    {
        private const float g_p_Y = 300;
        private const float g_p_X = 300;

        private Sprite _midLevelBoss;
        private Sprite _endLevelBoss;

        private Vector2 positionE;
        private Vector2 positionD;
        private Vector2 positionC;

        private Vector2 positionCStart;

        private float midPoint = 300f;
        public Vector2 Position { get; set; }

        private const int spriteCoord = 0;

        private Texture2D _spriteSheet;

        private readonly EntityManager _entityManager;

        private readonly List<Boss> _bossSprites;
        private readonly List<Boss> midLevelBoss;
        private readonly List<Boss> endLevelBoss;

        private float enemySpeed = 1f;

        private Random _random;

        private int max = 5;


        public float EnemySpeed { get; set; } = 150;

        public BossManager(Texture2D spriteSheet, EntityManager entityManager)
        {
            _spriteSheet = spriteSheet;
            _entityManager = entityManager;

            _bossSprites = new List<Boss>();
            midLevelBoss = new List<Boss>();
            endLevelBoss = new List<Boss>();

            _midLevelBoss = new Sprite(spriteSheet, Boss.MLB_DEFAULT_SPRITE_X, Boss.MLB_DEFAULT_SPRITE_Y, Boss.MLB_DEFAULT_SPRITE_W, Boss.MLB_DEFAULT_SPRITE_H);
            _endLevelBoss = new Sprite(spriteSheet, Boss.ELB_DEFAULT_SPRITE_X, Boss.ELB_DEFAULT_SPRITE_Y, Boss.ELB_DEFAULT_SPRITE_W, Boss.ELB_DEFAULT_SPRITE_H);

            _random = new Random();
        }


        public int drawOrder { get; set; }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        private Boss CreateMidLevelBoss()
        {
            Vector2 vector2 = new Vector2();

            Boss midLevelBoss = new Boss(vector2, _midLevelBoss);
            return midLevelBoss;
        }

        private Boss CreateEndLevelBoss()
        {
            Vector2 vector2 = new Vector2();

            Boss endLevelBoss = new Boss(vector2, _endLevelBoss);
            return endLevelBoss;
        }


        public void Initialize()
        {
            positionCStart.X = 500f;
            positionCStart.Y = 500f;

            spawnBoss();
            spawnMidLevelBoss();
            spawnEndLevelBoss();
        }

        //REMOVE POINT
        public async void Update(GameTime gameTime)
        {
            List<Boss> BossToRemove = new List<Boss>();

            if (_bossSprites.Count <= 1)
            {
                if (_bossSprites[0].position.Y > midPoint || _bossSprites[0].IsAlive == true) //need to figure out how to spawn when killed
                    spawnBoss();
            }
            else if (midLevelBoss.Count <= 1)
            {
                if (midLevelBoss[0].position.Y > midPoint || midLevelBoss[0].IsAlive == true) //need to figure out how to spawn when killed
                    spawnMidLevelBoss();
            }
            else if (endLevelBoss.Count <= 1)
            {
                if (endLevelBoss[0].position.X > midPoint || endLevelBoss[0].IsAlive == true) //need to figure out how to spawn when killed
                    spawnEndLevelBoss();
            }


            foreach (Boss _boss in _bossSprites)
            {
                updatePosition(gameTime, _boss);
                BossToRemove = assignPosition(gameTime, _boss, BossToRemove);
            }

            foreach (Boss _boss in BossToRemove)
            {
                _bossSprites.Remove(_boss);
            }

            foreach (Boss _boss in midLevelBoss)
            {
                updatePositionB(gameTime, _boss);
                BossToRemove = assignPositionB(gameTime, _boss, BossToRemove);
            }

            foreach (Boss _boss in BossToRemove)
            {
                midLevelBoss.Remove(_boss);
            }

            foreach (Boss _boss in endLevelBoss)
            {
                updatePositionC(gameTime, _boss);
                BossToRemove = assignPositionC(gameTime, _boss, BossToRemove);
            }

            foreach (Boss _boss in BossToRemove)
            {
                endLevelBoss.Remove(_boss);

            }

        }

        private void spawnBoss()
        {
            double randomNumber = _random.NextDouble();

            Boss _boss;

            if (randomNumber > .5)
            {
                _boss = CreateMidLevelBoss();
            }
            else
            {
                _boss = CreateEndLevelBoss();
            }

            _entityManager.addEntity(_boss);
            _bossSprites.Add(_boss);


        }

        private void spawnMidLevelBoss()
        {
            double randomNumber = _random.NextDouble();

            Boss _boss;

            if (randomNumber > .5)
            {
                _boss = CreateMidLevelBoss();
            }
            else
            {
                _boss = CreateEndLevelBoss();
            }

            _entityManager.addEntity(_boss);
            midLevelBoss.Add(_boss);
        }

        private void spawnEndLevelBoss()
        {
            double randomNumber = _random.NextDouble();

            Boss _boss;

            if (randomNumber > .5)
            {
                _boss = CreateMidLevelBoss();
            }
            else
            {
                _boss = CreateEndLevelBoss();
            }

            _entityManager.addEntity(_boss);
            endLevelBoss.Add(_boss);
        }

        public List<Boss> assignPosition(GameTime gameTime, Boss _boss, List<Boss> BossToRemove)
        {

            _boss.Position = positionE;

            if (positionE.X > 600 || positionE.Y > 600)
            {
                _entityManager.removeEntity(_boss);
                BossToRemove.Add(_boss);
            }

            return BossToRemove;
        }

        public void updatePosition(GameTime gameTime, Boss _boss)
        {

            _boss.position.X += enemySpeed / 2;
            _boss.position.Y += enemySpeed;

            positionE.X = _boss.position.X;
            positionE.Y = _boss.position.Y;
        }


        public List<Boss> assignPositionB(GameTime gameTime, Boss _boss,
                                       List<Boss> BossToRemove)
        {

            _boss.Position = positionD;

            if (positionD.X > 600 || positionD.Y > 600)
            {
                _entityManager.removeEntity(_boss);
                BossToRemove.Add(_boss);
            }

            return BossToRemove;
        }

        public void updatePositionB(GameTime gameTime, Boss _boss)
        {

            _boss.position.X += enemySpeed;
            _boss.position.Y += enemySpeed;

            positionD.X = positionCStart.X - _boss.position.X;
            positionD.Y = positionCStart.Y - _boss.position.Y;
        }


        public List<Boss> assignPositionC(GameTime gameTime, Boss _boss, List<Boss> BossToRemove)
        {

            _boss.Position = positionC;

            if (positionC.X > 600 || positionC.Y > 600)
            {
                _entityManager.removeEntity(_boss);
                BossToRemove.Add(_boss);
            }

            return BossToRemove;
        }

        public void updatePositionC(GameTime gameTime, Boss _boss)
        {

            _boss.position.X += enemySpeed/2;
            _boss.position.Y += enemySpeed;

            positionC.X = positionCStart.X - _boss.position.X;
            positionC.Y = positionCStart.Y - _boss.position.Y;
            //positionC.Y = _boss.position.Y;

        }
    }
}