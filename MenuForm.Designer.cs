﻿namespace Saper
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            cmbDifficulty = new ComboBox();
            btnStartGame = new Button();
            btnLeaderboard = new Button();
            btnHelp = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // cmbDifficulty
            // 
            cmbDifficulty.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDifficulty.FormattingEnabled = true;
            cmbDifficulty.Location = new Point(34, 51);
            cmbDifficulty.Margin = new Padding(4, 3, 4, 3);
            cmbDifficulty.Name = "cmbDifficulty";
            cmbDifficulty.Size = new Size(102, 23);
            cmbDifficulty.TabIndex = 0;
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(34, 80);
            btnStartGame.Margin = new Padding(4, 3, 4, 3);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(102, 27);
            btnStartGame.TabIndex = 1;
            btnStartGame.Text = "Начать игру";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // btnLeaderboard
            // 
            btnLeaderboard.Location = new Point(34, 113);
            btnLeaderboard.Margin = new Padding(4, 3, 4, 3);
            btnLeaderboard.Name = "btnLeaderboard";
            btnLeaderboard.Size = new Size(102, 27);
            btnLeaderboard.TabIndex = 2;
            btnLeaderboard.Text = "Лидерборд";
            btnLeaderboard.UseVisualStyleBackColor = true;
            btnLeaderboard.Click += btnLeaderboard_Click;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(4, 146);
            btnHelp.Margin = new Padding(4, 3, 4, 3);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(71, 27);
            btnHelp.TabIndex = 3;
            btnHelp.Text = "Помощь";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(101, 146);
            btnExit.Margin = new Padding(4, 3, 4, 3);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(71, 27);
            btnExit.TabIndex = 4;
            btnExit.Text = "Выход";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(175, 185);
            Controls.Add(btnExit);
            Controls.Add(btnHelp);
            Controls.Add(btnLeaderboard);
            Controls.Add(btnStartGame);
            Controls.Add(cmbDifficulty);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MenuForm";
            Text = "Меню";
            Load += MenuForm_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.ComboBox cmbDifficulty;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Button btnLeaderboard;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExit;
    }
}
