using BulletHell_CPTS587.System;
using CPTS587.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Numerics;


namespace CPTS587
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;
        private EntityManager entityManager;
        private BulletManager bulletManager;
        private ContentManager content;
        private GameTime _gameTime;

        private Texture2D backgroundTexture;
        private Microsoft.Xna.Framework.Vector2 backgroundPos;
        private Texture2D weGotDeathStar;
        private Microsoft.Xna.Framework.Vector2 weGotDeathStarPos;

        private Texture2D ISD;
        private Texture2D xWing;
        private Texture2D bossATexture;
        private Texture2D aWing;
        private Texture2D rebelScum;
        private Texture2D blasterGreen;
        private Texture2D blasterBlue;

        float elapsedTime = 0;

        private Player player;
        private EnemyA enemyA;
        private EnemyB enemyB;

        private InputController inputController; 

        private int screenWidth;
        private int screenHeight;

        bool xWingActive_1 = false;
        bool xWingActive_2 = false;
        bool xWingActive_3 = false;

        bool bossActive_A = false;

        bool aWingActive_1 = false;
        bool aWingActive_2 = false;
        bool aWingActive_3 = false;

        bool bossActive_B = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 1360;
            _graphics.PreferredBackBufferHeight = 768;
            _graphics.ApplyChanges();

            base.Initialize();


        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            content = new ContentManager(Services, "Content");

            backgroundTexture = Content.Load<Texture2D>("Background");
            backgroundPos = new Microsoft.Xna.Framework.Vector2(0, 0);

            weGotDeathStar = Content.Load<Texture2D>("weGotDeathStar");
            weGotDeathStarPos = new Microsoft.Xna.Framework.Vector2(1220, 660);

            blasterGreen = Content.Load<Texture2D>("blasterGreen");
            blasterBlue = Content.Load<Texture2D>("blasterBlue");

            bulletManager = new BulletManager();
            entityManager = new EntityManager(blasterGreen, blasterBlue, bulletManager); //MODIFIED


            // load the player
            screenWidth = GraphicsDevice.Viewport.Bounds.Width;
            screenHeight = GraphicsDevice.Viewport.Bounds.Height;
            ISD = Content.Load<Texture2D>("ISD");

            player = new Player(ISD, screenWidth, screenHeight);
            inputController = new InputController(player, bulletManager);

            xWing = Content.Load<Texture2D>("xWing");
            bossATexture = Content.Load<Texture2D>("BossA");
            aWing = Content.Load<Texture2D>("AWing");
            rebelScum = Content.Load<Texture2D>("BossB");

            
            
        }

        protected override void Update(GameTime _gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            inputController.processControls(_gameTime);

            if (elapsedTime > 2 && xWingActive_1 != true)
            {
                entityManager.AddEntity_EnemyA(new EnemyA(xWing, blasterGreen, new Microsoft.Xna.Framework.Vector2(0, 250), screenWidth, _gameTime));
                xWingActive_1 = true;
            }
            if (elapsedTime > 3 && xWingActive_2 != true)
            {
                entityManager.AddEntity_EnemyA(new EnemyA(xWing, blasterGreen, new Microsoft.Xna.Framework.Vector2(0, 200), screenWidth, _gameTime));
                xWingActive_2 = true;
            }
            if (elapsedTime > 4 && xWingActive_3 != true)
            {
                entityManager.AddEntity_EnemyA(new EnemyA(xWing, blasterGreen, new Microsoft.Xna.Framework.Vector2(0, 150), screenWidth, _gameTime));
                xWingActive_3 = true;
            }


            if (elapsedTime > 5 && bossActive_A != true)
            {
                entityManager.AddEntity_BossA(new BossA(bossATexture, blasterGreen, new Microsoft.Xna.Framework.Vector2(screenWidth, 25), screenWidth, _gameTime));
                bossActive_A = true;
            }


            if (elapsedTime > 10 && aWingActive_1 != true)
            {
                entityManager.AddEntity_EnemyB(new EnemyB(aWing, blasterBlue, new Microsoft.Xna.Framework.Vector2(screenWidth, 380), screenWidth, _gameTime));
                aWingActive_1 = true;
            }
            if (elapsedTime > 11 && aWingActive_2 != true)
            {
                entityManager.AddEntity_EnemyB(new EnemyB(aWing, blasterBlue, new Microsoft.Xna.Framework.Vector2(screenWidth, 340), screenWidth, _gameTime));
                aWingActive_2 = true;
            }
            if (elapsedTime > 12 && aWingActive_3 != true)
            {
                entityManager.AddEntity_EnemyB(new EnemyB(aWing, blasterBlue, new Microsoft.Xna.Framework.Vector2(screenWidth, 300), screenWidth, _gameTime));
                aWingActive_3 = true;
            }


            if (elapsedTime > 20 && bossActive_B != true)
            {
                entityManager.AddEntity_BossB(new BossB(rebelScum, blasterGreen, blasterBlue, new Microsoft.Xna.Framework.Vector2(0, 50), screenWidth, _gameTime));
                bossActive_B = true;
            }

            elapsedTime += (float)_gameTime.ElapsedGameTime.TotalSeconds;

            entityManager.Update(_gameTime);
            bulletManager.Update(_gameTime);

            player.Update(_gameTime);

            base.Update(_gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            


            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, backgroundPos, Color.White);
            spriteBatch.Draw(weGotDeathStar, weGotDeathStarPos, Color.White);
            

            //spriteBatch.Draw(SpaceShip, new Rectangle(0, 0, 100, 100), Color.White);

            player.Draw(spriteBatch);
            //enemyA.Draw(spriteBatch);

            entityManager.Draw(spriteBatch);
            bulletManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}