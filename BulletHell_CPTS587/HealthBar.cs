using CPTS587;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell_CPTS587
{
    public class HealthBar
    {
        private Player player;
        private List<Hitpoint> Hitpoints;

        Vector2 position;
        public Texture2D Texture;
        GraphicsDevice gd;


        public HealthBar(Player player, GraphicsDevice gd)
        {
            this.player = player;
            this.gd = gd;
            Hitpoints = new List<Hitpoint>();
        }

        public void setupHealthBar()
        {
            int count = player.Lives;

            for (int i = 0; i < count; i++)
            {
                position.Y = 20;
                position.X = (20 * count) + 10;

                Hitpoint hp = new Hitpoint(gd, position);
                Hitpoints.Add(hp);
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Hitpoint entity in Hitpoints)
            {
                entity.Draw(spriteBatch);
            }
        }

    }
}
