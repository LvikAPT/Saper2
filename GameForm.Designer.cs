namespace Saper
{
    partial class GameForm
    {
        private System.ComponentModel.IContainer components = null;

        // Метки для отображения флажков и времени
        private System.Windows.Forms.Label flagCountLabel;
        private System.Windows.Forms.Label timerLabel;

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
            flagCountLabel = new Label();
            timerLabel = new Label();
            btnFlagRandomMine = new Button();
            SuspendLayout();
            // 
            // flagCountLabel
            // 
            flagCountLabel.ImageKey = "(нет)";
            flagCountLabel.Location = new Point(350, 426);
            flagCountLabel.Margin = new Padding(4, 0, 4, 0);
            flagCountLabel.Name = "flagCountLabel";
            flagCountLabel.Size = new Size(117, 27);
            flagCountLabel.TabIndex = 0;
            flagCountLabel.Text = "Флажки: 0";
            flagCountLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // timerLabel
            // 
            timerLabel.Location = new Point(350, 399);
            timerLabel.Margin = new Padding(4, 0, 4, 0);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(117, 27);
            timerLabel.TabIndex = 1;
            timerLabel.Text = "Время: 0";
            timerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnFlagRandomMine
            // 
            btnFlagRandomMine.Location = new Point(364, 354);
            btnFlagRandomMine.Name = "btnFlagRandomMine";
            btnFlagRandomMine.Size = new Size(81, 42);
            btnFlagRandomMine.TabIndex = 0;
            btnFlagRandomMine.Text = "Случайный\r\n Флажок\r\n";
            btnFlagRandomMine.Click += BtnFlagRandomMine_Click;
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 452);
            Controls.Add(btnFlagRandomMine);
            Controls.Add(flagCountLabel);
            Controls.Add(timerLabel);
            Cursor = Cursors.Cross;
            Margin = new Padding(4, 3, 4, 3);
            Name = "GameForm";
            ResumeLayout(false);
        }

        private Button btnFlagRandomMine;
    }
}