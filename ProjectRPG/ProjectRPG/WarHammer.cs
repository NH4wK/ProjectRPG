using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class WarHammer : Weapon
    {
        public WarHammer()
        {
            Name = "";
            ElementType = "Thunder";
            BaseAttack = 0;

            Move1Name = "";
            Move2Name = "";
            Move3Name = "";
            Move4Name = "";

            Move1Ammo = 0;
            Move2Ammo = 0;
            Move3Ammo = 0;
            Move4Ammo = 0;
        }

        public WarHammer(int StrengthStat)
        {
            Name = GenerateWarHammerName();
            BaseAttack = StrengthStat * 2;

            Move1Name = "Hammer Smash";
            Move1Ammo = 30;
            Move1Damage = BaseAttack;

            Move2Name = "Hammer Throw";
            Move2Ammo = 10;
            Move2Damage = BaseAttack + (int)(BaseAttack * 0.25);

            Move3Name = "Thundershock";
            Move3Ammo = 10;

            if (Game.Enemy.Type == "")
                Move3Damage = BaseAttack + (int)(BaseAttack * 0.35);
            else
                Move3Damage = BaseAttack + (int)(BaseAttack * 0.15);

            Move4Name = "Power of Zeus";
            Move4Ammo = 1;

            if (Game.Enemy.Type == "")
                Move4Damage = BaseAttack * 4;
            else
                Move4Damage = BaseAttack * 2;


        }

        public string GenerateWarHammerName()
        {
            string[] name = { "The Banger", "Hammer Time!", "The Masher", "For Honor!", "Calm Thunder", "Raging Thunder" };

            Random rand = new Random();
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (Hammer)");
        }


        public void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = StrengthStat * 2;
        }
    }
}
