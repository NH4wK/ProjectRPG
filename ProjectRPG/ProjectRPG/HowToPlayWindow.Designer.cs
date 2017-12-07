namespace ProjectRPG
{
    partial class HowToPlayWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HowToPlayWindow));
            this.HTP_HowToPlay_Panel = new System.Windows.Forms.Panel();
            this.HTP_HowToPlay_PicBox = new System.Windows.Forms.PictureBox();
            this.HTP_Exit_Button = new System.Windows.Forms.Button();
            this.HTP_HowToPlay_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HTP_HowToPlay_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // HTP_HowToPlay_Panel
            // 
            this.HTP_HowToPlay_Panel.Controls.Add(this.HTP_Exit_Button);
            this.HTP_HowToPlay_Panel.Controls.Add(this.HTP_HowToPlay_PicBox);
            this.HTP_HowToPlay_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HTP_HowToPlay_Panel.Location = new System.Drawing.Point(0, 0);
            this.HTP_HowToPlay_Panel.Name = "HTP_HowToPlay_Panel";
            this.HTP_HowToPlay_Panel.Size = new System.Drawing.Size(1277, 720);
            this.HTP_HowToPlay_Panel.TabIndex = 0;
            // 
            // HTP_HowToPlay_PicBox
            // 
            this.HTP_HowToPlay_PicBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HTP_HowToPlay_PicBox.Image = ((System.Drawing.Image)(resources.GetObject("HTP_HowToPlay_PicBox.Image")));
            this.HTP_HowToPlay_PicBox.Location = new System.Drawing.Point(0, 0);
            this.HTP_HowToPlay_PicBox.Name = "HTP_HowToPlay_PicBox";
            this.HTP_HowToPlay_PicBox.Size = new System.Drawing.Size(1277, 720);
            this.HTP_HowToPlay_PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HTP_HowToPlay_PicBox.TabIndex = 0;
            this.HTP_HowToPlay_PicBox.TabStop = false;
            // 
            // HTP_Exit_Button
            // 
            this.HTP_Exit_Button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HTP_Exit_Button.Location = new System.Drawing.Point(1112, 68);
            this.HTP_Exit_Button.Name = "HTP_Exit_Button";
            this.HTP_Exit_Button.Size = new System.Drawing.Size(127, 97);
            this.HTP_Exit_Button.TabIndex = 3;
            this.HTP_Exit_Button.Text = "EXIT";
            this.HTP_Exit_Button.UseVisualStyleBackColor = true;
            this.HTP_Exit_Button.Click += new System.EventHandler(this.HTP_Exit_Button_Click);
            // 
            // HowToPlayWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 720);
            this.Controls.Add(this.HTP_HowToPlay_Panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(1299, 771);
            this.MinimumSize = new System.Drawing.Size(1299, 771);
            this.Name = "HowToPlayWindow";
            this.Text = "ProjectRPG - How To Play";
            this.HTP_HowToPlay_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HTP_HowToPlay_PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HTP_HowToPlay_Panel;
        private System.Windows.Forms.PictureBox HTP_HowToPlay_PicBox;
        private System.Windows.Forms.Button HTP_Exit_Button;
    }
}