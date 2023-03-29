using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    //retitle it to pickup?
    public interface Powerup
    {
        void CreatePowerup(Vector2 position, GraphicsDevice gd);
        void ActivatePowerup();
        void DeactivatePowerup();
        void DeletePowerup();

    }
}
