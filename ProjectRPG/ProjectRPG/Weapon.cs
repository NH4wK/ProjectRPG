using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Weapon Class
/// </summary>
namespace ProjectRPG
{
    public abstract class Weapon
    {
        public string Name { get; set; }

        public string ElementType { get; set; }

        public int BaseAttack { get; set; }

        public string Move1Name { get; set; }
        public string Move2Name { get; set; }
        public string Move3Name { get; set; }
        public string Move4Name { get; set; }

        public string Move1Description = "Low Damage Attack";
        public string Move2Description = "Medium Damage Attack";
        public string Move3Description = "High Damage Attack";
        public string Move4Description = "Very High Damage Attack";

        public int Move1Ammo { get; set; }
        public int Move2Ammo { get; set; }
        public int Move3Ammo { get; set; }
        public int Move4Ammo { get; set; }

        public int Move1MaxAmmo { get; set; }
        public int Move2MaxAmmo { get; set; }
        public int Move3MaxAmmo { get; set; }
        public int Move4MaxAmmo { get; set; }

        public int Move1Damage { get; set; } //Low Damage
        public int Move2Damage { get; set; } //Medium Damage
        public int Move3Damage { get; set; } //Medium-High Damage
        public int Move4Damage { get; set; } //High Damage

        public abstract void UpdateWeapon(int StrengthStat);
    }
}
