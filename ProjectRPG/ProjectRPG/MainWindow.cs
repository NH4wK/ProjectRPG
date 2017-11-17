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
    public partial class ProjectRPG_MainForm : Form
    {
        public ProjectRPG_MainForm()
        {
            InitializeComponent();
        }

        private void MainMenu_StartButton_Click(object sender, EventArgs e)
        {
            PlayerCreationForm PlayerCF = new PlayerCreationForm();
            PlayerCF.ShowDialog();
            
        }
    }
}
