using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    public class HealthPickup : Powerup
    {
        Vector2 position;
        public Texture2D Texture;
        public GraphicsDevice gd;
        private int sub = 20;
        public Rectangle Bounds;

        public void ActivatePowerup()
        {

        }

        public void CreatePowerup(Vector2 positionInput, GraphicsDevice gd)
        {
            Texture2D hitPointBox = new Texture2D(gd, 20, 20);
            this.position = positionInput;
            Texture = hitPointBox;
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);

            Color[] data = new Color[sub * sub];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            hitPointBox.SetData(data);
        }

        public void DeactivatePowerup()
        {

        }

        public void DeletePowerup()
        {

        }
    }

    public class ShootingPowerup : Powerup
    {
        public void ActivatePowerup()
        {
         
        }

        public void CreatePowerup()
        {
   
        }

        public void DeactivatePowerup()
        {
         
        }

        public void DeletePowerup()
        {
          
        }
    }

    public class DamagePowerup : Powerup
    {
        public void ActivatePowerup()
        {
       
        }

        public void CreatePowerup()
        {

        }

        public void DeactivatePowerup()
        {
    
        }

        public void DeletePowerup()
        {
       
        }
    }
}
