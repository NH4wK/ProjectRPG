using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class Katana : Weapon
    {
        public Katana()
        {
            Name = "";
            ElementType = "Wind";
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

        public Katana(int StrengthStat)
        {
            Name = GenerateWeapName();
            BaseAttack = StrengthStat * Game.Player.LevelNumber * 4;

            ElementType = "Wind";

            Move1Name = "Clean Swipe";
            Move1Ammo = 15;
            Move1Damage = (BaseAttack * 2) + (Game.Player.Dexterity * 4);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Tornado Slash";
            Move2Ammo = 12;
            Move2Damage = (BaseAttack * 3) + (int)(BaseAttack) + (Game.Player.Dexterity * 4);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Peaceful Harmony Strike";
            Move3Ammo = 5;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = (BaseAttack * 10) + (int)(BaseAttack) + (Game.Player.Dexterity * 5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "The Furious Eye of Akagi";
            Move4Ammo = 5;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 25;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;

        }

        private string GenerateWeapName()
        {
            string[] name = { "Shining Dawn", "Quick Horizon", "Akagi's Weapon", "Windslasher", "Windbreaker"};

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (Katana)");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = StrengthStat * Game.Player.LevelNumber * 4;
            Move1Damage = (BaseAttack * 2) + (Game.Player.Dexterity * 4);

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move4Damage = 999999;

            Move2Damage = (BaseAttack * 3) + (int)(BaseAttack) + (Game.Player.Dexterity * 4);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = (BaseAttack * 10) + (int)(BaseAttack) + (Game.Player.Dexterity * 5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 25;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}
