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
            SuspendLayout();
            // 
            // flagCountLabel
            // 
            flagCountLabel.Location = new Point(350, 426);
            flagCountLabel.Margin = new Padding(4, 0, 4, 0);
            flagCountLabel.Name = "flagCountLabel";
            flagCountLabel.Size = new Size(117, 27);
            flagCountLabel.TabIndex = 0;
            flagCountLabel.Text = "Флажки: 0";
            // 
            // timerLabel
            // 
            timerLabel.Location = new Point(350, 399);
            timerLabel.Margin = new Padding(4, 0, 4, 0);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new Size(117, 27);
            timerLabel.TabIndex = 1;
            timerLabel.Text = "Время: 0";
            // 
            // GameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 462);
            Controls.Add(flagCountLabel);
            Controls.Add(timerLabel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "GameForm";
            Text = "Игровое поле";
            ResumeLayout(false);
        }
    }
}