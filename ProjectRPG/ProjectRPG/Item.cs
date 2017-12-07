using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Item Class
/// </summary>
namespace ProjectRPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string EffectDescription { get; set; }
        public int Quantity { get; set; }

        public abstract void Use();
    }
}
