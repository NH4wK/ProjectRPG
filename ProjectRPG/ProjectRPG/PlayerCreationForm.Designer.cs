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
            this.CharacterName_Label = new System.Windows.Forms.Label();
            this.CharName_TextBox = new System.Windows.Forms.TextBox();
            this.Str_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Atrributes_Label = new System.Windows.Forms.Label();
            this.Strength_Label = new System.Windows.Forms.Label();
            this.Intelligence_Label = new System.Windows.Forms.Label();
            this.Intel_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.Dex_Label = new System.Windows.Forms.Label();
            this.Dex_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.Vit_NumUpDown = new System.Windows.Forms.NumericUpDown();
            this.ReRoll_Button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Create_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Str_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intel_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dex_NumUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vit_NumUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // CharacterName_Label
            // 
            this.CharacterName_Label.AutoSize = true;
            this.CharacterName_Label.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.CharacterName_Label.Location = new System.Drawing.Point(9, 20);
            this.CharacterName_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CharacterName_Label.Name = "CharacterName_Label";
            this.CharacterName_Label.Size = new System.Drawing.Size(138, 19);
            this.CharacterName_Label.TabIndex = 0;
            this.CharacterName_Label.Text = "CHARACTER NAME:";
            // 
            // CharName_TextBox
            // 
            this.CharName_TextBox.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.CharName_TextBox.Location = new System.Drawing.Point(146, 20);
            this.CharName_TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CharName_TextBox.MaxLength = 16;
            this.CharName_TextBox.Name = "CharName_TextBox";
            this.CharName_TextBox.Size = new System.Drawing.Size(129, 21);
            this.CharName_TextBox.TabIndex = 1;
            this.CharName_TextBox.Text = "PlayerName";
            this.CharName_TextBox.Click += new System.EventHandler(this.CharName_TextBox_Click);
            this.CharName_TextBox.Leave += new System.EventHandler(this.CharName_TextBox_Leave);
            // 
            // Str_NumUpDown
            // 
            this.Str_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Str_NumUpDown.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Str_NumUpDown.Location = new System.Drawing.Point(100, 76);
            this.Str_NumUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Str_NumUpDown.Name = "Str_NumUpDown";
            this.Str_NumUpDown.Size = new System.Drawing.Size(40, 20);
            this.Str_NumUpDown.TabIndex = 2;
            // 
            // Atrributes_Label
            // 
            this.Atrributes_Label.AutoSize = true;
            this.Atrributes_Label.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Atrributes_Label.Location = new System.Drawing.Point(9, 50);
            this.Atrributes_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Atrributes_Label.Name = "Atrributes_Label";
            this.Atrributes_Label.Size = new System.Drawing.Size(77, 19);
            this.Atrributes_Label.TabIndex = 3;
            this.Atrributes_Label.Text = "ATTRIBUTES";
            // 
            // Strength_Label
            // 
            this.Strength_Label.AutoSize = true;
            this.Strength_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Strength_Label.Location = new System.Drawing.Point(28, 77);
            this.Strength_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Strength_Label.Name = "Strength_Label";
            this.Strength_Label.Size = new System.Drawing.Size(53, 16);
            this.Strength_Label.TabIndex = 4;
            this.Strength_Label.Text = "Strength";
            // 
            // Intelligence_Label
            // 
            this.Intelligence_Label.AutoSize = true;
            this.Intelligence_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Intelligence_Label.Location = new System.Drawing.Point(19, 99);
            this.Intelligence_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Intelligence_Label.Name = "Intelligence_Label";
            this.Intelligence_Label.Size = new System.Drawing.Size(70, 16);
            this.Intelligence_Label.TabIndex = 5;
            this.Intelligence_Label.Text = "Intelligence";
            // 
            // Intel_NumUpDown
            // 
            this.Intel_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Intel_NumUpDown.Location = new System.Drawing.Point(100, 98);
            this.Intel_NumUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Intel_NumUpDown.Name = "Intel_NumUpDown";
            this.Intel_NumUpDown.Size = new System.Drawing.Size(40, 20);
            this.Intel_NumUpDown.TabIndex = 6;
            // 
            // Dex_Label
            // 
            this.Dex_Label.AutoSize = true;
            this.Dex_Label.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.Dex_Label.Location = new System.Drawing.Point(28, 123);
            this.Dex_Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Dex_Label.Name = "Dex_Label";
            this.Dex_Label.Size = new System.Drawing.Size(55, 16);
            this.Dex_Label.TabIndex = 7;
            this.Dex_Label.Text = "Dexterity";
            // 
            // Dex_NumUpDown
            // 
            this.Dex_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Dex_NumUpDown.Location = new System.Drawing.Point(100, 121);
            this.Dex_NumUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Dex_NumUpDown.Name = "Dex_NumUpDown";
            this.Dex_NumUpDown.Size = new System.Drawing.Size(40, 20);
            this.Dex_NumUpDown.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.label1.Location = new System.Drawing.Point(32, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Vitality";
            // 
            // Vit_NumUpDown
            // 
            this.Vit_NumUpDown.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.Vit_NumUpDown.Location = new System.Drawing.Point(100, 144);
            this.Vit_NumUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Vit_NumUpDown.Name = "Vit_NumUpDown";
            this.Vit_NumUpDown.Size = new System.Drawing.Size(40, 20);
            this.Vit_NumUpDown.TabIndex = 10;
            // 
            // ReRoll_Button
            // 
            this.ReRoll_Button.Location = new System.Drawing.Point(90, 50);
            this.ReRoll_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReRoll_Button.Name = "ReRoll_Button";
            this.ReRoll_Button.Size = new System.Drawing.Size(56, 19);
            this.ReRoll_Button.TabIndex = 11;
            this.ReRoll_Button.Text = "Roll";
            this.ReRoll_Button.UseVisualStyleBackColor = true;
            this.ReRoll_Button.Click += new System.EventHandler(this.ReRoll_Button_Click);
            // 
            // Create_Button
            // 
            this.Create_Button.Location = new System.Drawing.Point(44, 169);
            this.Create_Button.Name = "Create_Button";
            this.Create_Button.Size = new System.Drawing.Size(75, 23);
            this.Create_Button.TabIndex = 12;
            this.Create_Button.Text = "Create";
            this.Create_Button.UseVisualStyleBackColor = true;
            this.Create_Button.Click += new System.EventHandler(this.Create_Button_Click);
            // 
            // PlayerCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 200);
            this.Controls.Add(this.Create_Button);
            this.Controls.Add(this.ReRoll_Button);
            this.Controls.Add(this.Vit_NumUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dex_NumUpDown);
            this.Controls.Add(this.Dex_Label);
            this.Controls.Add(this.Intel_NumUpDown);
            this.Controls.Add(this.Intelligence_Label);
            this.Controls.Add(this.Strength_Label);
            this.Controls.Add(this.Atrributes_Label);
            this.Controls.Add(this.Str_NumUpDown);
            this.Controls.Add(this.CharName_TextBox);
            this.Controls.Add(this.CharacterName_Label);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PlayerCreationForm";
            this.Text = "Character Creation";
            ((System.ComponentModel.ISupportInitialize)(this.Str_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Intel_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dex_NumUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Vit_NumUpDown)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Vit_NumUpDown;
        private System.Windows.Forms.Button ReRoll_Button;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button Create_Button;
    }
}