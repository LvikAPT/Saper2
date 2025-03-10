using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            InitializeDifficultyComboBox();
        }

        private void InitializeDifficultyComboBox()
        {
            // Добавляем уровни сложности в ComboBox
            cmbDifficulty.Items.Add("Легкий");
            cmbDifficulty.Items.Add("Средний");
            cmbDifficulty.Items.Add("Сложный");
            cmbDifficulty.SelectedIndex = 0; // Устанавливаем "Легкий" по умолчанию
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            string selectedDifficulty = cmbDifficulty.SelectedItem.ToString();
            GameForm gameForm = new GameForm(selectedDifficulty);
            gameForm.Show();
            this.Hide();
        }

        private void btnLeaderboard_Click(object sender, EventArgs e)
        {
            LeaderboardForm leaderboardForm = new LeaderboardForm();
            leaderboardForm.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm();
            helpForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}