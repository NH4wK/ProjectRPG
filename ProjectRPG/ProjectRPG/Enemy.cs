using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Enemy Class
/// </summary>
/// 
namespace ProjectRPG
{
    public class Enemy
    {
        //Memeber Variables
        public string Name { get; set; }
        public string Type { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public bool IsBoss = false;

        //Default Constructor
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

        //Explicit Value Constructor
        public Enemy(string name, string type, int str, int intel, int dex, int vit)
        {
            Name = name;
            Type = type;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            Vitality = vit;
            Health = Strength * Vitality * 2;
            MaxHealth = Health;
        }

        //Generates an Enemy
        public void GenerateEnemy()
        {
            Random seed = new Random();
            int seedRand = seed.Next(0, 100);
            Random RanVal = new Random(seedRand);

            int StatValue1 = 0;
            int StatValue2 = 0;
            int StatValue3 = 0;
            int StatValue4 = 0;

            //if All Players Stats are maxed, set everything to maxed on the Enemy
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
                //if Player Stats is less than or equal to 10, set Roll Max Stats + 5, otherwise set Roll Max to Players Stats + 10% of Player Stat
                if(Game.Player.Strength <= 10)
                    StatValue1 = RanVal.Next(Game.Player.Strength, ((Game.Player.Strength + (int)(Game.Player.Strength + 5))));
                else
                    StatValue1 = RanVal.Next(Game.Player.Strength, ((Game.Player.Strength + (int)(Game.Player.Strength * 0.10))));

                if(Game.Player.Intelligence <= 10)
                    StatValue2 = RanVal.Next(Game.Player.Intelligence, ((Game.Player.Intelligence + (int)(Game.Player.Intelligence + 5))));
                else
                    StatValue2 = RanVal.Next(Game.Player.Intelligence, ((Game.Player.Intelligence + (int)(Game.Player.Intelligence * 0.10))));

                if(Game.Player.Dexterity <= 10)
                    StatValue3 = RanVal.Next(Game.Player.Dexterity, ((Game.Player.Dexterity + (int)(Game.Player.Dexterity + 5))));
                else
                    StatValue3 = RanVal.Next(Game.Player.Dexterity, ((Game.Player.Dexterity + (int)(Game.Player.Dexterity * 0.10))));

                if(Game.Player.Vitality <= 10)
                    StatValue4 = RanVal.Next(Game.Player.Vitality, ((Game.Player.Vitality + (int)(Game.Player.Vitality + 5))));
                else
                    StatValue4 = RanVal.Next(Game.Player.Vitality, ((Game.Player.Vitality + (int)(Game.Player.Vitality * 0.10))));

                Strength = StatValue1;
                Intelligence = StatValue2;
                Dexterity = StatValue3;
                Vitality = StatValue4;
                Health = (int)(Strength * Vitality * 1.5);
            }

            Name = GenerateEnemyName();
            Type = GenerateEnemyType();

            //If Enemy Health is set to a negative numeber then set it to 0
            if (Game.Enemy.Health < 0)
                Health = 0;

            MaxHealth = Health;

            //Randomly Choose a Weapon for the Enemy
            Random rand = new Random();
            int randVal = rand.Next(0, 7);

            if (randVal == 0)
                Game.EnemyWeapon = new WarHammer(Game.Enemy.Strength);
            else if (randVal == 1)
                Game.EnemyWeapon = new Mace(Game.Enemy.Strength);
            else if (randVal == 2)
                Game.EnemyWeapon = new Broadsword(Game.Enemy.Strength, Game.Enemy.Dexterity);
            else if (randVal == 3)
                Game.EnemyWeapon = new Greatsword(Game.Enemy.Strength, Game.Enemy.Dexterity);
            else if (randVal == 4)
                Game.EnemyWeapon = new Katana(Game.Enemy.Strength, Game.Enemy.Dexterity);
            else if (randVal == 5)
                Game.EnemyWeapon = new SpellTome(Game.Enemy.Strength, Game.Enemy.Intelligence);
            else if (randVal == 6)
                Game.EnemyWeapon = new Staff(Game.Enemy.Strength, Game.Enemy.Intelligence);
            else
                Game.EnemyWeapon = null;
        }

        /// <summary>
        /// Randomly Generate an Enemy Name
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Generate A Random Type for the Enemy
        /// </summary>
        /// <returns></returns>
        public string GenerateEnemyType()
        {
            Random RanVal = new Random();

            string[] type = { "Fire", "Normal", "Ice", "Undead", "Demon", "Raging Demon", "Spirit", "Water" };
            int value = RanVal.Next(0, type.Count());

            return type[value];
        }

        /// <summary>
        /// Set the Enemy to Boss Stats and give them the boss weapon
        /// </summary>
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
                MaxHealth = 999999;
            }
            else
            {
                Strength = (int)(Game.Player.Strength * 2.5);
                Intelligence = (int)(Game.Player.Intelligence * 2.5);
                Dexterity = (int)(Game.Player.Dexterity * 2.5);
                Vitality = (int)(Game.Player.Vitality * 2.5);
                Health = Strength * Vitality * 2;
                MaxHealth = Health;
            }

            Game.EnemyWeapon = new WarHammer((int)(Game.Enemy.Strength * 2.5));
            Game.EnemyWeapon.Name = "Deathhammer of Ra-Zakar (Legendary)";
            IsBoss = true; //Set Boss Flag to true
        }

        /// <summary>
        /// Calculate Enemy Damage
        /// </summary>
        /// <returns></returns>
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
            else //Enemy Missed
                AttackPoints = 0;

            return AttackPoints;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
