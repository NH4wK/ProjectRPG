using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    public class Enemy
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Health { get; set; }

        public Enemy()
        {
            Name = "";
            Type = "";
            Strength = 0;
            Intelligence = 0;
            Dexterity = 0;
            Vitality = 0;
            Health = 0;
        }

        public Enemy(string name, string type, int str, int intel, int dex, int vit)
        {
            Name = name;
            Type = type;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Vitality = vit;
            Health = Strength * Vitality * 2;
        }

        public void GenerateEnemy()
        {
            Random RanVal = new Random();
            int StatValue1 = RanVal.Next(Game.Player.Strength, Game.Player.Strength + 10);
            int StatValue2 = RanVal.Next(Game.Player.Intelligence, Game.Player.Intelligence + 10);
            int StatValue3 = RanVal.Next(Game.Player.Dexterity, Game.Player.Dexterity + 10);
            int StatValue4 = RanVal.Next(Game.Player.Vitality, Game.Player.Vitality + 10);

            Name = GenerateEnemyName();
            Type = GenerateEnemyType();

            Strength = StatValue1;
            Intelligence = StatValue2;
            Dexterity = StatValue3;
            Vitality = StatValue4;

            Health = Strength * Vitality * 2;            
        }

        public string GenerateEnemyName()
        {
            Random RanVal = new Random();

            string[] name = { "Vargan", "Kulgha", "Nag", "Slughig", "Yolmar",
                                "Slaugh", "Nurghed", "Ogharod", "Nargulg",
                                    "Shurkul", "Urog", "Bor", "Glasha", "Uloth",
                                        "Bagrak", "Ugak", "Gharol", "Ghak", "Koloth"};
            string[] adjective = { "Impaler", "Soft", "Courageous", "Basher",
                                      "Fat", "Fighter", "Powerful", "Full", "Tough",
                                            "Unbroken", "Unchained", "Deserving", "Jealous",
                                                    "Destroyer", "Small", "Large", "Blind",
                                                          "Giant", "Hand", "Warrior","Mighty", "Defiant"};

            int Value1 = RanVal.Next(0, name.Count());
            int Value2 = RanVal.Next(0, adjective.Count());
            string nameResult = name[Value1] + " " + "the" + " "+ adjective[Value2];

            return nameResult;
        }

        public string GenerateEnemyType()
        {
            Random RanVal = new Random();

            string[] type = { "Fire", "Normal", "Ice", "Undead" };
            int Value = RanVal.Next(0, type.Count());

            return type[Value];
        }



    }
}
