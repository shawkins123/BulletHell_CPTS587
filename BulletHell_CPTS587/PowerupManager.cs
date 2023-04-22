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
    public class PowerupManager
    {
        public List<HealthPowerup> powerups;
        public PowerupFactory powerupFactory;
        private Player player;
        private EntityManager entityManager;
        private int pickupZone = 50;

        public PowerupManager(GraphicsDevice gd, Player player, EntityManager entityManager)
        {
            powerups = new List<HealthPowerup>();
            this.player = player;
            powerupFactory = new PowerupFactory(gd, player);
            this.entityManager = entityManager;
        }

        public void AddEntity_Powerup(Vector2 positionX)
        {
            HealthPowerup hp = powerupFactory.createPowerup(positionX);

            powerups.Add(hp);
            entityManager.AddPowerup(hp);
        }

        public void Update(GameTime gameTime)
        {
                
            for (int i = 0; i < powerups.Count; i++)
            {
                Rectangle BoundsPU = powerups[i].getBounds();
                if (player.Bounds.X >= BoundsPU.X &&
                player.Bounds.X <= BoundsPU.X + pickupZone)
                {
                    if (player.Bounds.Y >= BoundsPU.Y &&
                    player.Bounds.Y <= BoundsPU.Y + pickupZone)
                    {
                     //   powerups[i].setIsActive(false);
                     //not sure why above isn't working 
                     //if additional powerups are to be created, then above needs to work
                        powerups[i].isActive = false;
                        int choice = powerups[i].activate();
                        initiatePowerup(choice);
                    }

                }
            }
       
        }

        public void initiatePowerup(int choice)
        {
            if(choice == 1)
            {
              player.addLife();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
