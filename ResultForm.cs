// ResultForm.cs
using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class ResultForm : Form
    {
        public ResultForm(string message, string difficulty, int elapsedTime)
        {
            InitializeComponent();
            lblMessage.Text = message;
            lblTime.Text = $"Время: {elapsedTime} секунд"; // Отображаем время
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }
    }
}