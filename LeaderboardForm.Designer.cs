namespace Saper
{
    partial class LeaderboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LeaderboardForm));
            txtLeaderboard = new TextBox();
            btnClearLeaderboard = new Button();
            SuspendLayout();
            // 
            // txtLeaderboard
            // 
            txtLeaderboard.ImeMode = ImeMode.Off;
            txtLeaderboard.Location = new Point(65, 176);
            txtLeaderboard.Multiline = true;
            txtLeaderboard.Name = "txtLeaderboard";
            txtLeaderboard.ReadOnly = true;
            txtLeaderboard.ScrollBars = ScrollBars.Vertical;
            txtLeaderboard.Size = new Size(325, 80);
            txtLeaderboard.TabIndex = 0;
            // 
            // btnClearLeaderboard
            // 
            btnClearLeaderboard.Location = new Point(65, 313);
            btnClearLeaderboard.Name = "btnClearLeaderboard";
            btnClearLeaderboard.Size = new Size(303, 23);
            btnClearLeaderboard.TabIndex = 1;
            btnClearLeaderboard.Text = "Очистить лидерборд";
            btnClearLeaderboard.UseVisualStyleBackColor = true;
            btnClearLeaderboard.Click += btnClearLeaderboard_Click;
            // 
            // LeaderboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(446, 348);
            Controls.Add(btnClearLeaderboard);
            Controls.Add(txtLeaderboard);
            Name = "LeaderboardForm";
            Text = "Лидерборд";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLeaderboard;
        private System.Windows.Forms.Button btnClearLeaderboard;
    }
}