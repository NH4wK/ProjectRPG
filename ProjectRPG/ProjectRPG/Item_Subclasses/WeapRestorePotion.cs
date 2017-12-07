using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Mana Potion - Item Sub Class
/// </summary>
namespace ProjectRPG
{
    class WeapRestorePotion : Item
    {
        public WeapRestorePotion()
        {
            Name = "Weapon Restoration Potion";
            EffectDescription = "Restore a weapon's power to full.";
            Quantity = 0;
        }

        public override void Use()
        {
            //Restores Weapon Ammo to there original max values
            Game.PlayerWeapon.Move1Ammo = Game.PlayerWeapon.Move1MaxAmmo;
            Game.PlayerWeapon.Move2Ammo = Game.PlayerWeapon.Move2MaxAmmo;
            Game.PlayerWeapon.Move3Ammo = Game.PlayerWeapon.Move3MaxAmmo;
            Game.PlayerWeapon.Move4Ammo = Game.PlayerWeapon.Move4MaxAmmo;

            //Reduce Weapon Restore Potion Quantity by 1
            Quantity -= 1;
        }
    }
}
