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
            txtLeaderboard = new TextBox();
            SuspendLayout();
            // 
            // txtLeaderboard
            // 
            txtLeaderboard.Location = new Point(14, 14);
            txtLeaderboard.Margin = new Padding(4, 3, 4, 3);
            txtLeaderboard.Multiline = true;
            txtLeaderboard.Name = "txtLeaderboard";
            txtLeaderboard.ReadOnly = true;
            txtLeaderboard.ScrollBars = ScrollBars.Vertical;
            txtLeaderboard.Size = new Size(303, 230);
            txtLeaderboard.TabIndex = 0;
            // 
            // LeaderboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 301);
            Controls.Add(txtLeaderboard);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LeaderboardForm";
            Text = "Лидерборд";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLeaderboard;
    }
}