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
            GW_XPVal_Label.Text = Convert.ToString(Game.Player.Experience);
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

        private void GW_Attack_Button_Click(object sender, EventArgs e)
        {
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

            Game.Player.LevelUp();
        }
    }
}
