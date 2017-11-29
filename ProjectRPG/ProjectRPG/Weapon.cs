using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int Move1Ammo { get; set; }
        public int Move2Ammo { get; set; }
        public int Move3Ammo { get; set; }
        public int Move4Ammo { get; set; }

        public int Move1MaxAmmo { get; set; }
        public int Move2MaxAmmo { get; set; }
        public int Move3MaxAmmo { get; set; }
        public int Move4MaxAmmo { get; set; }

        public int Move1Damage { get; set; }
        public int Move2Damage { get; set; }
        public int Move3Damage { get; set; }
        public int Move4Damage { get; set; }

        public abstract void UpdateWeapon(int StrengthStat);
    }
}
