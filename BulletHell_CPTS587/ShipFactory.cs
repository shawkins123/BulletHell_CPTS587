using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BulletHell_CPTS587;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CPTS587.Entities
{

    public class ShipFactory
    {
        public ShipFactory() { }

        public static Ship createShip(int health, string name, Texture2D texture, Vector2 inpPosition, int inpScreenWidth, GameTime gameTime, float zigZag = 0.0f)
        {
            return new Ship(health, name, texture, inpPosition, inpScreenWidth, gameTime, zigZag);
        }

        public static Ship AddLaser(Ship rawShip, int laserHealth, string laserName,
        Texture2D LaserTexture,
        float bulletInterval,
        Microsoft.Xna.Framework.Vector2 laserPosition,
        Microsoft.Xna.Framework.Vector2 laserVector,
        bool PlayerLaser = false,
        float laserDelay = 0.0f)
        {
            rawShip.AddLaser(new Laser(laserHealth, laserName, LaserTexture, bulletInterval, laserPosition, laserVector, PlayerLaser, laserDelay));
            return rawShip;
        }
    }
}
