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

    public interface Powerup
    {
        int activate();
        void Update(GameTime gameTime);
        Rectangle getBounds();
        void Draw(SpriteBatch spriteBatch);

        void setIsActive(bool isActive);
    }
    public class HealthPowerup : Powerup
    {
        public Vector2 position;
        public Texture2D Texture;
        public Rectangle Bounds;
        public GraphicsDevice gd;
        public int sub = 15;
        public bool isActive;

        public HealthPowerup(GraphicsDevice gd, Vector2 positionInput)
        {
            Texture2D hitPointBox = new Texture2D(gd, sub, sub);
            setColor(hitPointBox, sub);
            position = positionInput;
            Texture = hitPointBox;
            isActive = true;
            Bounds = new Rectangle((int)position.X, (int)position.Y, Texture.Width, Texture.Height);
        }

        private static void setColor(Texture2D hitPointBox, int sub)
        {
            Color[] data = new Color[sub * sub];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            hitPointBox.SetData(data);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

        public Rectangle getBounds()
        {
            Bounds.X = (int)position.X;
            Bounds.Y = (int)position.Y;
            return Bounds;
        }
        public void Update(GameTime _gameTime)
        {
            
        }

        public void setIsActive(bool isActive)
        {
            isActive = false;
        }
        public int activate()
        {
            return 1;
        }
    }
}
