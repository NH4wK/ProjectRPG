using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class Broadsword : Weapon
    {
        public Broadsword()
        {
            Name = "";
            ElementType = "Normal";
            BaseAttack = 0;

            Move1Name = "";
            Move2Name = "";
            Move3Name = "";
            Move4Name = "";

            Move1Ammo = 0;
            Move2Ammo = 0;
            Move3Ammo = 0;
            Move4Ammo = 0;

            Move1MaxAmmo = Move1Ammo;
            Move2MaxAmmo = Move2Ammo;
            Move3MaxAmmo = Move3Ammo;
            Move4MaxAmmo = Move4Ammo;
        }

        public Broadsword(int StrengthStat)
        {
            Name = GenerateWeapName();
            BaseAttack = (StrengthStat) * Game.Player.LevelNumber * 4;

            ElementType = "Normal";

            Move1Name = "Quick Slash";
            Move1Ammo = 30;
            Move1Damage = BaseAttack + (Game.Player.Dexterity * 2);
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 2147483647 || Move1Damage < 0)
                Move1Damage = 2147483647;

            Move2Name = "Sword Dance Fury";
            Move2Ammo = 10;
            Move2Damage = BaseAttack + (int)(BaseAttack / 2) + (Game.Player.Dexterity * 2);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 2147483647 || Move2Damage < 0)
                Move2Damage = 2147483647;

            Move3Name = "Mountainous Swipe";
            Move3Ammo = 10;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = BaseAttack + (int)(BaseAttack / 1.5) + (Game.Player.Dexterity * 2);

            if (Move3Damage >= 2147483647 || Move3Damage < 0)
                Move3Damage = 2147483647;

            Move4Name = "Swordbreaker";
            Move4Ammo = 10;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 7;

            if (Move4Damage >= 2147483647 || Move4Damage < 0)
                Move4Damage = 2147483647;
        }

        private string GenerateWeapName()
        {
            string[] name = { "Sword of the Nine", "King Slayer", "Wise Old One", "Standard", "Useful Sword", "Gleaming Federation" };

            Random rand = new Random();
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (Broadsword)");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = Game.Player.Strength * Game.Player.LevelNumber * 4;
            Move1Damage = BaseAttack + (Game.Player.Dexterity * 2);

            if (Move1Damage >= 2147483647 || Move1Damage < 0)
                Move1Damage = 2147483647;

            Move2Damage = BaseAttack + (int)(BaseAttack / 2) + (Game.Player.Dexterity * 2);

            if (Move2Damage >= 2147483647 || Move2Damage < 0)
                Move2Damage = 2147483647;

            Move3Damage = BaseAttack + (int)(BaseAttack / 2.5) + (Game.Player.Dexterity * 2);

            if (Move3Damage >= 2147483647 || Move3Damage < 0)
                Move3Damage = 2147483647;

            Move4Damage = BaseAttack * 7;

            if (Move4Damage >= 2147483647 || Move4Damage < 0)
                Move4Damage = 2147483647;
        }
    }
}
