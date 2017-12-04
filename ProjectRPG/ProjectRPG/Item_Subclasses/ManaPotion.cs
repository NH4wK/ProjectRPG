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
            if ((Game.Player.Mana + (int)(Game.Player.MaxMana * 0.50)) < Game.Player.MaxMana)
                Game.Player.Mana += (int)(Game.Player.MaxMana * 0.50);
            else
                Game.Player.Mana = Game.Player.MaxMana;

            Quantity -= 1;
        }
    }
}
