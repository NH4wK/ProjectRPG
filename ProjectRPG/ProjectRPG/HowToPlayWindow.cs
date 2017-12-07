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
/// ProjectRPG - How To Play Window
/// </summary>
namespace ProjectRPG
{
    public partial class HowToPlayWindow : Form
    {
        public HowToPlayWindow()
        {
            InitializeComponent();
        }

        private void HTP_Exit_Button_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
