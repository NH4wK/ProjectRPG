namespace ProjectRPG
{
    partial class ProjectRPG_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectRPG_MainForm));
            this.MainMenu_StartButton = new System.Windows.Forms.Button();
            this.MainMenu_SettingsButton = new System.Windows.Forms.Button();
            this.MainMenu_ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainMenu_StartButton
            // 
            this.MainMenu_StartButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainMenu_StartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenu_StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenu_StartButton.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu_StartButton.ForeColor = System.Drawing.Color.Transparent;
            this.MainMenu_StartButton.Location = new System.Drawing.Point(430, 456);
            this.MainMenu_StartButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainMenu_StartButton.Name = "MainMenu_StartButton";
            this.MainMenu_StartButton.Size = new System.Drawing.Size(146, 54);
            this.MainMenu_StartButton.TabIndex = 0;
            this.MainMenu_StartButton.Text = "START";
            this.MainMenu_StartButton.UseVisualStyleBackColor = false;
            this.MainMenu_StartButton.Click += new System.EventHandler(this.MainMenu_StartButton_Click);
            // 
            // MainMenu_SettingsButton
            // 
            this.MainMenu_SettingsButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainMenu_SettingsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenu_SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenu_SettingsButton.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu_SettingsButton.ForeColor = System.Drawing.Color.Transparent;
            this.MainMenu_SettingsButton.Location = new System.Drawing.Point(600, 456);
            this.MainMenu_SettingsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainMenu_SettingsButton.Name = "MainMenu_SettingsButton";
            this.MainMenu_SettingsButton.Size = new System.Drawing.Size(146, 54);
            this.MainMenu_SettingsButton.TabIndex = 1;
            this.MainMenu_SettingsButton.Text = "SETTINGS";
            this.MainMenu_SettingsButton.UseVisualStyleBackColor = false;
            // 
            // MainMenu_ExitButton
            // 
            this.MainMenu_ExitButton.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MainMenu_ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MainMenu_ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainMenu_ExitButton.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenu_ExitButton.ForeColor = System.Drawing.Color.Transparent;
            this.MainMenu_ExitButton.Location = new System.Drawing.Point(765, 456);
            this.MainMenu_ExitButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainMenu_ExitButton.Name = "MainMenu_ExitButton";
            this.MainMenu_ExitButton.Size = new System.Drawing.Size(146, 54);
            this.MainMenu_ExitButton.TabIndex = 2;
            this.MainMenu_ExitButton.Text = "QUIT";
            this.MainMenu_ExitButton.UseVisualStyleBackColor = false;
            // 
            // ProjectRPG_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(962, 591);
            this.Controls.Add(this.MainMenu_ExitButton);
            this.Controls.Add(this.MainMenu_SettingsButton);
            this.Controls.Add(this.MainMenu_StartButton);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximumSize = new System.Drawing.Size(978, 630);
            this.MinimumSize = new System.Drawing.Size(978, 630);
            this.Name = "ProjectRPG_MainForm";
            this.Text = "ProjectRPG - Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MainMenu_StartButton;
        private System.Windows.Forms.Button MainMenu_SettingsButton;
        private System.Windows.Forms.Button MainMenu_ExitButton;
    }
}

