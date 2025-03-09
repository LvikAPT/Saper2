﻿namespace Saper
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
            this.lblResult = new System.Windows.Forms.Label();
            this.lblDifficulty = new System.Windows.Forms.Label(); // Define lblDifficulty
            this.lblTime = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 9);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(35, 13);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Результат:";
            // 
            // lblDifficulty
            // 
            this.lblDifficulty.AutoSize = true; // Initialize lblDifficulty
            this.lblDifficulty.Location = new System.Drawing.Point(12, 30);
            this.lblDifficulty.Name = "lblDifficulty";
            this.lblDifficulty.Size = new System.Drawing.Size(35, 13);
            this.lblDifficulty.TabIndex = 1;
            this.lblDifficulty.Text = "Сложность:"; // Set default text
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(12, 50);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Время:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(12, 70);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDifficulty); // Add lblDifficulty to controls
            this.Controls.Add(this.lblResult);
            this.Name = "ResultForm";
            this.Text = "Результат";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblDifficulty; // Declare lblDifficulty
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnClose;

        private void btnClose_Click(object sender, EventArgs e) // Implement btnClose_Click
        {
            this.Close();
        }
    }
}
