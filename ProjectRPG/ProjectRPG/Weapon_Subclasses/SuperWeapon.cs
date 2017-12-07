using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Super Weapon - Weapon Sub Class
/// </summary>
namespace ProjectRPG
{
    class SuperWeapon : Weapon
    {
        public SuperWeapon()
        {
            Name = "";
            ElementType = "All";
            BaseAttack = 0;
            BaseAttackMultiplier = 0;

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

        public SuperWeapon(int StrengthStat)
        {
            Name = "Super Attacks (Special)";
            BaseAttack = 999999;

            ElementType = "All";

            Move1Name = "Spirit Bomb";
            Move1Ammo = 999;
            Move1Damage = BaseAttack;
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 999999 || Move1Damage < 0)
                Move1Damage = 999999;

            Move2Name = "Serious Punch";
            Move2Ammo = 999;
            Move2Damage = BaseAttack;
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 999999 || Move2Damage < 0)
                Move2Damage = 999999;

            Move3Name = "Rasengan";
            Move3Ammo = 999;
            Move3MaxAmmo = Move3Ammo;

            Move3Damage = BaseAttack + (int)(BaseAttack * 2.5);

            if (Move3Damage >= 999999 || Move3Damage < 0)
                Move3Damage = 999999;

            Move4Name = "Jajanken";
            Move4Ammo = 999;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack;

            if (Move4Damage >= 999999 || Move4Damage < 0)
                Move4Damage = 999999;
        }

        public override void UpdateWeapon(int StrengthStat, int Intelligence, int Dexterity)
        {
            BaseAttack = 999999;
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
