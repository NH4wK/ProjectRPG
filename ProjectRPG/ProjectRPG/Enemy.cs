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
        public int MaxHealth { get; set; }
        public bool IsBoss = false;

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
            Health = Strength * Vitality;
            MaxHealth = Health;
        }

        public void GenerateEnemy()
        {
            Random RanVal = new Random();

            int StatValue1 = 0;
            int StatValue2 = 0;
            int StatValue3 = 0;
            int StatValue4 = 0;

            if (Game.Player.Strength == 999 && Game.Player.Intelligence == 999 && Game.Player.Dexterity == 999 && Game.Player.Vitality == 999)
            {
                Strength = 999;
                Intelligence = 999;
                Dexterity = 999;
                Vitality = 999;
                Health = 999999;
            }
            else
            { 
                StatValue1 = RanVal.Next(Game.Player.Strength, ((Game.Player.Strength + (int)(Game.Player.Strength * 0.10))));
                StatValue2 = RanVal.Next(Game.Player.Intelligence, ((Game.Player.Intelligence + (int)(Game.Player.Intelligence * 0.10))));
                StatValue3 = RanVal.Next(Game.Player.Dexterity, ((Game.Player.Dexterity + (int)(Game.Player.Dexterity * 0.10))));
                StatValue4 = RanVal.Next(Game.Player.Vitality, ((Game.Player.Vitality + (int)(Game.Player.Vitality * 0.10))));

                Strength = StatValue1;
                Intelligence = StatValue2;
                Dexterity = StatValue3;
                Vitality = StatValue4;
                Health = Strength * Vitality;
            }
            Name = GenerateEnemyName();
            Type = GenerateEnemyType();


            if (Game.Enemy.Health < 0)
                Health = 999999;

            MaxHealth = Health;

            //Randomly Choose a Weapon for the Player
            Random rand = new Random();
            int randVal = rand.Next(0, 6);

            if (randVal == 0)
                Game.EnemyWeapon = new WarHammer(Game.Enemy.Strength);
            else if (randVal == 1)
                Game.EnemyWeapon = new Mace(Game.Enemy.Strength);
            else if (randVal == 2)
                Game.EnemyWeapon = new Broadsword(Game.Enemy.Strength);
            else if (randVal == 3)
                Game.EnemyWeapon = new Greatsword(Game.Enemy.Strength);
            else if (randVal == 4)
                Game.EnemyWeapon = new Katana(Game.Enemy.Strength);
            else if (randVal == 5)
                Game.EnemyWeapon = new SpellTome(Game.Enemy.Strength);
            else if (randVal == 6)
                Game.EnemyWeapon = new Staff(Game.Enemy.Strength);
            else
                Game.EnemyWeapon = null;
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

            int value1 = RanVal.Next(0, name.Count());
            int value2 = RanVal.Next(0, adjective.Count());
            string nameResult = name[value1] + " " + "the" + " "+ adjective[value2];

            return nameResult;
        }

        public string GenerateEnemyType()
        {
            Random RanVal = new Random();

            string[] type = { "Fire", "Normal", "Ice", "Undead" };
            int value = RanVal.Next(0, type.Count());

            return type[value];
        }

        public void SetToBoss()
        {
            Name = ($"{Game.Enemy.Name} (Boss)");

            if (Game.Player.Strength == 999 && Game.Player.Intelligence == 999 && Game.Player.Dexterity == 999 && Game.Player.Vitality == 999)
            {
                Strength = 999;
                Intelligence = 999;
                Dexterity = 999;
                Vitality = 999;
                Health = 999999;
            }
            else
            {
                Strength = (int)(Game.Player.Strength * 2.5);
                Intelligence = (int)(Game.Player.Intelligence * 2.5);
                Dexterity = (int)(Game.Player.Dexterity * 2.5);
                Vitality = (int)(Game.Player.Vitality * 2.5);
            }

            Game.EnemyWeapon = new WarHammer((int)(Game.Enemy.Strength * 1.5));
            Game.EnemyWeapon.Name = "Deathhammer of Ra-Zakar (Legendary)";
            IsBoss = true;
        }

        public int Attack()
        {
            int AttackPoints;

            Random RanVal = new Random();

            int value = RanVal.Next(1, 6);

            if (value == 1)
                AttackPoints = Game.EnemyWeapon.Move1Damage;
            else if (value == 2)
                AttackPoints = Game.EnemyWeapon.Move2Damage;
            else if (value == 3)
                AttackPoints = Game.EnemyWeapon.Move3Damage;
            else if (value == 4)
                AttackPoints = Game.EnemyWeapon.Move4Damage;
            else
                AttackPoints = 0;

            return AttackPoints;
        }
    }
}
