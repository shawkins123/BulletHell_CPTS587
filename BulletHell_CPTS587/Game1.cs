using BulletHell_CPTS587.Entities;
using BulletHell_CPTS587.Graphics;
using BulletHell_CPTS587.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//uses sprites from https://chasersgaming.itch.io/asset-pack-space-shooter-sms

namespace BulletHell_CPTS587
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private const string ASSET_NAME_SPRITESHEET = "sprite sheet";
        private Texture2D _spriteSheetTexture;

        private PlayerCharacter _pc;
        private Bullet _bullet;
        private EnemyBullet _ebullet;
        private GruntA _gruntA;
        private GruntB _gruntB;
        private MidLevelBoss _mlboss;
        private EndLevelBoss _elboss;

        public const int WINDOW_WIDTH = 600;
        public const int WINDOW_HEIGHT = 600;

        public const int PC_START_X_POS = 300;
        public const int PC_START_Y_POS = 300;

        private EntityManager _entityManager;
        private InputController _ipController; 

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _entityManager = new EntityManager(); 
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteSheetTexture = Content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);
            _pc = new PlayerCharacter(_spriteSheetTexture, new Vector2(PC_START_X_POS - PlayerCharacter.PC_DEFAULT_SPRITE_W, PC_START_Y_POS + 105));
            _ipController = new InputController(_pc);

           // _entityManager.addEntity(_pc);

            //------just for displaying, delete when done using ------------//
            _bullet = new Bullet(_spriteSheetTexture, new Vector2(PC_START_X_POS, PC_START_Y_POS)); 
            _ebullet = new EnemyBullet(_spriteSheetTexture, new Vector2(PC_START_X_POS + 20, PC_START_Y_POS)); 
            _gruntA = new GruntA(_spriteSheetTexture, new Vector2(PC_START_X_POS + 40, PC_START_Y_POS)); 
            _gruntB = new GruntB(_spriteSheetTexture, new Vector2(PC_START_X_POS + 60, PC_START_Y_POS)); 
            _mlboss = new MidLevelBoss(_spriteSheetTexture, new Vector2(PC_START_X_POS + 80, PC_START_Y_POS)); 
            _elboss = new EndLevelBoss(_spriteSheetTexture, new Vector2(PC_START_X_POS + 110, PC_START_Y_POS));
            //------just for displaying, delete when done using ------------//
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            _ipController.processControls(gameTime);

            _entityManager.Update(gameTime);
           
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _pc.Draw(_spriteBatch, gameTime);
           
           // _entityManager.Draw(_spriteBatch, gameTime);

            //------just for displaying, delete when done using ------------//
            _spriteBatch.Draw(_spriteSheetTexture, new Vector2(10, 10), Color.White);

            _bullet.Draw(_spriteBatch, gameTime); 
            _ebullet.Draw(_spriteBatch, gameTime);
            _gruntA.Draw(_spriteBatch, gameTime); 
            _gruntB.Draw(_spriteBatch, gameTime); 
            _mlboss.Draw(_spriteBatch, gameTime); 
            _elboss.Draw(_spriteBatch, gameTime); 
            //------just for displaying, delete when done using ------------//

            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}