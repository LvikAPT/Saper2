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
            this.txtLeaderboard = new System.Windows.Forms.TextBox();
            this.btnClearLeaderboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLeaderboard
            // 
            this.txtLeaderboard.Location = new System.Drawing.Point(12, 12);
            this.txtLeaderboard.Multiline = true;
            this.txtLeaderboard.ReadOnly = true;
            this.txtLeaderboard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLeaderboard.Size = new System.Drawing.Size(303, 230);
            this.txtLeaderboard.TabIndex = 0;
            // 
            // btnClearLeaderboard
            // 
            this.btnClearLeaderboard.Location = new System.Drawing.Point(12, 248);
            this.btnClearLeaderboard.Name = "btnClearLeaderboard";
            this.btnClearLeaderboard.Size = new System.Drawing.Size(303, 23);
            this.btnClearLeaderboard.TabIndex = 1;
            this.btnClearLeaderboard.Text = "Очистить лидерборд";
            this.btnClearLeaderboard.UseVisualStyleBackColor = true;
            this.btnClearLeaderboard.Click += new System.EventHandler(this.btnClearLeaderboard_Click);
            // 
            // LeaderboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 301);
            this.Controls.Add(this.btnClearLeaderboard);
            this.Controls.Add(this.txtLeaderboard);
            this.Name = "LeaderboardForm";
            this.Text = "Лидерборд";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLeaderboard;
        private System.Windows.Forms.Button btnClearLeaderboard;
    }
}