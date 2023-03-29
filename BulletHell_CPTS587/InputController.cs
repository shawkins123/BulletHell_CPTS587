using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BulletHell_CPTS587.Entities;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
//using BulletHell_CPTS587.Graphics;
using CPTS587;
using CPTS587.Entities;

namespace BulletHell_CPTS587.System
{
    public class InputController
    {
        private Player _pc;
        private BulletManager _bulletManager;

        private bool hasFireButtonBeenPressed;
        //cheatmode
        private bool hasCheatButtonBeenPressed;

        private double _timeSinceLastSpeedChange = 0;
        private double _speedChangeInterval = 0.5;

        float speedVar = 4.0f;

        private int screenHeight = 660; //change value?
        private int screenWidth = 1300; //change value?
        private int entityWidth = 20; //change value?
        private int entityHeight = 40; //change value?

        public InputController(Player pc, BulletManager bulletManager) // BulletManager bulletManager)
        {
            _pc = pc;
            _bulletManager = bulletManager;
        }
        public void processControls(GameTime gameTime)
        {
            var keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Tab))
            {
                moveShip(gameTime, keyState, speedVar/2);
            }
            else
            {
                moveShip(gameTime, keyState, speedVar);
            }

            if (keyState.IsKeyDown(Keys.F) && hasFireButtonBeenPressed == false)
            {
                fireBullet(gameTime);
                hasFireButtonBeenPressed = true;
            }

            if (keyState.IsKeyUp(Keys.F))
            {
                hasFireButtonBeenPressed = false;
            }

            //cheatmode
            if (keyState.IsKeyDown(Keys.W) && hasCheatButtonBeenPressed == false)
            {
                activateCheatMode();
                hasCheatButtonBeenPressed = true;
            }

            if (keyState.IsKeyUp(Keys.W))
            {
                deactivateCheatMode();
                hasCheatButtonBeenPressed = false;
            }


        }

        public void activateCheatMode()
        {
            _pc.isCheating = true;
        }

        public void deactivateCheatMode()
        {
            _pc.isCheating = false;
        }

        public void fireBullet(GameTime gameTime)
        {
            //  _bulletManager.fire(_pc.position.Y, _pc.position.X);
        }     

        public void moveShip(GameTime gameTime, KeyboardState keyState, float speed)
        {

            _timeSinceLastSpeedChange += gameTime.ElapsedGameTime.TotalSeconds;


            if (keyState.IsKeyDown(Keys.Up) && _pc.position.Y > 0)
            {
                _pc.position.Y -= speed;
            }
            if (keyState.IsKeyDown(Keys.Down) && _pc.position.Y < (screenHeight - entityHeight))
            {
                _pc.position.Y += speed;
            }
            if (keyState.IsKeyDown(Keys.Left) && _pc.position.X > 0)
            {
                _pc.position.X -= speed;
            }
            if (keyState.IsKeyDown(Keys.Right) && _pc.position.X < (screenWidth - entityWidth))
            {
                _pc.position.X += speed;
            }
            if (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Left))
            {
                if (_pc.position.X > 0)
                {
                    _pc.position.X -= (speed * 0.5f)/4;
                }
                if (_pc.position.Y > 0)
                {
                    _pc.position.Y -= (speed * 0.5f)/4;
                }
            }
            if (keyState.IsKeyDown(Keys.Up) && keyState.IsKeyDown(Keys.Right))
            {
                if (_pc.position.X < (screenWidth - entityWidth))
                {
                    _pc.position.X += (speed * 0.5f)/4;
                }
                if (_pc.position.Y > 0)
                {
                    _pc.position.Y -= (speed * 0.5f)/4;
                }
            }
            if (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Left))
            {
                if (_pc.position.X > 0)
                {
                    _pc.position.X -= (speed * 0.5f)/4;
                }
                if (_pc.position.Y < (screenHeight - entityHeight))
                {
                    _pc.position.Y += (speed * 0.5f)/4;
                }

            }
            if (keyState.IsKeyDown(Keys.Down) && keyState.IsKeyDown(Keys.Right))
            {
                if (_pc.position.X < (screenWidth - entityWidth))
                {
                    _pc.position.X += (speed * 0.5f)/4;
                }
                if (_pc.position.Y < (screenHeight - entityHeight))
                {
                    _pc.position.Y += (speed * 0.5f)/4;
                }

            }

        }

    }

}
