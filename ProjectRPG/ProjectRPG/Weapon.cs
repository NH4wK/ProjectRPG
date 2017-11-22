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

        public int Move1Damage { get; set; }
        public int Move2Damage { get; set; }
        public int Move3Damage { get; set; }
        public int Move4Damage { get; set; }

        public Weapon()
        {
            Name = "";

            ElementType = "";

            BaseAttack = 0;

            Move1Name = "";
            Move2Name = "";
            Move3Name = "";
            Move4Name = "";

            Move1Ammo = 0;
            Move2Ammo = 0;
            Move3Ammo = 0;
            Move4Ammo = 0;

            Move1Damage = 0;
            Move2Damage = 0;
            Move3Damage = 0;
            Move4Damage = 0;
        }
    }
}
