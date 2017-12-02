using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class ManaPotion : Item
    {
        public ManaPotion()
        {
            Name = "Mana Potion";
            EffectDescription = "Regain 50% of your Mana";
            Quantity = 0;
        }

        public override void Use()
        {
            Game.Player.Mana += (int)(Game.Player.MaxMana * 0.50);
            Quantity -= 1;
        }
    }
}
