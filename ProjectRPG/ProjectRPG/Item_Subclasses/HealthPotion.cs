using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Health Potion - Item Sub Class
/// </summary>
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
            //if Player Health + Half Player Health is less than maximum health, Add Half Health to Player.Health, otherwise set Health to MaxHealth
            if ((Game.Player.Health + (int)(Game.Player.MaxHealth * 0.50)) < Game.Player.MaxHealth)
                Game.Player.Health += (int)(Game.Player.MaxHealth * 0.50);
            else
                Game.Player.Health = Game.Player.MaxHealth;

            //Reduce Health Potion Quantity by 1
            Quantity -= 1;
        }
    }
}
