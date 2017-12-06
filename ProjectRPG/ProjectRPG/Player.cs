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
        public int MaxHealth { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; }
        public int Experience { get; set; }
        public int LevelNumber { get; set; }
        public int KillCount { get; set; }

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
            Health = Strength * Vitality;
            Mana = Intelligence * 8;
            MaxHealth = Health;
            MaxMana = Mana;
            KillCount = 0;
        }

        public void SetHealthPool()
        {
            Health = Strength * Vitality;

            if (Game.Player.Health > 999999 || Game.Player.Health < 0)
                Health = 999999;

            MaxHealth = Health;
        }

        public void SetManaPool()
        {
            Mana = Intelligence * 8;

            if (Game.Player.Mana >= 999999 || Game.Player.Mana < 0)
                Mana = 999999;
            
            MaxMana = Mana;
        }

        public void AddEXP(int xpGained)
        {
            Experience += xpGained;       
        }

        public void LevelUp()
        {
            if(Game.Player.LevelNumber < 999)
                LevelNumber += 1;

            if (Strength < 10)
                Strength += 1;
            else
                Strength += (int)(Game.Player.Strength * 0.10);

            if (Intelligence < 10)
                Intelligence += 1;
            else
                Intelligence += (int)(Game.Player.Intelligence * 0.10);

            if (Dexterity < 10)
                Dexterity += 1;
            else
                Dexterity += (int)(Game.Player.Dexterity * 0.10);

            if (Vitality < 10)
                Vitality += 1;
            else
                Vitality += (int)(Game.Player.Vitality * 0.10);

            if (Game.Player.Strength > 999)
                Game.Player.Strength = 999;
            if (Game.Player.Intelligence > 999)
                Game.Player.Intelligence = 999;
            if (Game.Player.Dexterity > 999)
                Game.Player.Dexterity = 999;
            if (Game.Player.Vitality > 999)
                Game.Player.Vitality = 999;
        }

        public void CheatGodMode()
        {
            LevelNumber = 999;
            Strength = 999;
            Intelligence = 999;
            Dexterity = 999;
            Vitality = 999;
            Health = 999999;
            MaxHealth = 999999;
            Mana = 999999;
            MaxMana = 999999;
        }
    }
}
