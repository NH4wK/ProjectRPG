using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public class Player
    {
        public string Name { get { return Name; } private set { Name = value; } }
        public int Strength { get { return Strength; } private set { Strength = value; } }
        public int Intelligence { get { return Intelligence; } private set { Intelligence = value; } }
        public int Dexterity { get { return Dexterity; } private set { Dexterity = value; } }
        public int Vitality { get { return Vitality; } private set { Vitality = value; } }
        public int Health { get { return Health;  } private set { Health = (Vitality * 4); } }
        public int Mana { get { return Mana; } private set { Mana = (Intelligence * 6); } }

        public Player()
        {
            Name = "";
            Strength = 0;
            Intelligence = 0;
            Dexterity = 0;
            Vitality = 0;
        }

        public Player(string name, int str, int intel, int dex, int vit)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Vitality = vit;
        }
    }
}
