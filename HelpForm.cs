using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            LoadHelp();
        }

        private void LoadHelp()
        {
            // Здесь можно добавить инструкции по игре
            Text = "Инструкция по игре:\n" +
                           "1. Нажмите на клетку, чтобы открыть её.\n" +
                           "2. Если вы нажмете на мину, игра окончена.\n" +
                           "3. Цель игры - открыть все клетки, не попав на мины.";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}