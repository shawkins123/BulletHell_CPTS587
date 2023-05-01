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
using System.Text;
using System.Xml.Linq;
using Microsoft.Xna.Framework.Media;
using System.Linq;

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
        private PowerupManager pm;
        private ShipFactory shipFactory;

        private Texture2D backgroundTexture;
        private Microsoft.Xna.Framework.Vector2 backgroundPos;
        private Texture2D weGotDeathStar;
        private Microsoft.Xna.Framework.Vector2 weGotDeathStarPos;

        private Texture2D ISD;
        private Texture2D blasterRed;

        float elapsedTime = 0;

        private Player player;

        private InputController inputController; 

        private int screenWidth;
        private int screenHeight;

        private HealthBar healthbar;

        public GameOver gameOver;
        private SpriteFont Arial;
        LevelFactory levelFactory = new LevelFactory();


        SoundManager soundManager;
        bool iKeyPressed = false;

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

            shipFactory = new ShipFactory(content);

            backgroundTexture = Content.Load<Texture2D>("Background");
            backgroundPos = new Microsoft.Xna.Framework.Vector2(0, 0);

            weGotDeathStar = Content.Load<Texture2D>("weGotDeathStar");
            weGotDeathStarPos = new Microsoft.Xna.Framework.Vector2(1220, 660);

            blasterRed = Content.Load<Texture2D>("blasterRed");
         
            screenWidth = GraphicsDevice.Viewport.Bounds.Width;
            screenHeight = GraphicsDevice.Viewport.Bounds.Height;
            ISD = Content.Load<Texture2D>("ISD");

          //  Arial = content.Load<SpriteFont>("Ariall");
          //  gameOver = new GameOver(screenHeight, screenWidth, Arial, spriteBatch, GraphicsDevice);

            player = new Player(ISD, screenWidth, screenHeight, gameOver);
            PlayerObserver observer = new PlayerObserver();
            player.Attach(observer);
            healthbar = new HealthBar(player, GraphicsDevice, screenHeight, screenWidth, 20);
            observer.setHealthBar(healthbar);
            healthbar.updateHealthBar();
            
            bulletManager = new BulletManager(player);
            inputController = new InputController(player, bulletManager, blasterRed);
            entityManager = new EntityManager(bulletManager); //MODIFIED
            pm = new PowerupManager(GraphicsDevice, player, entityManager);
            
            Song backgroundMusic = Content.Load<Song>("backgroundMusic");
            soundManager = new SoundManager(backgroundMusic);
        }

        protected override void Update(GameTime _gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here
            inputController.processControls(_gameTime);

            UpdateShips(_gameTime);

            elapsedTime += (float)_gameTime.ElapsedGameTime.TotalSeconds;

            entityManager.Update(_gameTime);
            bulletManager.Update(_gameTime);
            pm.Update(_gameTime);

            soundManager.Update(_gameTime);

            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.I))
            {
                iKeyPressed = true;
            }

            if (iKeyPressed)
            {
                player.addLife();
            }
            player.Update(_gameTime);


            base.Update(_gameTime);
        }

        private void UpdateShips(GameTime _gameTime)
        {
            foreach (Wave wave in levelFactory.waves)
            {
                if (wave.finished == false)
                {
                    for (int i = 0; i < wave.ships.Count; i++)
                    {

                        if (wave.activated[i] == false && elapsedTime > wave.entranceTime[i])
                        {
                            Ship myShip = shipFactory.assembleShip(wave.ships[i], wave.start_Y[i], wave.start_X[i], wave.movePattern[i], screenWidth, _gameTime, pm);
                            entityManager.AddShip(myShip);

                            wave.activated[i] = true;
                        }
                    }

                    if (wave.activated.All(x => x == true))
                    {
                        wave.finished = true;
                    }
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, backgroundPos, Color.White);
            spriteBatch.Draw(weGotDeathStar, weGotDeathStarPos, Color.White);
         
            player.Draw(spriteBatch);
            healthbar.Draw(spriteBatch);
           
            entityManager.Draw(spriteBatch);
            bulletManager.Draw(spriteBatch);
            pm.Draw(spriteBatch);
    
            if (!player.IsPlayerAlive())
            {
                //gameOver.Draw();
            }
 
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}