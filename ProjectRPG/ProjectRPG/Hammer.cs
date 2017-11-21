using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class Hammer : Weapon
    {
        public int BaseAttack { get; set; }
        //public double CritChance { get; set; }

        public Hammer(string name, int baseAttack) : base(name)
        {
            BaseAttack = baseAttack;
        }

        public void GenerateHammer(int StrengthStat)
        {
            BaseAttack = StrengthStat * 3;
        }
    }
}
