using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Greatsword(int StrengthStat)
        {
            Name = GenerateWeapName();
            BaseAttack = StrengthStat * Game.Player.LevelNumber * 5;

            ElementType = "Fire";

            Move1Name = "Heavy Slash";
            Move1Ammo = 20;
            Move1Damage = (BaseAttack * 2) + (Game.Player.Dexterity * 2);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Burning Slash";
            Move2Ammo = 10;
            Move2Damage = (BaseAttack * 2) + (int)(BaseAttack / 2) + (Game.Player.Dexterity * 2);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Fiery Winter Blast";
            Move3Ammo = 8;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = (BaseAttack * 3) + (int)(BaseAttack) + (Game.Player.Dexterity * 3);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "Wildfire of the Black Dragon";
            Move4Ammo = 3;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 30;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }

        private string GenerateWeapName()
        {
            string[] name = { "Killer of Nogeo, the Great", "Coldfire", "Firebringer", "Destroyer of Ice", "Useful Sword", "Gleaming Federation" };

            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random rand = new Random(seedRand);
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (Greatsword)");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = Game.Player.Strength * Game.Player.LevelNumber * 5;

            Move1Damage = (BaseAttack * 2) + (Game.Player.Dexterity * 2);

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Damage = (BaseAttack * 2) + (int)(BaseAttack / 2) + (Game.Player.Dexterity * 2);

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Damage = (BaseAttack * 3) + (int)(BaseAttack) + (Game.Player.Dexterity * 3);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Damage = BaseAttack * 30;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }
    }
}
