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
        public string Type { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Health { get; set; }

        public Enemy()
        {
            Name = "";
            Type = "";
            Strength = 0;
            Intelligence = 0;
            Dexterity = 0;
            Vitality = 0;
            Health = 0;
        }

        public Enemy(string name, string type, int str, int intel, int dex, int vit)
        {
            Name = name;
            Type = type;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Vitality = vit;
            Health = Strength * Vitality * 3;
        }

        public void GenerateEnemy()
        {

            Random RanVal = new Random();
            int StatValue1 = RanVal.Next(Game.Player.Strength, Game.Player.Strength + 4);
            int StatValue2 = RanVal.Next(Game.Player.Intelligence, Game.Player.Intelligence + 4);
            int StatValue3 = RanVal.Next(Game.Player.Dexterity, Game.Player.Dexterity + 4);
            int StatValue4 = RanVal.Next(Game.Player.Vitality, Game.Player.Vitality + 4);

            Strength = StatValue1;
            Intelligence = StatValue2;
            Dexterity = StatValue3;
            Vitality = StatValue4;

            Health = Strength * Vitality * 4;
        }



    }
}
