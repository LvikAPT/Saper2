﻿﻿﻿﻿﻿﻿﻿// HelpForm.cs
using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            LoadHelpContent();
        }

        private void LoadHelpContent()
        {
            string rules = "Правила игры:\n" +
                           "1. Цель игры - очистить минное поле, не подорвав ни одной мины.\n" +
                           "2. Нажмите на ячейку, чтобы открыть её. Если в ней находится мина, игра окончена.\n" +
                           "3. Щелкните правой кнопкой мыши, чтобы установить флажок на ячейке, чтобы отметить её как подозреваемую мину.\n" +
                           "4. Игра выиграна, когда все ячейки без мин открыты.\n" +
                           "5. Используйте таймер, чтобы отслеживать ваш прогресс.\n" +
                           "6. Вы можете приостановить игру в любое время.\n\n" +
                           "Советы:\n" +
                           "- Начинайте с нажатия на углы или края сетки.\n" +
                           "- Используйте флажки с умом, чтобы отслеживать подозреваемые мины.\n" +
                           "- Обращайте внимание на числа, которые открываются, так как они указывают, сколько мин находится рядом с этой ячейкой.";


            TextBox helpTextBox = new TextBox
            {
                Text = rules,
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true
            };


            Button closeButton = new Button
            {
                Text = "Закрыть",
                Dock = DockStyle.Bottom
            };
            closeButton.Click += (sender, e) => this.Close();

            this.Controls.Add(helpTextBox);

            this.Controls.Add(closeButton);
            this.Text = "Помощь";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(400, 300);
        }
    }
}
