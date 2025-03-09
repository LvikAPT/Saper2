namespace Saper
{
    partial class PauseForm
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
            this.btnResume = new System.Windows.Forms.Button();
            this.btnExitToMenu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(12, 12);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(75, 23);
            this.btnResume.TabIndex = 0;
            this.btnResume.Text = "Продолжить";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // btnExitToMenu
            // 
            this.btnExitToMenu.Location = new System.Drawing.Point(12, 41);
            this.btnExitToMenu.Name = "btnExitToMenu";
            this.btnExitToMenu.Size = new System.Drawing.Size(75, 23);
            this.btnExitToMenu.TabIndex = 1;
            this.btnExitToMenu.Text = "В меню";
            this.btnExitToMenu.UseVisualStyleBackColor = true;
            this.btnExitToMenu.Click += new System.EventHandler(this.btnExitToMenu_Click);
            // 
            // PauseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 80);
            this.Controls.Add(this.btnExitToMenu);
            this.Controls.Add(this.btnResume);
            this.Name = "PauseForm";
            this.Text = "Пауза";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnExitToMenu;
    }
}