using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class HealthPotion : Item
    {
        public HealthPotion()
        {
            Name = "Health Potion";
            EffectDescription = "Regain 75% of your Health";
        }

        public override void Use()
        {
            Game.Player.Health += (int)(Game.Player.Health * 0.75);
        }
    }
}
