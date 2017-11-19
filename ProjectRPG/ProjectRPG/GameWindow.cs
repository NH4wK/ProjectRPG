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


        /*
        private void TestStrength_Button_Click(object sender, EventArgs e)
        {
            Game.Player.Strength += 100;
            GW_StrVal_Label.Text = Convert.ToString(Game.Player.Strength);
            Game.Player.SetHealthPool();
            GW_HPVal_Label.Text = Convert.ToString(Game.Player.Health);

        }
        */
    }
}
