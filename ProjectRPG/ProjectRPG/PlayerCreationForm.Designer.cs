namespace ProjectRPG
{
    partial class PlayerCreationForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerCreationForm));
            this.CharacterName_Label = new System.Windows.Forms.Label();
            this.CharName_TextBox = new System.Windows.Forms.TextBox();
            this.Str_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Atrributes_Label = new System.Windows.Forms.Label();
            this.Strength_Label = new System.Windows.Forms.Label();
            this.Intelligence_Label = new System.Windows.Forms.Label();
            this.Intel_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Dex_Label = new System.Windows.Forms.Label();
            this.Dex_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Vit_Label = new System.Windows.Forms.Label();
            this.Vit_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ReRoll_Button = new System.Windows.Forms.Button();
            this.CC_ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.CC_Create_Button = new System.Windows.Forms.Button();
            this.CC_PlayerModel_PicBox = new System.Windows.Forms.PictureBox();
            this.CC_Cancel_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Str_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intel_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dex_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vit_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CC_PlayerModel_PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CharacterName_Label
            // 
            this.CharacterName_Label.AutoSize = true;
            this.CharacterName_Label.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.CharacterName_Label.Location = new System.Drawing.Point(12, 25);
            this.CharacterName_Label.Name = "CharacterName_Label";
            this.CharacterName_Label.Size = new System.Drawing.Size(175, 21);
            this.CharacterName_Label.TabIndex = 0;
            this.CharacterName_Label.Text = "CHARACTER NAME:";
            // 
            // CharName_TextBox
            // 
            this.CharName_TextBox.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.CharName_TextBox.Location = new System.Drawing.Point(195, 25);
            this.CharName_TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CharName_TextBox.MaxLength = 16;
            this.CharName_TextBox.Name = "CharName_TextBox";
            this.CharName_TextBox.Size = new System.Drawing.Size(187, 24);
            this.CharName_TextBox.TabIndex = 1;
            this.CharName_TextBox.Text = "PlayerName";
            this.CharName_TextBox.Click += new System.EventHandler(this.CharName_TextBox_Click);
            this.CharName_TextBox.Leave += new System.EventHandler(this.CharName_TextBox_Leave);
            // 
            // Str_NumUpDown
            // 
            this.Str_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Str_NumUpDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Str_NumUpDown.Location = new System.Drawing.Point(133, 94);
            this.Str_NumUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Str_NumUpDown.Name = "Str_NumUpDown";
            this.Str_NumUpDown.Size = new System.Drawing.Size(53, 23);
            this.Str_NumUpDown.TabIndex = 2;
            this.Str_NumUpDown.ValueChanged += new System.EventHandler(this.Str_NumUpDown_ValueChanged);
            // 
            // Atrributes_Label
            // 
            this.Atrributes_Label.AutoSize = true;
            this.Atrributes_Label.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Atrributes_Label.Location = new System.Drawing.Point(12, 62);
            this.Atrributes_Label.Name = "Atrributes_Label";
            this.Atrributes_Label.Size = new System.Drawing.Size(101, 21);
            this.Atrributes_Label.TabIndex = 3;
            this.Atrributes_Label.Text = "ATTRIBUTES";
            // 
            // Strength_Label
            // 
            this.Strength_Label.AutoSize = true;
            this.Strength_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Strength_Label.Location = new System.Drawing.Point(37, 95);
            this.Strength_Label.Name = "Strength_Label";
            this.Strength_Label.Size = new System.Drawing.Size(66, 19);
            this.Strength_Label.TabIndex = 4;
            this.Strength_Label.Text = "Strength";
            // 
            // Intelligence_Label
            // 
            this.Intelligence_Label.AutoSize = true;
            this.Intelligence_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Intelligence_Label.Location = new System.Drawing.Point(25, 122);
            this.Intelligence_Label.Name = "Intelligence_Label";
            this.Intelligence_Label.Size = new System.Drawing.Size(89, 19);
            this.Intelligence_Label.TabIndex = 5;
            this.Intelligence_Label.Text = "Intelligence";
            // 
            // Intel_NumUpDown
            // 
            this.Intel_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Intel_NumUpDown.Location = new System.Drawing.Point(133, 121);
            this.Intel_NumUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Intel_NumUpDown.Name = "Intel_NumUpDown";
            this.Intel_NumUpDown.Size = new System.Drawing.Size(53, 23);
            this.Intel_NumUpDown.TabIndex = 6;
            this.Intel_NumUpDown.ValueChanged += new System.EventHandler(this.Intel_NumUpDown_ValueChanged);
            // 
            // Dex_Label
            // 
            this.Dex_Label.AutoSize = true;
            this.Dex_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Dex_Label.Location = new System.Drawing.Point(37, 151);
            this.Dex_Label.Name = "Dex_Label";
            this.Dex_Label.Size = new System.Drawing.Size(69, 19);
            this.Dex_Label.TabIndex = 7;
            this.Dex_Label.Text = "Dexterity";
            // 
            // Dex_NumUpDown
            // 
            this.Dex_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Dex_NumUpDown.Location = new System.Drawing.Point(133, 149);
            this.Dex_NumUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dex_NumUpDown.Name = "Dex_NumUpDown";
            this.Dex_NumUpDown.Size = new System.Drawing.Size(53, 23);
            this.Dex_NumUpDown.TabIndex = 8;
            this.Dex_NumUpDown.ValueChanged += new System.EventHandler(this.Dex_NumUpDown_ValueChanged);
            // 
            // Vit_Label
            // 
            this.Vit_Label.AutoSize = true;
            this.Vit_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Vit_Label.Location = new System.Drawing.Point(43, 177);
            this.Vit_Label.Name = "Vit_Label";
            this.Vit_Label.Size = new System.Drawing.Size(55, 19);
            this.Vit_Label.TabIndex = 9;
            this.Vit_Label.Text = "Vitality";
            // 
            // Vit_NumUpDown
            // 
            this.Vit_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Vit_NumUpDown.Location = new System.Drawing.Point(133, 177);
            this.Vit_NumUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Vit_NumUpDown.Name = "Vit_NumUpDown";
            this.Vit_NumUpDown.Size = new System.Drawing.Size(53, 23);
            this.Vit_NumUpDown.TabIndex = 10;
            this.Vit_NumUpDown.ValueChanged += new System.EventHandler(this.Vit_NumUpDown_ValueChanged);
            // 
            // ReRoll_Button
            // 
            this.ReRoll_Button.Location = new System.Drawing.Point(120, 62);
            this.ReRoll_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReRoll_Button.Name = "ReRoll_Button";
            this.ReRoll_Button.Size = new System.Drawing.Size(75, 23);
            this.ReRoll_Button.TabIndex = 11;
            this.ReRoll_Button.Text = "Roll";
            this.ReRoll_Button.UseVisualStyleBackColor = true;
            this.ReRoll_Button.Click += new System.EventHandler(this.ReRoll_Button_Click);
            // 
            // CC_Create_Button
            // 
            this.CC_Create_Button.Location = new System.Drawing.Point(59, 208);
            this.CC_Create_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CC_Create_Button.Name = "CC_Create_Button";
            this.CC_Create_Button.Size = new System.Drawing.Size(100, 28);
            this.CC_Create_Button.TabIndex = 12;
            this.CC_Create_Button.Text = "Create";
            this.CC_Create_Button.UseVisualStyleBackColor = true;
            this.CC_Create_Button.Click += new System.EventHandler(this.Create_Button_Click);
            // 
            // CC_PlayerModel_PicBox
            // 
            this.CC_PlayerModel_PicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CC_PlayerModel_PicBox.Image = ((System.Drawing.Image)(resources.GetObject("CC_PlayerModel_PicBox.Image")));
            this.CC_PlayerModel_PicBox.Location = new System.Drawing.Point(201, 62);
            this.CC_PlayerModel_PicBox.Name = "CC_PlayerModel_PicBox";
            this.CC_PlayerModel_PicBox.Size = new System.Drawing.Size(181, 222);
            this.CC_PlayerModel_PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CC_PlayerModel_PicBox.TabIndex = 13;
            this.CC_PlayerModel_PicBox.TabStop = false;
            // 
            // CC_Cancel_Button
            // 
            this.CC_Cancel_Button.Location = new System.Drawing.Point(59, 244);
            this.CC_Cancel_Button.Margin = new System.Windows.Forms.Padding(4);
            this.CC_Cancel_Button.Name = "CC_Cancel_Button";
            this.CC_Cancel_Button.Size = new System.Drawing.Size(100, 28);
            this.CC_Cancel_Button.TabIndex = 14;
            this.CC_Cancel_Button.Text = "Cancel";
            this.CC_Cancel_Button.UseVisualStyleBackColor = true;
            this.CC_Cancel_Button.Click += new System.EventHandler(this.CC_Cancel_Button_Click);
            // 
            // PlayerCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 296);
            this.Controls.Add(this.CC_Cancel_Button);
            this.Controls.Add(this.CC_PlayerModel_PicBox);
            this.Controls.Add(this.CC_Create_Button);
            this.Controls.Add(this.ReRoll_Button);
            this.Controls.Add(this.Vit_NumUpDown);
            this.Controls.Add(this.Vit_Label);
            this.Controls.Add(this.Dex_NumUpDown);
            this.Controls.Add(this.Dex_Label);
            this.Controls.Add(this.Intel_NumUpDown);
            this.Controls.Add(this.Intelligence_Label);
            this.Controls.Add(this.Strength_Label);
            this.Controls.Add(this.Atrributes_Label);
            this.Controls.Add(this.Str_NumUpDown);
            this.Controls.Add(this.CharName_TextBox);
            this.Controls.Add(this.CharacterName_Label);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(425, 343);
            this.MinimumSize = new System.Drawing.Size(425, 343);
            this.Name = "PlayerCreationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Character Creation";
            this.Load += new System.EventHandler(this.PlayerCreationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Str_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intel_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dex_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vit_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CC_PlayerModel_PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CharacterName_Label;
        private System.Windows.Forms.TextBox CharName_TextBox;
        private System.Windows.Forms.NumericUpDown Str_NumUpDown;
        private System.Windows.Forms.Label Atrributes_Label;
        private System.Windows.Forms.Label Strength_Label;
        private System.Windows.Forms.Label Intelligence_Label;
        private System.Windows.Forms.NumericUpDown Intel_NumUpDown;
        private System.Windows.Forms.Label Dex_Label;
        private System.Windows.Forms.NumericUpDown Dex_NumUpDown;
        private System.Windows.Forms.Label Vit_Label;
        private System.Windows.Forms.NumericUpDown Vit_NumUpDown;
        private System.Windows.Forms.Button ReRoll_Button;
        private System.Windows.Forms.ToolTip CC_ToolTips;
        private System.Windows.Forms.Button CC_Create_Button;
        private System.Windows.Forms.PictureBox CC_PlayerModel_PicBox;
        private System.Windows.Forms.Button CC_Cancel_Button;
    }
}