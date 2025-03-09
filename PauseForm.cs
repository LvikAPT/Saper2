// PauseForm.cs
using System;
using System.Windows.Forms;

namespace Saper
{
    public partial class PauseForm : Form
    {
        private GameForm gameForm; // ������ �� ������� �����

        public PauseForm(GameForm gameForm)
        {
            InitializeComponent();
            this.gameForm = gameForm; // ��������� ������ �� ������� �����
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            this.Close(); // ��������� ����� �����, ����� ��������� � ����
            gameForm.Show(); // ���������� ������� �����
        }

        private void btnExitToMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide(); // �������� ����� �����
            gameForm.Hide(); // �������� ������� �����
        }
    }
}