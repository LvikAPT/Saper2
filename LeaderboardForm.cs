// LeaderboardForm.cs
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Saper
{
    public partial class LeaderboardForm : Form
    {
        private const string leaderboardFilePath = "leaderboard.txt"; // Путь к файлу

        public LeaderboardForm()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            if (File.Exists(leaderboardFilePath))
            {
                using (StreamReader reader = new StreamReader(leaderboardFilePath))
                {
                    txtLeaderboard.Clear(); // Очищаем текстовое поле перед загрузкой
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        txtLeaderboard.AppendText(line + Environment.NewLine); // Добавляем каждую строку в текстовое поле
                    }
                }
            }
            else
            {
                txtLeaderboard.Text = "Лидерборд пуст."; // Если файл не существует
            }
        }

        // Метод для добавления нового результата в лидерборд
        public void AddScore(string playerName, int time)
        {
            // Проверяем, есть ли в лидерборде хотя бы один игрок
            if (File.Exists(leaderboardFilePath))
            {
                string[] lines = File.ReadAllLines(leaderboardFilePath);
                if (lines.Length > 0)
                {
                    // Получаем время первого игрока
                    string[] firstPlayerData = lines[0].Split(';');
                    if (firstPlayerData.Length > 1 && int.TryParse(firstPlayerData[1], out int firstPlayerTime))
                    {
                        // Если время игрока больше времени первого игрока, добавляем его в лидерборд
                        if (time > firstPlayerTime)
                        {
                            using (StreamWriter writer = new StreamWriter(leaderboardFilePath, true))
                            {
                                writer.WriteLine($"{playerName};{time}"); // Записываем имя игрока и время
                            }
                        }
                    }
                }
            }
            else
            {
                // Если файл не существует, создаем его и добавляем результат
                using (StreamWriter writer = new StreamWriter(leaderboardFilePath, true))
                {
                    writer.WriteLine($"{playerName};{time}"); // Записываем имя игрока и время
                }
            }
        }
    }
}