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
        private Texture2D xWing;
        private Texture2D aWing;
        private Texture2D Frigate;
        private Texture2D rebelScum;


        private Texture2D blasterGreen;
        private Texture2D blasterBlue;

        public ShipFactory(ContentManager content)
        {
            this.xWing = content.Load<Texture2D>("xWing");
            this.aWing = content.Load<Texture2D>("aWing");
            this.Frigate = content.Load<Texture2D>("BossA");
            this.rebelScum = content.Load<Texture2D>("BossB");

            this.blasterGreen = content.Load<Texture2D>("blasterGreen");
            this.blasterBlue = content.Load<Texture2D>("blasterBlue");
        }


        public Ship assembleShip(string shipName, int yCoord, string startSide, float movement, int inpScreenWidth, GameTime gameTime, PowerupManager pm)
        {
            int inp_y = 0;
            if (startSide != "L")
            {
                inp_y = inpScreenWidth;
            }


            switch (shipName)
            {
                case "xWing":

                    Ship xWing = createShip(25, "T-65B X-wing", this.xWing, new Microsoft.Xna.Framework.Vector2(inp_y, yCoord), inpScreenWidth, gameTime, pm, movement);
                    AddLaser(xWing, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(-5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                    AddLaser(xWing, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                    return xWing;

                case "aWing":

                    Ship aWing = createShip(25, "RZ-1 A-wing", this.aWing, new Microsoft.Xna.Framework.Vector2(inp_y, yCoord), inpScreenWidth, gameTime, pm, movement);
                    AddLaser(aWing, 10, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(-3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                    AddLaser(aWing, 10, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(3, 0), new Microsoft.Xna.Framework.Vector2(0, 2));
                    return aWing;

                case "Frigate":

                    Ship frigate = createShip(25, "Frigate", this.Frigate, new Microsoft.Xna.Framework.Vector2(inp_y, yCoord), inpScreenWidth, gameTime, pm, movement);
                    AddLaser(frigate, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(-5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                    AddLaser(frigate, 25, "KX9 Laser Cannon", blasterGreen, 1, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(0, 5));
                    AddLaser(frigate, 25, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(-5, 5));
                    AddLaser(frigate, 25, "KX9 Laser Cannon", blasterBlue, 0.5f, new Microsoft.Xna.Framework.Vector2(5, 0), new Microsoft.Xna.Framework.Vector2(5, 5));
                    return frigate;

                case "Cruiser":

                    Ship cruiser = createShip(25, "MC80A Cruiser", this.rebelScum, new Microsoft.Xna.Framework.Vector2(inp_y, yCoord), inpScreenWidth, gameTime, pm, movement);
                    AddLaser(cruiser, 50, "KX9 Laser Cannon", blasterGreen, 1.0f, new Microsoft.Xna.Framework.Vector2(0, 75), new Microsoft.Xna.Framework.Vector2(6.0f, 4.0f), false, 0.25f);
                    AddLaser(cruiser, 50, "KX9 Laser Cannon", blasterGreen, 1.0f, new Microsoft.Xna.Framework.Vector2(50, 75), new Microsoft.Xna.Framework.Vector2(4.0f, 4.75f), false, 0.5f);
                    AddLaser(cruiser, 50, "KX9 Laser Cannon", blasterGreen, 1.0f, new Microsoft.Xna.Framework.Vector2(-5, 150), new Microsoft.Xna.Framework.Vector2(2.0f, 5.25f), false, 0.75f);
                    AddLaser(cruiser, 50, "KX9 Laser Cannon", blasterGreen, 1f, new Microsoft.Xna.Framework.Vector2(25, 100), new Microsoft.Xna.Framework.Vector2(0.0f, 6.0f), false, 1.0f);

                    AddLaser(cruiser, 100, "KX9 Laser Cannon", blasterBlue, 0.75f, new Microsoft.Xna.Framework.Vector2(10, 230), new Microsoft.Xna.Framework.Vector2(0, 2));
                    AddLaser(cruiser, 100, "KX9 Laser Cannon", blasterBlue, 0.75f, new Microsoft.Xna.Framework.Vector2(20, 230), new Microsoft.Xna.Framework.Vector2(0, 2));


                    return cruiser;

                default:
                    return createShip(25, "T-65B X-wing", this.xWing, new Microsoft.Xna.Framework.Vector2(0, yCoord), inpScreenWidth, gameTime, pm, 0.75f);
            }
        }

        public static Ship createShip(int health, string name, Texture2D texture, Vector2 inpPosition, int inpScreenWidth, GameTime gameTime, PowerupManager pm, float zigZag = 0.0f)
        {
            return new Ship(health, name, texture, inpPosition, inpScreenWidth, gameTime, pm, zigZag);
        }

        public static Ship AddLaser(
            Ship rawShip,
            int laserHealth,
            string laserName,
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
