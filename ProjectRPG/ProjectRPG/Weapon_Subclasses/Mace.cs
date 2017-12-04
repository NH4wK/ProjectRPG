﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    class Mace : Weapon
    {
        public Mace()
        {
            Name = "";
            ElementType = "Holy";
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

        public Mace(int StrengthStat)
        {
            Name = GenerateWeapName();
            BaseAttack = StrengthStat * Game.Player.LevelNumber * 3;

            ElementType = "Holy";

            Move1Name = "Blunt Smack";
            Move1Ammo = 30;
            Move1Damage = BaseAttack;
            Move1MaxAmmo = Move1Ammo;

            if (Move1Damage >= 2147483647 || Move1Damage < 0)
                Move1Damage = 2147483647;

            Move2Name = "Blinding Light";
            Move2Ammo = 15;
            Move2Damage = BaseAttack + (int)(BaseAttack * 2);
            Move2MaxAmmo = Move2Ammo;

            if (Move2Damage >= 2147483647 || Move2Damage < 0)
                Move2Damage = 2147483647;

            Move3Name = "Divine Blast";
            Move3Ammo = 15;
            Move3MaxAmmo = Move3Ammo;
            Move3Damage = BaseAttack + (int)(BaseAttack * 2);

            if (Move3Damage >= 2147483647 || Move3Damage < 0)
                Move3Damage = 2147483647;

            Move4Name = "Heaven's Gate";
            Move4Ammo = 3;
            Move4MaxAmmo = Move4Ammo;
            Move4Damage = BaseAttack * 15;

            if (Move4Damage >= 2147483647 || Move4Damage < 0)
                Move4Damage = 2147483647;
        }

        private string GenerateWeapName()
        {
            string[] name = { "From the Heavens", "The Divine", "Armageddon", "The Right Hand of the Almighty", "The Eliminator", "Mace of Yu" };

            Random rand = new Random();
            int randVal = rand.Next(0, name.Count());

            return ($"{name[randVal]} (Mace)");
        }

        public override void UpdateWeapon(int StrengthStat)
        {
            BaseAttack = StrengthStat * Game.Player.LevelNumber * 3;

            Move1Damage = BaseAttack;
            if (Move1Damage >= 2147483647 || Move1Damage < 0)
                Move1Damage = 2147483647;

            Move2Damage = BaseAttack + (int)(BaseAttack * 2);
            if (Move2Damage >= 2147483647 || Move2Damage < 0)
                Move2Damage = 2147483647;

            Move3Damage = BaseAttack + (int)(BaseAttack * 2);
            if (Move3Damage >= 2147483647 || Move3Damage < 0)
                Move3Damage = 2147483647;

            Move4Damage = BaseAttack * 15;
            if (Move4Damage >= 2147483647 || Move4Damage < 0)
                Move4Damage = 2147483647;
        }
    }
}