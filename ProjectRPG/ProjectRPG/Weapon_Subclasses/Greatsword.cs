using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Greatsword - Weapon Sub Class
/// </summary>
namespace ProjectRPG
{
    class Greatsword : Weapon
    {
        public Greatsword()
        {
            Name = "";
            ElementType = "Fire";
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

        public Greatsword(int StrengthStat, int DexterityStat)
        {
            SetBaseAttackMult();
            Name = GenerateWeapName();
            BaseAttack = StrengthStat * Game.Player.LevelNumber * BaseAttackMultiplier;

            ElementType = "Fire";

            Move1Name = "Heavy Slash";
            Move1Ammo = 20;
            Move1Damage = (BaseAttack * 2) + (DexterityStat * 2);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Burning Slash";
            Move2Ammo = 10;
            Move2Damage = (BaseAttack * 2) + (int)(BaseAttack / 2) + (DexterityStat * 2);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Fiery Winter Blast";
            Move3Ammo = 8;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = (BaseAttack * 3) + (int)(BaseAttack) + (DexterityStat * 3);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "Wildfire of the Black Dragon";
            Move4Ammo = 3;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 30;

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
            string[] name = { "Killer of Nogeo, the Great", "Coldfire", "Firebringer", "Destroyer of Ice", "Useful Sword", "Gleaming Federation" };

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            if (BaseAttackMultiplier == 4)
                return ($"{name[randVal]} (Legendary Greatsword)");
            else if (BaseAttackMultiplier == 3)
                return ($"{name[randVal]} (Epic Greatsword)");
            else if (BaseAttackMultiplier == 2)
                return ($"{name[randVal]} (Rare Greatsword)");
            else if (BaseAttackMultiplier == 1)
                return ($"{name[randVal]} (Normal Greatsword)");
            else
                return ($"{name[randVal]} (Greatsword)");
        }

        public override void UpdateWeapon(int StrengthStat, int IntelligenceStat, int DexterityStat)
        {
            BaseAttack = StrengthStat * Game.Player.LevelNumber * BaseAttackMultiplier;

            Move1Damage = (BaseAttack * 2) + (DexterityStat * 2);

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Damage = (BaseAttack * 2) + (int)(BaseAttack / 2) + (DexterityStat * 2);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = (BaseAttack * 3) + (int)(BaseAttack) + (DexterityStat * 3);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 30;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}
