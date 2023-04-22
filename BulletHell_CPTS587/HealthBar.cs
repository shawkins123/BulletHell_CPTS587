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

        private int screenHeight;
        private int screenWidth;
        private int offset = 200;

        public HealthBar(Player player, GraphicsDevice gd, int screenHeight, int screenWidth)
        {
            this.player = player;
            this.gd = gd;
            Hitpoints = new List<Hitpoint>();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        public void updateHealthBar()
        {
            Hitpoints.Clear();
            int count = player.getLives();
            
            for (int i = 0; i < count + 1; i++)
            {
                Hitpoint hp = new Hitpoint(gd, position);
                int sub = hp.getSub();
                position.Y = screenHeight - sub;
                position.X = screenWidth - offset - (sub * i);
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
