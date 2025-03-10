// GameForm.cs
using System;
using System.Drawing;
using System.IO;
using System.Linq;
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
        private System.Windows.Forms.Timer timer; // Таймер
        private int elapsedTime; // Время в секундах
        private int flagsPlaced; // Количество установленных флажков

        public GameForm(string difficulty)
        {
            InitializeComponent();
            SetDifficulty(difficulty);
            InitializeGame();
            InitializeTimer(); // Инициализация таймера
            UpdateLabels(); // Обновляем метки
        }

        private void SetDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "Легкий":
                    rows = 8;
                    columns = 8;
                    mines = 10;
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
                    buttons[i, j].Location = new Point(j * 30, i * 30 + 40); // Сдвигаем вниз, чтобы оставить место для меток
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

        private void UpdateLabels()
        {
            flagCountLabel.Text = $"Флажки: {flagsPlaced} / {mines}"; // Обновляем количество флажков
            timerLabel.Text = $"Время: {elapsedTime}"; // Обновляем время
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++; // Увеличиваем время на 1 секунду
            UpdateLabels(); // Обновляем метки
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
            int row = button.Location.Y / 30 - 1; // Учитываем смещение из-за меток
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
                OpenCell(row, col); // Открываем клетку
            }
        }

        private void OpenCell(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= columns || !buttons[row, col].Enabled)
                return;

            buttons[row, col].Enabled = false; // Делаем кнопку неактивной
            int minesAround = CountMinesAround(row, col); // Подсчитываем количество мин вокруг

            if (minesAround > 0)
            {
                buttons[row, col].Text = minesAround.ToString(); // Отображаем количество мин
                buttons[row, col].BackColor = Color.LightGray; // Открываем клетку
            }
            else
            {
                buttons[row, col].BackColor = Color.LightGray; // Открываем клетку
                // Если вокруг нет мин, открываем соседние клетки
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i == 0 && j == 0) continue; // Пропускаем саму клетку
                        OpenCell(row + i, col + j); // Рекурсивно открываем соседние клетки
                    }
                }
            }

            CheckWinCondition(); // Проверяем условия победы после открытия клетки
        }

        private int CountMinesAround(int row, int col)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue; // Пропускаем саму клетку
                    int newRow = row + i;
                    int newCol = col + j;
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < columns && mineField[newRow, newCol])
                    {
                        count++; // Увеличиваем счетчик, если найдена мина
                    }
                }
            }
            return count; // Возвращаем количество мин вокруг
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
                UpdateLabels(); // Обновляем метки
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
            using (Form nameForm = new Form())
            {
                Label nameLabel = new Label() { Text = "Введите ваше имя:", Dock = DockStyle.Top };
                TextBox nameTextBox = new TextBox() { Dock = DockStyle.Top };
                Button submitButton = new Button() { Text = "OK", Dock = DockStyle.Bottom };

                submitButton.Click += (sender, e) => { nameForm.Close(); };
                nameForm.Controls.Add(nameTextBox);
                nameForm.Controls.Add(submitButton);
                nameForm.Controls.Add(nameLabel);
                nameForm.ShowDialog();

                return nameTextBox.Text;
            }
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
            // Проверяем, все ли клетки без мин открыты
            int openedCells = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (!buttons[i, j].Enabled)
                    {
                        openedCells++;
                    }
                }
            }

            if (openedCells == (rows * columns - mines))
            {
                gameOver = true;
                timer.Stop(); // Останавливаем таймер
                ShowResult(true); // Передаем true, чтобы записать результат
            }
        }
    }
}