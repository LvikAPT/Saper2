// PauseForm.cs
using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class PauseForm : Form
    {
        private GameForm gameForm; // Ссылка на игровую форму

        public PauseForm(GameForm gameForm)
        {
            InitializeComponent();
            this.gameForm = gameForm; // Сохраняем ссылку на игровую форму
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрываем форму паузы, чтобы вернуться к игре
            gameForm.Show(); // Показываем игровую форму
        }

        private void btnExitToMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide(); // Скрываем форму паузы
            gameForm.Hide(); // Скрываем игровую форму
        }
    }
}