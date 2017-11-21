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

        public Weapon()
        {
            Name = "";
        }

        public Weapon(string name)
        {
            Name = name;
        }
    }
}
