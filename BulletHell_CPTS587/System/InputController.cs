using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletHell_CPTS587.Entities;
using Microsoft.Xna.Framework.Input;

namespace BulletHell_CPTS587.System
{
    public class InputController
    {
        private PlayerCharacter _pc;
        private float normalSpeed = NORMAL_SPEED;
        private float slowSpeed = SLOW_SPEED; 

        private Vector2 position;

        private int pcWidth = PC_WIDTH;
        private int pcHeight = PC_HEIGHT;
        private int graphicsHeight = GRAPHICS_HEIGHT;
        private int graphicsWidth = GRAPHICS_WIDTH;
        private int graphicsEdge = GRAPHICS_EDGE;

        public const int PC_START_X_POS = 300;
        public const int PC_START_Y_POS = 300;
        public const int PC_WIDTH = 40;
        public const int PC_HEIGHT = 55;
        public const int GRAPHICS_HEIGHT = 600;
        public const int GRAPHICS_WIDTH = 600;
        public const float NORMAL_SPEED = 300f;
        public const float SLOW_SPEED = 150f;
        public const int GRAPHICS_EDGE = 25;

        public InputController(PlayerCharacter pc)
        {
            _pc = pc;
        }
        public void processControls(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if(kstate.IsKeyDown(Keys.Space))
            { 
                moveShip(gameTime, kstate, slowSpeed);
            }
            else
            {
                moveShip(gameTime, kstate, normalSpeed);
            }

        }

        public void moveShip(GameTime gameTime, KeyboardState kstate, float speed)
        {

            if (kstate.IsKeyDown(Keys.Up))
            {
                _pc.position.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                _pc.position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                _pc.position.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                _pc.position.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (_pc.position.X > (graphicsWidth - pcWidth / 2) - graphicsEdge)
            {
                _pc.position.X = (graphicsWidth - pcWidth / 2) - graphicsEdge;
            }
            else if (_pc.position.X < pcWidth / 2)
            {
                _pc.position.X = pcWidth / 2;
            }

            if (_pc.position.Y > (graphicsHeight - pcHeight / 2) - graphicsEdge)
            {
                _pc.position.Y = (graphicsHeight - pcHeight / 2) - graphicsEdge;
            }
            else if (_pc.position.Y < pcHeight / 2)
            {
                _pc.position.Y = pcHeight / 2;
            }
        }

    }
}
