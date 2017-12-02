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
            BaseAttack = StrengthStat * 3;

            Move1Name = "Hammer Smash";
            Move1Ammo = 30;
            Move1Damage = BaseAttack;
            Move1MaxAmmo = Move1Ammo;


            Move2Name = "Hammer Throw";
            Move2Ammo = 10;
            Move2Damage = BaseAttack + (int)(BaseAttack * 2);
            Move2MaxAmmo = Move2Ammo;

            Move3Name = "Thundershock";
            Move3Ammo = 10;
            Move3MaxAmmo = Move3Ammo;

            Move3Damage = BaseAttack + (int)(BaseAttack * 3.75);

            Move4Name = "Power of Zeus";
            Move4Ammo = 1;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 8;
        }

        private string GenerateWeapName()
        {
            string[] name = { "The Banger", "Hammer Time!", "The Masher", "For Honor!", "Calm Thunder", "Raging Thunder" };

            Random rand = new Random();
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} ({this.GetType()}))");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = StrengthStat * 3;
            Move1Damage = BaseAttack;
            Move2Damage = BaseAttack + (int)(BaseAttack * 2);
            Move3Damage = BaseAttack + (int)(BaseAttack * 3.75);      
            Move4Damage = BaseAttack * 8;
        }
    }
}
