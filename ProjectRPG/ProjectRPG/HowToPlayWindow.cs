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
        public static int PageCount = 0;

        public HowToPlayWindow()
        {
            InitializeComponent();
        }

        void MenuInit()
        {
            HTP_PREVIOUS_BUTTON.Enabled = false;
        }

        private void HTP_Exit_Button_Click(object sender, EventArgs e)
        {
            PageCount = 0;
            this.Close();
            this.Dispose();
        }

        private void HTP_NEXT_BUTTON_Click(object sender, EventArgs e)
        {
            HTP_PREVIOUS_BUTTON.Enabled = true;

            if(PageCount >= 0 && PageCount < 6)
                PageCount += 1;

            if (PageCount >= 6)
            {
                HTP_NEXT_BUTTON.Enabled = false;
                PageCount = 5;
            }
            else
            {
                HTP_NEXT_BUTTON.Enabled = true;
            }
          
            switch (PageCount)
            {
                case 0:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step1;
                    break;
                case 1:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step2;
                    break;
                case 2:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step3;
                    break;
                case 3:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step4;
                    break;
                case 4:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step5;
                    break;
                case 5:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step6;
                    break;
                default:
                    break;
            }
        }

        private void HTP_PREVIOUS_BUTTON_Click(object sender, EventArgs e)
        {
            if (PageCount >= 0 && PageCount < 6)
                PageCount -= 1;

            if (PageCount < 0)
            {
                HTP_PREVIOUS_BUTTON.Enabled = false;
                HTP_NEXT_BUTTON.Enabled = true;
                PageCount = 0;
            }
            else
            {
                HTP_PREVIOUS_BUTTON.Enabled = true;
            }

            //Display the proper how to play image
            switch (PageCount)
            {
                case 0:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step1;
                    break;
                case 1:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step2;
                    break;
                case 2:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step3;
                    break;
                case 3:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step4;
                    break;
                case 4:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step5;
                    break;
                case 5:
                    HTP_HowToPlay_PicBox.Image = ProjectRPG.Properties.Resources.HowToPlay_Step6;
                    break;
                default:
                    break;
            }
        }

        private void HowToPlayWindow_Load(object sender, EventArgs e)
        {
            MenuInit();
        }
    }
}
