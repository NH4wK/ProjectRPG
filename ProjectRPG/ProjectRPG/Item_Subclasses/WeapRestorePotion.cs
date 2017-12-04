using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Game.PlayerWeapon.Move1Ammo = Game.PlayerWeapon.Move1MaxAmmo;
            Game.PlayerWeapon.Move2Ammo = Game.PlayerWeapon.Move2MaxAmmo;
            Game.PlayerWeapon.Move3Ammo = Game.PlayerWeapon.Move3MaxAmmo;
            Game.PlayerWeapon.Move4Ammo = Game.PlayerWeapon.Move4MaxAmmo;

            Quantity -= 1;
        }
    }
}
