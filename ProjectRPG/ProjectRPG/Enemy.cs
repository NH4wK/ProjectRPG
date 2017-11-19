using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public class Enemy
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Health { get { return Health; } set { Health = (Vitality * 8); } }

        public Enemy()
        {
            Name = "";
            Strength = 0;
            Intelligence = 0;
            Dexterity = 0;
            Vitality = 0;
        }

        public Enemy(string name, int str, int intel, int dex, int vit)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Vitality = vit;
        }



    }
}
