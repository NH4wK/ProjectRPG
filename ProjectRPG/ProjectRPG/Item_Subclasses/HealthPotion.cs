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
            EffectDescription = "Regain 50% of your Health";
            Quantity = 0;
        }

        public override void Use()
        {
            if ((Game.Player.Health + (int)(Game.Player.MaxHealth * 0.50)) < Game.Player.MaxHealth)
                Game.Player.Health += (int)(Game.Player.MaxHealth * 0.50);
            else
                Game.Player.Health = Game.Player.MaxHealth;

            Quantity -= 1;
        }
    }
}
