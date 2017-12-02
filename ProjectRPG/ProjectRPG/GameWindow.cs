using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectRPG
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            EnemyInit();
            CharacterInit();
            InventoryInit();
            MenuInit();

        }
        void CharacterInit()
        {
            Game.Player.SetHealthPool();
            Game.Player.SetManaPool();
            GW_ChName_Label.Text = Game.Player.Name;
            GW_HPVal_Label.Text = Convert.ToString(Game.Player.Health);
            GW_MPVal_Label.Text = Convert.ToString(Game.Player.Mana);
            GW_XPVal_Label.Text = ($"{ Convert.ToString(Game.Player.Experience)} / 100");
            GW_LevelVal_Label.Text = Convert.ToString(Game.Player.LevelNumber);
            GW_StrVal_Label.Text = Convert.ToString(Game.Player.Strength);
            GW_IntelVal_Label.Text = Convert.ToString(Game.Player.Intelligence);
            GW_DexVal_Label.Text = Convert.ToString(Game.Player.Dexterity);
            GW_VitVal_Label.Text = Convert.ToString(Game.Player.Vitality);

            Game.PlayerWeapon = new WarHammer(Game.Player.Strength);
            Game.PlayerHealthPotion = new HealthPotion();
            Game.PlayerManaPotion = new ManaPotion();

            PlayerWeaponUpdate();

            /*
            Random rand = new Random();
            int randVal = rand.Next(0, 6);
            
            if (randVal == 0)
                Game.PlayerWeapon = new Warhammer();
            else if(randVal == 1)
                Game.PlayerWeapon = new Mace();
            else if(randVal == 2)
                Game.PlayerWeapon = new Broadsword();
            else if(randVal == 3)
                Game.PlayerWeapon = new Greatsword();
            else if(randVal == 4)
                Game.PlayerWeapon = new Katana();
            else if(randVal == 5)
                Game.PlayerWeapon = new Wand();
            else if(randVal == 6)
                Game.PlayerWeapon = new Staff();
            else
                Game.PlayerWeapon = new Weapon();
            */
        }
        void MenuInit()
        {
            GW_Weapon_Panel.Hide();
            GW_Inventory_Panel.Hide();
        }

        void InventoryInit()
        {
            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";            
        }

        void EnemyInit()
        {
            Game.Enemy = new Enemy();
            Game.Enemy.GenerateEnemy();
            Game.EnemyWeapon = new WarHammer(Game.Enemy.Strength);

            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = Convert.ToString(Game.Enemy.Health);
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
        }
        void PlayerWeaponUpdate()
        {
            GW_WeaponName_Label.Text = Game.PlayerWeapon.Name;
            GW_WeapMove1_RadButton.Text = Game.PlayerWeapon.Move1Name;
            GW_WeapMove2_RadButton.Text = Game.PlayerWeapon.Move2Name;
            GW_WeapMove3_RadButton.Text = Game.PlayerWeapon.Move3Name;
            GW_WeapMove4_RadButton.Text = Game.PlayerWeapon.Move4Name;

            GW_M1AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move1Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move1MaxAmmo)}";
            GW_M2AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move2Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move2MaxAmmo)}";
            GW_M3AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move3Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move3MaxAmmo)}";
            GW_M4AmmoCount_Label.Text = $"{Convert.ToString(Game.PlayerWeapon.Move4Ammo)} / {Convert.ToString(Game.PlayerWeapon.Move4MaxAmmo)}";

            Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength);
        }
        void PlayerUpdate()
        {
            if (Game.Player.Health <= 0)
            {
                Game.Player.Health = 0;
                GW_HPVal_Label.Text = Convert.ToString(Game.Player.Health);
                
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has been slained by {Game.Enemy.Name}!");
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine} You have been revived by an unknown force, you feel weaker... (Stats reduced by 10%)");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

                Game.Player.Strength -= (int)(Game.Player.Strength * 0.10);
                Game.Player.Intelligence -= (int)(Game.Player.Intelligence * 0.10);
                Game.Player.Dexterity -= (int)(Game.Player.Dexterity * 0.10);
                Game.Player.Vitality -= (int)(Game.Player.Vitality * 0.10);

                Game.Player.SetHealthPool();
                Game.Player.SetManaPool();
                PlayerUpdate();

                return;
            }

            if (Game.Player.Experience >= 100)
            {
                if (Game.Player.Experience >= 100)
                    Game.Player.Experience = Game.Player.Experience - 100;
                else
                    Game.Player.Experience = 0;

                Game.Player.LevelUp();
            }

            Game.PlayerWeapon.UpdateWeapon(Game.Player.Strength);

            //Update Labels
            GW_HPVal_Label.Text = Convert.ToString(Game.Player.Health);
            GW_MPVal_Label.Text = Convert.ToString(Game.Player.Mana);
            GW_XPVal_Label.Text = ($"{ Convert.ToString(Game.Player.Experience)} / 100");
            GW_LevelVal_Label.Text = Convert.ToString(Game.Player.LevelNumber);
            GW_StrVal_Label.Text = Convert.ToString(Game.Player.Strength);
            GW_IntelVal_Label.Text = Convert.ToString(Game.Player.Intelligence);
            GW_DexVal_Label.Text = Convert.ToString(Game.Player.Dexterity);
            GW_VitVal_Label.Text = Convert.ToString(Game.Player.Vitality);
        }
        void EnemyUpdate()
        {
            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = Convert.ToString(Game.Enemy.Health);
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);

            Game.EnemyWeapon.UpdateWeapon(Game.Enemy.Strength);
        }

        private void GW_Attack_Button_Click(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = false;
            GW_WeapMove1_RadButton.Checked = false;
            GW_WeapMove2_RadButton.Checked = false;
            GW_WeapMove3_RadButton.Checked = false;
            GW_WeapMove4_RadButton.Checked = false;

            if (!GW_Weapon_Panel.Visible)
            {
                GW_Weapon_Panel.Show();
                GW_Inventory_Panel.Hide();
            }
            else
                GW_Weapon_Panel.Hide();
        }
        private void GW_Items_Button_Click(object sender, EventArgs e)
        {
            if (!GW_Inventory_Panel.Visible)
            {
                GW_Inventory_Panel.Show();
                GW_Weapon_Panel.Hide();
            }
            else
                GW_Inventory_Panel.Hide();
        }

        private void GW_ExecMove_Button_Click(object sender, EventArgs e)
        {
            GW_Weapon_Panel.Hide();

            int pDamage = 0, eDamage;

            if (GW_WeapMove1_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move1Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move1Damage;
                    Game.PlayerWeapon.Move1Ammo -= 1;
                }
            }
            else if (GW_WeapMove2_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move2Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move2Damage;
                    Game.PlayerWeapon.Move2Ammo -= 1;
                }
            }
            else if (GW_WeapMove3_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move3Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move3Damage;
                    Game.PlayerWeapon.Move3Ammo -= 1;
                }
            }
            else if (GW_WeapMove4_RadButton.Checked)
            {
                if (Game.PlayerWeapon.Move4Ammo > 0)
                {
                    pDamage = Game.PlayerWeapon.Move4Damage;
                    Game.PlayerWeapon.Move4Ammo -= 1;
                }
            }
            else
            {
                pDamage = 0;
            }

            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} attacked {Game.Enemy.Name} for {pDamage} Damage!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            //Player Turn
            Game.Enemy.Health -= pDamage;
            GW_EnemyHealthVal_Label.Text = Convert.ToString(Game.Enemy.Health);

            if (Game.Enemy.Health <= 0)
            {
                GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} has been slained. You have absorbed {Game.Enemy.Name}'s power!");
                GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
                GW_BattleAction_TextBox.ScrollToCaret();

                Game.Player.Strength += Game.Enemy.Strength;
                Game.Player.Intelligence += Game.Enemy.Intelligence;
                Game.Player.Dexterity += Game.Enemy.Dexterity;
                Game.Player.Vitality += Game.Enemy.Vitality;
                Game.Player.Experience += 75;

                Game.Player.SetHealthPool();
                Game.Player.SetManaPool();

                Game.Enemy.GenerateEnemy();

                PlayerUpdate();
                EnemyUpdate();
            }

            //Enemy Turn
            eDamage = Game.Enemy.Attack();
            Game.Player.Health -= eDamage;
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Enemy.Name} attacked {Game.Player.Name} for {eDamage} Damage!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerUpdate();
            PlayerWeaponUpdate();
        }

        private void GW_WeapMove1_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_WeapMove2_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_WeapMove3_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_WeapMove4_RadButton_CheckedChanged(object sender, EventArgs e)
        {
            GW_ExecMove_Button.Enabled = true;
        }

        private void GW_Defend_Button_Click(object sender, EventArgs e)
        {
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} goes into a defensive stance!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }

        private void GW_Retreat_Button_Click(object sender, EventArgs e)
        {
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has retreated!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();
        }

        private void GW_HPPotUse_Button_Click(object sender, EventArgs e)
        {
            Game.PlayerHealthPotion.Use();
            GW_QuantHPot_Label.Text = $"Quantity: {Game.PlayerHealthPotion.Quantity}";
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has used a Health Potion! Restored {Game.Player.MaxHealth * 0.50} Health");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerUpdate();
        }

        private void GW_MPPotUse_Button_Click(object sender, EventArgs e)
        {
            Game.PlayerManaPotion.Use();
            GW_QuantMPot_Label.Text = $"Quantity: {Game.PlayerManaPotion.Quantity}";
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} has used a Mana Potion! Restored {Game.Player.MaxMana * 0.50} Mana");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();

            PlayerUpdate();
        }

        private void GW_WeapEquip_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
