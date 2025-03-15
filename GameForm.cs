// GameForm.cs
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.ComponentModel;

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
        private Image closedCellImage;
        private Image openCellImage;
        private Image mineImage;

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
                    rows = 4;
                    columns = 4;
                    mines = 2;
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

        private void LoadImages()
        {
            try
            {

                var closedCellImage = Image.FromFile("C:\\IS - 22\\С#\\Saper\\Images\\cell.jpg");
                openCellImage = Image.FromFile("C:\\IS - 22\\С#\\Saper\\Images\\openCell.jpg");
                mineImage = Image.FromFile("C:\\IS - 22\\С#\\Saper\\Images\\mine.jpg");
            }
            catch
            {

            }
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
            this.Text = $"Игровое поле (Перезарядка: {abilityCooldown} секунд)"; // Обновляем заголовок
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++; // Увеличиваем время на 1 секунду
            UpdateLabels(); // Обновляем метки

            // Уменьшаем время перезарядки, если оно больше 0
            if (abilityCooldown > 0)
            {
                abilityCooldown--;
            }
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
                button.BackgroundImage = mineImage; // Устанавливаем изображение мины
                button.BackgroundImageLayout = ImageLayout.Stretch; // Растягиваем изображение

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

            // Проверяем, нужно ли вернуть флажок
            if (flagsPlaced > 0)
            {
                foreach (var btn in buttons)
                {
                    if (btn.Text == "★" && !btn.Enabled) // Если флажок установлен на открытой клетке
                    {
                        btn.Text = ""; // Убираем флажок
                        flagsPlaced--; // Уменьшаем счетчик флажков
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
                    if (flagsPlaced < mines) // Проверяем, не превышает ли количество флажков количество мин
                    {
                        button.Text = "★"; // Устанавливаем флажок
                        flagsPlaced++; // Увеличиваем счетчик флажков
                    }
                    else
                    {
                        MessageBox.Show("Нельзя установить больше флажков, чем мин!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                UpdateLabels(); // Обновляем метки
            }
        }

        private void RemoveAnyFlag()
        {
            // Ищем любую кнопку с установленным флажком и убираем его
            foreach (var btn in buttons)
            {
                if (btn.Text == "★")
                {
                    btn.Text = ""; // Убираем флажок
                    flagsPlaced--; // Уменьшаем счетчик флажков
                    break; // Выходим из цикла после удаления одного флажка
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
                        File.WriteAllLines(leaderboardFilePath, lines.OrderBy(line => int.Parse(line.Split(';')[1])).ToList());
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
        private int abilityCooldown = 0; // Время перезарядки в секундах
        private const int abilityCooldownTime = 100; // Время перезарядки в секундах
        private void BtnFlagRandomMine_Click(object sender, EventArgs e)
        {

            if (abilityCooldown > 0)
            {
                MessageBox.Show($"Способность перезаряжается. Осталось времени: {abilityCooldown} секунд.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем все позиции мин
            var minePositions = new List<Point>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (mineField[i, j] && buttons[i, j].Text != "★") // Если это мина и флажок не установлен
                    {
                        minePositions.Add(new Point(i, j));
                    }
                }
            }

            // Если есть мины, устанавливаем флажок на одну случайную
            if (minePositions.Count > 0)
            {

                Random rand = new Random();
                int randomIndex = rand.Next(minePositions.Count);
                Point randomMine = minePositions[randomIndex];
                if (minePositions.Count == flagsPlaced)
                {
                    RemoveAnyFlag();
                }
                // Устанавливаем флажок на случайную мину
                Button button = buttons[randomMine.X, randomMine.Y];
                button.Text = "★"; // Устанавливаем флажок
                flagsPlaced++; // Увеличиваем счетчик флажков
                UpdateLabels(); // Обновляем метки

                // Устанавливаем время перезарядки
                abilityCooldown = abilityCooldownTime;
            }
            else
            {
                MessageBox.Show("Нет мин для установки флажка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
