using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Mana Potion - Item Sub Class
/// </summary>
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
            //if Player Mana + Half Player Mana is less than maximum health, Add Half Mana to Player Mana, otherwise set Mana to MaxMana           
            if ((Game.Player.Mana + (int)(Game.Player.MaxMana * 0.50)) < Game.Player.MaxMana)
                Game.Player.Mana += (int)(Game.Player.MaxMana * 0.50);
            else
                Game.Player.Mana = Game.Player.MaxMana;

            //Reduce Mana Potion Quantity by 1
            Quantity -= 1;
        }
    }
}
