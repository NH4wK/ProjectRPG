using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// /// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Katana - Weapon Sub Class
/// </summary>
/// </summary>
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

        public Katana(int StrengthStat, int DexterityStat)
        {
            SetBaseAttackMult();
            Name = GenerateWeapName();
            BaseAttack = StrengthStat * Game.Player.LevelNumber * BaseAttackMultiplier;

            ElementType = "Wind";

            Move1Name = "Clean Swipe";
            Move1Ammo = 15;
            Move1Damage = (BaseAttack * 2) + (DexterityStat * 4);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Tornado Slash";
            Move2Ammo = 12;
            Move2Damage = (BaseAttack * 3) + (int)(BaseAttack) + (DexterityStat * 4);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Peaceful Harmony Strike";
            Move3Ammo = 5;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = (BaseAttack * 10) + (int)(BaseAttack) + (DexterityStat * 5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "The Furious Eye of Akagi";
            Move4Ammo = 5;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 25;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;

        }

        private void SetBaseAttackMult()
        {
            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int BaseMult = rand.Next(1, 4);

            BaseAttackMultiplier = BaseMult;
        }

        private string GenerateWeapName()
        {
            string[] name = { "Shining Dawn", "Quick Horizon", "Akagi's Weapon", "Windslasher", "Windbreaker"};

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            if (BaseAttackMultiplier == 4)
                return ($"{name[randVal]} (Legendary Katana)");
            else if (BaseAttackMultiplier == 3)
                return ($"{name[randVal]} (Epic Katana)");
            else if (BaseAttackMultiplier == 2)
                return ($"{name[randVal]} (Rare Katana)");
            else if (BaseAttackMultiplier == 1)
                return ($"{name[randVal]} (Normal Katana)");
            else
                return ($"{name[randVal]} (Katana)");
        }

        public override void UpdateWeapon(int StrengthStat, int IntelligenceStat, int DexterityStat)
        {
            BaseAttack = StrengthStat * Game.Player.LevelNumber * BaseAttackMultiplier;
            Move1Damage = (BaseAttack * 2) + (DexterityStat * 4);

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move4Damage = 999999;

            Move2Damage = (BaseAttack * 3) + (int)(BaseAttack) + (DexterityStat * 4);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = (BaseAttack * 10) + (int)(BaseAttack) + (DexterityStat * 5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 25;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}
