using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - SpellTome - Weapon Sub Class
/// </summary>
namespace ProjectRPG
{
    class SpellTome : Weapon
    {
        public SpellTome()
        {
            Name = "";
            ElementType = "Magic";
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

        public SpellTome(int StrengthStat)
        {
            Name = GenerateWeapName();
            BaseAttack = (StrengthStat / 4) * Game.Player.LevelNumber * Game.Player.Intelligence;

            ElementType = "Magic";

            Move1Name = "Fire Blast";
            Move1Ammo = 3;
            Move1Damage = BaseAttack + (Game.Player.Intelligence * 4);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Ice Blast";
            Move2Ammo = 3;
            Move2Damage = BaseAttack + (Game.Player.Intelligence * 4);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Thunderbolt";
            Move3Ammo = 3;
            Move3MaxAmmo = Move3Ammo;

            Move3Damage = BaseAttack + (Game.Player.Intelligence * 4);

            if (Move4Damage >= 999999 || Move3Damage < 0)
                Move4Damage = 999999;

            Move4Name = "Elemental Cataclysm";
            Move4Ammo = 1;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 100;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }

        private string GenerateWeapName()
        {
            string[] name = { "Forbidden Book", "Unknown Scripture", "Ender of Worlds", "Harry's Spells"};

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (Spell Tome)");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = (StrengthStat / 4) * Game.Player.LevelNumber * Game.Player.Intelligence;

            Move1Damage = BaseAttack + (Game.Player.Intelligence * 4);

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Damage = BaseAttack + (Game.Player.Intelligence * 4);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = BaseAttack + (Game.Player.Intelligence * 4);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 100;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}

