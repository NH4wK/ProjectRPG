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

            Move1MaxAmmo = Move1Ammo;
            Move2MaxAmmo = Move2Ammo;
            Move3MaxAmmo = Move3Ammo;
            Move4MaxAmmo = Move4Ammo;
        }

        public WarHammer(int StrengthStat)
        {
            Name = GenerateWeapName();
            BaseAttack = StrengthStat * Game.Player.LevelNumber;

            ElementType = "Thunder";

            Move1Name = "Hammer Smash";
            Move1Ammo = 30;
            Move1Damage = BaseAttack;
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Hammer Throw";
            Move2Ammo = 10;
            Move2Damage = BaseAttack + (int)(BaseAttack * 2);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Thundershock";
            Move3Ammo = 10;
            Move3MaxAmmo = Move3Ammo;

            Move3Damage = BaseAttack + (int)(BaseAttack * 2.5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "Power of Zeus";
            Move4Ammo = 5;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 10;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }

        private string GenerateWeapName()
        {
            string[] name = { "The Banger", "Hammer Time!", "The Masher", "For Honor!", "Calm Thunder", "Raging Thunder" };

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (WarHammer)");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = Game.Player.Strength * Game.Player.LevelNumber;
            Move1Damage = BaseAttack;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Damage = BaseAttack + (int)(BaseAttack * 2);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = BaseAttack + (int)(BaseAttack * 2.5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 8;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}
