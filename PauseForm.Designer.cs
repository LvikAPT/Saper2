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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PauseForm));
            btnResume = new Button();
            btnExitToMenu = new Button();
            SuspendLayout();
            // 
            // btnResume
            // 
            btnResume.Location = new Point(13, 239);
            btnResume.Margin = new Padding(4, 3, 4, 3);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(88, 27);
            btnResume.TabIndex = 0;
            btnResume.Text = "Продолжить";
            btnResume.UseVisualStyleBackColor = true;
            btnResume.Click += btnResume_Click;
            // 
            // btnExitToMenu
            // 
            btnExitToMenu.Location = new Point(197, 239);
            btnExitToMenu.Margin = new Padding(4, 3, 4, 3);
            btnExitToMenu.Name = "btnExitToMenu";
            btnExitToMenu.Size = new Size(88, 27);
            btnExitToMenu.TabIndex = 1;
            btnExitToMenu.Text = "В меню";
            btnExitToMenu.UseVisualStyleBackColor = true;
            btnExitToMenu.Click += btnExitToMenu_Click;
            // 
            // PauseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(298, 289);
            Controls.Add(btnExitToMenu);
            Controls.Add(btnResume);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PauseForm";
            Text = "Пауза";
            Load += PauseForm_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Button btnExitToMenu;
    }
}