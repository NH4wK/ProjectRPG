using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Broadsword - Weapon Sub Class
/// </summary>
/// 
namespace ProjectRPG
{
    class Broadsword : Weapon
    {
        public Broadsword()
        {
            Name = "";
            ElementType = "Normal";
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

        public Broadsword(int StrengthStat, int DexterityStat)
        {
            SetBaseAttackMult();
            Name = GenerateWeapName();
            BaseAttack = (StrengthStat) * Game.Player.LevelNumber * BaseAttackMultiplier;

            ElementType = "Normal";

            Move1Name = "Quick Slash";
            Move1Ammo = 30;
            Move1Damage = BaseAttack + (DexterityStat * 2);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Sword Dance Fury";
            Move2Ammo = 10;
            Move2Damage = BaseAttack + (int)(BaseAttack / 2) + (DexterityStat * 2);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Mountainous Swipe";
            Move3Ammo = 10;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = BaseAttack + (int)(BaseAttack / 1.5) + (DexterityStat * 2);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "Swordbreaker";
            Move4Ammo = 10;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 7;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }

        private void SetBaseAttackMult()
        {
            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int BaseMult = rand.Next(1, 5);

            BaseAttackMultiplier = BaseMult;
        }

        private string GenerateWeapName()
        {
            string[] name = { "Sword of the Nine", "King Slayer", "Wise Old One", "Standard", "Useful Sword", "Gleaming Federation" };

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            if (BaseAttackMultiplier == 4)
                return ($"{name[randVal]} (Legendary Broadsword)");
            else if (BaseAttackMultiplier == 3)
                return ($"{name[randVal]} (Epic Broadsword)");
            else if (BaseAttackMultiplier == 2)
                return ($"{name[randVal]} (Rare Broadsword)");
            else if (BaseAttackMultiplier == 1)
                return ($"{name[randVal]} (Normal Broadsword)");
            else
                return ($"{name[randVal]} (Broadsword)");
        }

        public override void UpdateWeapon(int StrengthStat, int IntelligenceStat, int DexterityStat)
        {
            BaseAttack = StrengthStat * Game.Player.LevelNumber * BaseAttackMultiplier;
            Move1Damage = BaseAttack + (DexterityStat * 2);

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Damage = BaseAttack + (int)(BaseAttack / 2) + (DexterityStat * 2);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = BaseAttack + (int)(BaseAttack / 2.5) + (DexterityStat * 2);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 7;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}
