using BulletHell_CPTS587;
using BulletHell_CPTS587.System;
using CPTS587.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Xml.Linq;

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

        private HealthBar healthbar;


        public GameOver gameOver;
        private SpriteFont Arial;

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
            

            // load the player
            screenWidth = GraphicsDevice.Viewport.Bounds.Width;
            screenHeight = GraphicsDevice.Viewport.Bounds.Height;
            ISD = Content.Load<Texture2D>("ISD");

            Arial = content.Load<SpriteFont>("Ariall");
            gameOver = new GameOver(screenHeight, screenWidth, Arial, spriteBatch, GraphicsDevice);

            player = new Player(ISD, screenWidth, screenHeight, healthbar, gameOver);
            healthbar = new HealthBar(player, GraphicsDevice);
            bulletManager = new BulletManager(player);
            inputController = new InputController(player, bulletManager, blasterGreen);
            entityManager = new EntityManager(bulletManager); //MODIFIED


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
                Ship myShip = ShipFactory.createShip(25, "T-65B X-wing", xWing, new Microsoft.Xna.Framework.Vector2(0, 350), screenWidth, _gameTime, 0.75f);
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(-5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                entityManager.AddShip(myShip);

                xWingActive_1 = true;
            }

            if (elapsedTime > 3 && xWingActive_2 != true)
            {
                Ship myShip = ShipFactory.createShip(25, "T-65B X-wing", xWing, new Microsoft.Xna.Framework.Vector2(0, 300), screenWidth, _gameTime, 0.75f);
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(-5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                entityManager.AddShip(myShip);

                xWingActive_2 = true;
            }

            if (elapsedTime > 4 && xWingActive_3 != true)
            {
                Ship myShip = ShipFactory.createShip(25, "T-65B X-wing", xWing, new Microsoft.Xna.Framework.Vector2(0, 250), screenWidth, _gameTime, 0.75f);
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(-5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                entityManager.AddShip(myShip);

                xWingActive_3 = true;
            }


            if (elapsedTime > 5 && bossActive_A != true)
            {
                Ship myShip = ShipFactory.createShip(25, "Frigate", bossATexture, new Microsoft.Xna.Framework.Vector2(0, 25), screenWidth, _gameTime);
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(-5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(-5, 5));
                ShipFactory.AddLaser(myShip, 25, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(5, 5));
                entityManager.AddShip(myShip);

                bossActive_A = true;
            }


            if (elapsedTime > 10 && aWingActive_1 != true)
            {
                Ship myShip = ShipFactory.createShip(25, "RZ-1 A-wing", aWing, new Microsoft.Xna.Framework.Vector2(0, 480), screenWidth, _gameTime, 0.25f);
                ShipFactory.AddLaser(myShip, 10, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(-3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                ShipFactory.AddLaser(myShip, 10, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                entityManager.AddShip(myShip);

                aWingActive_1 = true;
            }
            if (elapsedTime > 11 && aWingActive_2 != true)
            {
                Ship myShip = ShipFactory.createShip(25, "RZ-1 A-wing", aWing, new Microsoft.Xna.Framework.Vector2(0, 440), screenWidth, _gameTime, 0.35f);
                ShipFactory.AddLaser(myShip, 10, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(-3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                ShipFactory.AddLaser(myShip, 10, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                entityManager.AddShip(myShip);
                aWingActive_2 = true;
            }
            if (elapsedTime > 12 && aWingActive_3 != true)
            {
                Ship myShip = ShipFactory.createShip(25, "RZ-1 A-wing", aWing, new Microsoft.Xna.Framework.Vector2(0, 400), screenWidth, _gameTime, 0.45f);
                ShipFactory.AddLaser(myShip, 10, "Borstel RG-9 Laser cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(-3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                ShipFactory.AddLaser(myShip, 10, "Borstel RG-9 Laser cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                entityManager.AddShip(myShip);
                aWingActive_3 = true;
            }


            if (elapsedTime > 20 && bossActive_B != true)
            {
                Ship myShip = ShipFactory.createShip(25, "MC80-A Star Cruiser", rebelScum, new Microsoft.Xna.Framework.Vector2(0, 50), screenWidth, _gameTime);
                
                ShipFactory.AddLaser(myShip, 50, "KX9 Laser Cannon", blasterGreen, 1.0f, new Microsoft.Xna.Framework.Vector2(0, 75), new Microsoft.Xna.Framework.Vector2(6.0f, 4.0f), false, 0.25f);
                ShipFactory.AddLaser(myShip, 50, "KX9 Laser Cannon", blasterGreen, 1.0f, new Microsoft.Xna.Framework.Vector2(50, 75), new Microsoft.Xna.Framework.Vector2(4.0f, 4.75f), false, 0.5f);
                ShipFactory.AddLaser(myShip, 50, "KX9 Laser Cannon", blasterGreen, 1.0f, new Microsoft.Xna.Framework.Vector2(-5, 150), new Microsoft.Xna.Framework.Vector2(2.0f, 5.25f), false, 0.75f);
                ShipFactory.AddLaser(myShip, 50, "KX9 Laser Cannon", blasterGreen, 1f, new Microsoft.Xna.Framework.Vector2(25, 100), new Microsoft.Xna.Framework.Vector2(0.0f, 6.0f), false, 1.0f);

                ShipFactory.AddLaser(myShip, 100, "KX9 Laser Cannon", blasterBlue, 0.75f, new Microsoft.Xna.Framework.Vector2(10, 230), new Microsoft.Xna.Framework.Vector2(0, 2));
                ShipFactory.AddLaser(myShip, 100, "KX9 Laser Cannon", blasterBlue, 0.75f, new Microsoft.Xna.Framework.Vector2(20, 230), new Microsoft.Xna.Framework.Vector2(0, 2));




                entityManager.AddShip(myShip);


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
            healthbar.Draw(spriteBatch);
            //enemyA.Draw(spriteBatch);

            entityManager.Draw(spriteBatch);
            bulletManager.Draw(spriteBatch);

   
            if (!player.IsPlayerAlive())
            {
                gameOver.Draw();
            }
 


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}