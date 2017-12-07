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
/// ProjectRPG -  Main Window
/// </summary>
namespace ProjectRPG
{
    public partial class ProjectRPG_MainForm : Form
    {
        public ProjectRPG_MainForm()
        {
            InitializeComponent();
        }

        private void MainMenu_StartButton_Click(object sender, EventArgs e)
        {
            PlayerCreationForm playerCF = new PlayerCreationForm();
            playerCF.ShowDialog();
        }

        private void MainMenu_ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenu_HowToPlay_Button_Click(object sender, EventArgs e)
        {
            HowToPlayWindow HTPForm = new HowToPlayWindow();
            HTPForm.ShowDialog();
        }
    }
}
