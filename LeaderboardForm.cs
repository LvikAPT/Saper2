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
                    string[] lines = reader.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    // Сортируем записи по времени (второй элемент после ";") и добавляем их в текстовое поле
                    var sortedLines = lines
                        .Select(line => line.Split(';'))
                        .Where(parts => parts.Length == 2)
                        .OrderBy(parts => int.Parse(parts[1])) // Сортируем по времени
                        .Select(parts => $"{parts[0]}: {parts[1]} секунд");

                    foreach (var line in sortedLines)
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

        private void btnClearLeaderboard_Click(object sender, EventArgs e)
        {
            // Очищаем файл лидерборда
            if (File.Exists(leaderboardFilePath))
            {
                File.WriteAllText(leaderboardFilePath, string.Empty); // Очищаем содержимое файла
                LoadLeaderboard(); // Перезагружаем лидерборд
            }
        }
    }
}