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
    public partial class HowToPlayWindow : Form
    {

        public static int PageCount = 0;

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
