using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public class Player
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Experience { get; set; }
        public int LevelNumber { get; set; }

        public Player()
        {
            Name = "";
            Strength = 0;
            Intelligence = 0;
            Dexterity = 0;
            Vitality = 0;
            Experience = 0;
            LevelNumber = 1;
        }

        public Player(string name, int str, int intel, int dex, int vit)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Vitality = vit;
            Experience = 0;
            LevelNumber = 1;
            Health = Strength * Vitality * 2;
            Mana = Intelligence * 8;
        }

        public void SetHealthPool()
        {
            Health = Strength * Vitality * 2;
        }

        public void SetManaPool()
        {
            Mana = Intelligence * 8;
        }

        public void AddEXP(int xpGained)
        {
            Experience += xpGained;       
        }

        public void LevelUp()
        {
            LevelNumber += 1;
            Strength += 1;
            Intelligence += 1;
            Dexterity += 1;
            Vitality += 1;
        }

        public void CheatGodMode()
        {
            Strength = 9999;
            Intelligence = 9999;
            Dexterity = 9999;
            Vitality = 9999;
        }
    }
}
