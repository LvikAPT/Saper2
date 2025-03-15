namespace Saper
{
    partial class ResultForm
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
            lblMessage = new Label();
            lblTime = new Label();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(14, 10);
            lblMessage.Margin = new Padding(4, 0, 4, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(73, 15);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Сообщение";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Location = new Point(14, 59);
            lblTime.Margin = new Padding(4, 0, 4, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(42, 15);
            lblTime.TabIndex = 2;
            lblTime.Text = "Время";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(14, 92);
            btnBack.Margin = new Padding(4, 3, 4, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(88, 27);
            btnBack.TabIndex = 3;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // ResultForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 138);
            Controls.Add(btnBack);
            Controls.Add(lblTime);
            Controls.Add(lblMessage);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ResultForm";
            Text = "Результат";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnBack;
    }
}