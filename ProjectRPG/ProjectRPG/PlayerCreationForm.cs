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
    public partial class PlayerCreationForm : Form
    {
        public PlayerCreationForm()
        {
            InitializeComponent();
        }

        private void CharName_TextBox_Click(object sender, EventArgs e)
        {
            CharName_TextBox.Text = "";
        }

        private void CharName_TextBox_Leave(object sender, EventArgs e)
        {
            if (CharName_TextBox.Text == "")
            {
                CharName_TextBox.Text = "PlayerName";
            }
        }

        private void ReRoll_Button_Click(object sender, EventArgs e)
        {
            ReRoll_Button.Text = "Re-Roll";
            Random RanVal = new Random();
            int StatValue1 = RanVal.Next(1, 12);
            int StatValue2 = RanVal.Next(1, 12);
            int StatValue3 = RanVal.Next(1, 12);
            int StatValue4 = RanVal.Next(1, 12);

            Str_NumUpDown.Value = StatValue1;
            Intel_NumUpDown.Value = StatValue2;
            Dex_NumUpDown.Value = StatValue3;
            Vit_NumUpDown.Value = StatValue4;
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            Game.Player = new Player();
            Game.Player.Name = CharName_TextBox.Text;
            Game.Player.Strength = Convert.ToInt32(Str_NumUpDown.Value);
            Game.Player.Intelligence = Convert.ToInt32(Intel_NumUpDown.Value);
            Game.Player.Dexterity = Convert.ToInt32(Dex_NumUpDown.Value);
            Game.Player.Vitality = Convert.ToInt32(Vit_NumUpDown.Value);

            this.Close();
            this.Dispose();
        }

    }
}
