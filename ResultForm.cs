﻿// ResultForm.cs
using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class ResultForm : Form
    {
        private LeaderboardForm leaderboardForm;

        public ResultForm(string message, string difficulty, int elapsedTime)
        {
            InitializeComponent();
            lblDifficulty.Text = $"Сложность: {difficulty}";
            lblTime.Text = $"Время: {elapsedTime} секунд"; // Отображаем время

            // Запрашиваем имя игрока
            string playerName = PromptForPlayerName();
            if (!string.IsNullOrEmpty(playerName))
            {
                leaderboardForm = new LeaderboardForm();
                leaderboardForm.AddScore(playerName, elapsedTime); // Добавляем результат в лидерборд
            }
        }

        private string PromptForPlayerName()
        {
            string playerName = Microsoft.VisualBasic.Interaction.InputBox("Введите ваше имя:", "Имя игрока", "Игрок", -1, -1);
            return playerName; // Возвращаем введенное имя
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}