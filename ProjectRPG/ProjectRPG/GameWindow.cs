﻿using System;
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
            CharacterInit();
            MenuInit();
            EnemyInit();
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
        }
        void MenuInit()
        {
            GW_Weapon_Panel.Hide();
            GW_Inventory_Panel.Hide();
        }
        void EnemyInit()
        {
            Game.Enemy = new Enemy();
            Game.Enemy.GenerateEnemy();

            GW_EnemyName_Label.Text = Game.Enemy.Name;
            GW_EnemyHealthVal_Label.Text = Convert.ToString(Game.Enemy.Health);
            GW_EnemyTypeVal_Label.Text = Game.Enemy.Type;
            GW_EnemyStrVal_Label.Text = Convert.ToString(Game.Enemy.Strength);
            GW_EnemyIntelVal_Label.Text = Convert.ToString(Game.Enemy.Intelligence);
            GW_EnemyDexVal_Label.Text = Convert.ToString(Game.Enemy.Dexterity);
            GW_EnemyVitVal_Label.Text = Convert.ToString(Game.Enemy.Vitality);
        }

        void PlayerUpdate()
        {
            if (Game.Player.Experience > 100)
            {
                if (Game.Player.Experience > 100)
                    Game.Player.Experience = Game.Player.Experience - 100;
                else
                    Game.Player.Experience = 0;

                Game.Player.LevelUp();
            }

            Game.Player.SetHealthPool();
            Game.Player.SetManaPool();
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
            GW_BattleAction_TextBox.Text += ($"{Environment.NewLine}{Game.Player.Name} attacked {Game.Enemy.Name} for ___ Damage!");
            GW_BattleAction_TextBox.SelectionStart = GW_BattleAction_TextBox.Text.Length;
            GW_BattleAction_TextBox.ScrollToCaret();


            Game.Enemy.Health -= 100;
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

                Game.Enemy.GenerateEnemy();
                PlayerUpdate();
                EnemyUpdate();
            }
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
    }
}
