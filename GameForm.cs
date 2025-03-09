// GameForm.cs
using System;
using System.Drawing;
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
        private System.Windows.Forms.Timer timer; // Explicitly use System.Windows.Forms.Timer

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
                case "Тестовый": // New case for test level
                    rows = 4;
                    columns = 4;
                    mines = 1;
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
                    buttons[i, j].Click += Button_Click;
                    buttons[i, j].ContextMenuStrip = CreateContextMenu(); // Добавляем контекстное меню для установки флажка
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
            timer = new System.Windows.Forms.Timer(); // Explicitly use System.Windows.Forms.Timer
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
                ShowResult();
            }
            else
            {
                button.BackColor = Color.LightGray; // Открываем клетку
                // Здесь можно добавить логику для подсчета соседних мин
            }
        }

        private ContextMenuStrip CreateContextMenu()
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem flagItem = new ToolStripMenuItem("Установить флажок");
            flagItem.Click += FlagItem_Click;
            contextMenu.Items.Add(flagItem);
            return contextMenu;
        }

        private void FlagItem_Click(object sender, EventArgs e)
        {
            if (gameOver) return;

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            Button button = (Button)item.GetCurrentParent().Controls[0]; // Correctly access the button

            int row = button.Location.Y / 30;
            int col = button.Location.X / 30;

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

        private void ShowResult()
        {
            if (gameOver) return; // Prevent recording if the game is over due to hitting a mine

            int finalTime = elapsedTime - flagsPlaced; // Вычитаем секунды за установленные флажки
            string resultMessage;
            if (flagsPlaced == mines) 







            {
                resultMessage = "Поздравляем! Вы выиграли!";
            } 
            else 
            {
                resultMessage = "Игра окончена! Вы попали на мину.";
            }
            ResultForm resultForm = new ResultForm(resultMessage, "Сложность", finalTime); // Ensure correct constructor

            resultForm.ShowDialog();
            this.Close();
        }
    }
}
