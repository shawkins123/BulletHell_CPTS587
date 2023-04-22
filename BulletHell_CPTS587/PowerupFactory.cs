using CPTS587;
using CPTS587.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    public class PowerupFactory
    {
        public GraphicsDevice _gd;
        private Player _player;
        private GameTime gameTime;

        public PowerupFactory(GraphicsDevice gd, Player player)
        {
            _gd = gd;
            _player = player;
        }

        public void updateGameTime(GameTime gt)
        {
            gameTime = gt;
        }

        public HealthPowerup createPowerup(Vector2 position)
        {
            return new HealthPowerup( _gd, position);
            
        }


    }
}
