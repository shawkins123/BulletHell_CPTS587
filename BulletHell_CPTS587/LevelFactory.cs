using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using CPTS587.Entities;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Content;

namespace BulletHell_CPTS587
{

    public class LevelFactory
    {
        public List<Wave> waves;
        public LevelFactory() 
        {
            string json = File.ReadAllText(@"Level_1.json");
            this.waves = JsonSerializer.Deserialize<List<Wave>>(json);
        }
    }


    public class Wave
    {
        public Boolean finished {  get; set; }
        public List<string> ships { get; set; }
        public List<Boolean> activated { get; set; }
        public List<int> entranceTime { get; set; }
        public List<int> exitTime { get; set; }
        public List<float> movePattern { get; set; }
        public List<string> enterFrom { get; set; }
        public List<int> start_Y { get; set; }
        public List<string> start_X { get; set; }

    }
}

