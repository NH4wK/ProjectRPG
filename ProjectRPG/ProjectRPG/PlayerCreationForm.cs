using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Name: Paul Jerrold Biglete
/// RedID: 8115430506
/// ProjectRPG - Player Creation Form
/// </summary>
namespace ProjectRPG
{
    public partial class PlayerCreationForm : Form
    {
        private static decimal StrRollValInit { get; set; }
        private static decimal IntelRollValInit { get; set; }
        private static decimal DexRollValInit { get; set; }
        private static decimal VitRollValInit { get; set; }

        public PlayerCreationForm()
        {
            InitializeComponent();
        }

        void MenuInit()
        {
            //Disable Create Button and NumUpDown Buttons initially
            CC_Create_Button.Enabled = false;
            Str_NumUpDown.Enabled = false;
            Intel_NumUpDown.Enabled = false;
            Dex_NumUpDown.Enabled = false;
            Vit_NumUpDown.Enabled = false;

            //Set up tooltips
            CC_ToolTips.SetToolTip(CharName_TextBox, "Enter a name for your character!");
            CC_ToolTips.SetToolTip(CC_Create_Button, "Create your character!");
            CC_ToolTips.SetToolTip(ReRoll_Button, "Roll random stats for your character!");
            CC_ToolTips.SetToolTip(Str_NumUpDown, "Adjust Strength by +/- 2!");
            CC_ToolTips.SetToolTip(Intel_NumUpDown, "Adjust Intelligence by +/- 2!");
            CC_ToolTips.SetToolTip(Dex_NumUpDown, "Adjust Dexterity by +/- 2!");
            CC_ToolTips.SetToolTip(Vit_NumUpDown, "Adjust Vitality by +/- 2!");

            CC_ToolTips.SetToolTip(Strength_Label, "Affects Health and significantly affects Weapon Damage for Maces / Warhammers");
            CC_ToolTips.SetToolTip(Intelligence_Label, "Significantly affects Weapon Damage for Spell Tomes / Staffs");
            CC_ToolTips.SetToolTip(Dex_Label, "Significantly affects Weapon Damage for Swords");
            CC_ToolTips.SetToolTip(Vit_Label, "Affects Health");
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

            //Re-enable Button and NumUpDown Buttons
            CC_Create_Button.Enabled = true;
            Str_NumUpDown.Enabled = true;
            Intel_NumUpDown.Enabled = true;
            Dex_NumUpDown.Enabled = true;
            Vit_NumUpDown.Enabled = true;

            Random seed = new Random();
            int RanValSeed = seed.Next(1, 100);
            Random RanVal = new Random(RanValSeed);
            int StatValue1 = RanVal.Next(4, 18);
            int StatValue2 = RanVal.Next(4, 18);
            int StatValue3 = RanVal.Next(4, 18);
            int StatValue4 = RanVal.Next(6, 18);

            Str_NumUpDown.Value = StatValue1;
            Intel_NumUpDown.Value = StatValue2;
            Dex_NumUpDown.Value = StatValue3;
            Vit_NumUpDown.Value = StatValue4;

            //Temporarily Store Values for NumUpDown ValueChange Conditions
            StrRollValInit = Str_NumUpDown.Value;
            IntelRollValInit = Intel_NumUpDown.Value;
            DexRollValInit = Dex_NumUpDown.Value;
            VitRollValInit = Vit_NumUpDown.Value;
        }

        private void Create_Button_Click(object sender, EventArgs e)
        {
            Game.SPlayerMainMenu.Play();
            //Create a new player object and assign values to the player object
            Game.Player = new Player();
            Game.Player.Name = CharName_TextBox.Text;
            Game.Player.Strength = Convert.ToInt32(Str_NumUpDown.Value);
            Game.Player.Intelligence = Convert.ToInt32(Intel_NumUpDown.Value);
            Game.Player.Dexterity = Convert.ToInt32(Dex_NumUpDown.Value);
            Game.Player.Vitality = Convert.ToInt32(Vit_NumUpDown.Value);

            this.Close(); //Close Creation Window
            this.Dispose(); //Dispose Creation Window
            Game.CreateGameWindow(); // Open Up Game Window
        }

        private void Str_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Editing range of this stat is plus or minus 2 of the original roll.
            if (Str_NumUpDown.Value > (StrRollValInit + 2))
                Str_NumUpDown.Value = StrRollValInit + 2;

            if (Str_NumUpDown.Value < (StrRollValInit - 2))
                Str_NumUpDown.Value = StrRollValInit - 2;
        }

        private void Intel_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Editing range of this stat is plus or minus 2 of the original roll.
            if (Intel_NumUpDown.Value > (IntelRollValInit + 2))
                Intel_NumUpDown.Value = IntelRollValInit + 2;

            if (Intel_NumUpDown.Value < (IntelRollValInit - 2))
                Intel_NumUpDown.Value = IntelRollValInit - 2;
        }

        private void Dex_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Editing range of this stat is plus or minus 2 of the original roll.
            if (Dex_NumUpDown.Value > (DexRollValInit + 2))
                Dex_NumUpDown.Value = DexRollValInit + 2;

            if (Dex_NumUpDown.Value < (DexRollValInit - 2))
                Dex_NumUpDown.Value = DexRollValInit - 2;
        }

        private void Vit_NumUpDown_ValueChanged(object sender, EventArgs e)
        {
            //Editing range of this stat is plus or minus 2 of the original roll.
            if (Vit_NumUpDown.Value > (VitRollValInit + 2))
                Vit_NumUpDown.Value = VitRollValInit + 2;

            if (Vit_NumUpDown.Value < (VitRollValInit - 2))
                Vit_NumUpDown.Value = VitRollValInit - 2;
        }

        private void CC_Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void PlayerCreationForm_Load(object sender, EventArgs e)
        {
            MenuInit();
        }
    }
}
