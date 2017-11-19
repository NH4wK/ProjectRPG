using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public class Weapon
    {
        public string Name { get; set; }
        public int AttackPoints { get; set; }
        //public string AttackType { get; set; }
        //public int CritChance { get; set; }

        public Weapon()
        {
            Name = "";
            AttackPoints = 0;
        }

        public Weapon(string name, int attackPoints)
        {
            Name = name;
            AttackPoints = attackPoints;
        }
    }
}
