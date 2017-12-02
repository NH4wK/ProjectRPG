using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string EffectDescription { get; set; }

        public abstract void Use();
    }
}
