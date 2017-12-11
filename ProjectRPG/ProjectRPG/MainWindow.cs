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
            //Open Player Creation Form
            PlayerCreationForm playerCF = new PlayerCreationForm();
            playerCF.ShowDialog();
        }

        private void MainMenu_ExitButton_Click(object sender, EventArgs e)
        {
            //Exit Application
            Application.Exit();
        }

        private void MainMenu_HowToPlay_Button_Click(object sender, EventArgs e)
        {
            //Open How To Play Form
            HowToPlayWindow HTPForm = new HowToPlayWindow();
            HTPForm.ShowDialog();
        }

        private void MainMenu_StartButton_MouseHover(object sender, EventArgs e)
        {
            Game.SPlayerMainMenu.Play();
            MainMenu_StartButton.ImageIndex = 1;
        }

        private void MainMenu_StartButton_MouseLeave(object sender, EventArgs e)
        {

            MainMenu_StartButton.ImageIndex = 0;
        }

        private void MainMenu_HowToPlay_Button_MouseHover(object sender, EventArgs e)
        {
            Game.SPlayerMainMenu.Play();
            MainMenu_HowToPlay_Button.ImageIndex = 1;
        }

        private void MainMenu_HowToPlay_Button_MouseLeave(object sender, EventArgs e)
        {
            MainMenu_HowToPlay_Button.ImageIndex = 0;
        }

        private void MainMenu_ExitButton_MouseHover(object sender, EventArgs e)
        {
            Game.SPlayerMainMenu.Play();
            MainMenu_ExitButton.ImageIndex = 1;
        }

        private void MainMenu_ExitButton_MouseLeave(object sender, EventArgs e)
        {
            MainMenu_ExitButton.ImageIndex = 0;
        }
    }
}
