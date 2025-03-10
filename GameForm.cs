// GameForm.cs
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Saper
{
    public partial class GameForm : Form
    {
        private int rows;
        private int columns;
        private int mines;
        private Button[,] buttons;
        private bool[,] mineField;
        private bool gameOver = false;
        private System.Windows.Forms.Timer timer; // Таймер // Таймер
        private int elapsedTime; // Время в секундах
        private int flagsPlaced; // Количество установленных флажков

        public GameForm(string difficulty)
        {
            InitializeComponent();
            SetDifficulty(difficulty);
            InitializeGame();
            InitializeTimer(); // Инициализация таймера
        }

        private void SetDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "Легкий":
                    rows = 1;
                    columns = 1;
                    mines = 0;
                    break;
                case "Средний":
                    rows = 10;
                    columns = 10;
                    mines = 20;
                    break;
                case "Сложный":
                    rows = 12;
                    columns = 12;
                    mines = 30;
                    break;
            }
            buttons = new Button[rows, columns];
            mineField = new bool[rows, columns];
        }

        private void InitializeGame()
        {
            // Инициализация кнопок
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Size = new Size(30, 30);
                    buttons[i, j].Location = new Point(j * 30, i * 30);
                    buttons[i, j].Click += Button_Click; // Левый клик для открытия клетки
                    buttons[i, j].MouseDown += Button_MouseDown; // Правый клик для установки флажка
                    this.Controls.Add(buttons[i, j]);
                }
            }

            // Установка мин
            Random rand = new Random();
            for (int i = 0; i < mines; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(rows);
                    y = rand.Next(columns);
                } while (mineField[x, y]);
                mineField[x, y] = true;
            }

            // Добавляем кнопку паузы
            Button btnPause = new Button();
            btnPause.Text = "Пауза";
            btnPause.Size = new Size(60, 30);
            btnPause.Location = new Point(columns * 30 + 10, 10); // Позиция кнопки
            btnPause.Click += BtnPause_Click;
            this.Controls.Add(btnPause);
        }

        private void InitializeTimer()
        {
            elapsedTime = 0; // Сброс времени
            flagsPlaced = 0; // Сброс флажков
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000; // 1 секунда
            timer.Tick += Timer_Tick;
            timer.Start(); // Запуск таймера
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++; // Увеличиваем время на 1 секунду
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем игровую форму
            PauseForm pauseForm = new PauseForm(this); // Передаем ссылку на игровую форму
            pauseForm.ShowDialog(); // Открываем форму паузы как модальное окно
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            Button button = sender as Button;
            int row = button.Location.Y / 30;
            int col = button.Location.X / 30;

            if (mineField[row, col])
            {
                button.BackColor = Color.Red; // Показываем, что это мина
                gameOver = true;
                timer.Stop(); // Останавливаем таймер
                ShowResult(false); // Передаем false, чтобы не записывать результат
            }
            else
            {
                button.BackColor = Color.LightGray; // Открываем клетку
                button.Enabled = false; // Делаем кнопку неактивной
                CheckWinCondition(); // Проверяем условия победы
            }
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) // Проверяем, был ли нажат правый клик
            {
                Button button = sender as Button;

                if (button.Text == "★") // Если флажок уже установлен
                {
                    button.Text = ""; // Убираем флажок
                    flagsPlaced--; // Уменьшаем счетчик флажков
                }
                else
                {
                    button.Text = "★"; // Устанавливаем флажок
                    flagsPlaced++; // Увеличиваем счетчик флажков
                }
            }
        }

        private void ShowResult(bool won)
        {
            // Показываем все мины
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (mineField[i, j])
                    {
                        buttons[i, j].BackColor = Color.Red; // Показываем мины
                    }
                }
            }

            if (won)
            {
                int finalTime = elapsedTime - flagsPlaced; // Вычитаем секунды за установленные флажки
                string playerName = PromptForPlayerName(); // Запрашиваем имя игрока
                if (!string.IsNullOrEmpty(playerName))
                {
                    AddScoreToLeaderboard(playerName, finalTime); // Добавляем результат в лидерборд
                }
                ResultForm resultForm = new ResultForm("Поздравляем! Вы выиграли!", "Сложность", finalTime);
                resultForm.ShowDialog();
            }
            else
            {
                ResultForm resultForm = new ResultForm("Игра окончена! Вы попали на мину.", "Сложность", elapsedTime);
                resultForm.ShowDialog();
            }

            this.Close();
        }

        private string PromptForPlayerName()
        {
            // Используем InputBox для запроса имени игрока
            return Microsoft.VisualBasic.Interaction.InputBox("Введите ваше имя:", "Имя игрока", "Игрок", -1, -1);
        }

        private void AddScoreToLeaderboard(string playerName, int time)
        {
            string leaderboardFilePath = "leaderboard.txt";
            var lines = File.Exists(leaderboardFilePath) ? File.ReadAllLines(leaderboardFilePath).ToList() : new List<string>();

            // Проверяем, если лидерборд пуст
            if (lines.Count == 0)
            {
                // Если лидерборд пуст, добавляем запись только если время меньше 999
                if (time < 999)
                {
                    lines.Add($"{playerName};{time}");
                    File.WriteAllLines(leaderboardFilePath, lines);
                }
            }
            else
            {
                // Если лидерборд не пуст, проверяем время последнего игрока
                var lastEntry = lines.Last().Split(';');
                if (lastEntry.Length == 2 && int.TryParse(lastEntry[1], out int lastTime))
                {
                    // Добавляем запись только если время игрока лучше, чем у последнего игрока
                    if (time < lastTime)
                    {
                        lines.Add($"{playerName};{time}");
                        File.WriteAllLines(leaderboardFilePath, lines);
                    }
                }
            }
        }

        private void CheckWinCondition()
        {
            // Проверяем, открыты ли все клетки, кроме мин
            int openedCells = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (buttons[i, j].BackColor == Color.LightGray) // Если клетка открыта
                    {
                        openedCells++;
                    }
                }
            }

            // Если все клетки, кроме мин, открыты, игрок выигрывает
            if (openedCells == (rows * columns - mines))
            {
                gameOver = true;
                timer.Stop(); // Останавливаем таймер
                ShowResult(true); // Передаем true, чтобы записать результат
            }
        }
    }
}
