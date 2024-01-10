using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrackingApp
{
    public partial class ChangeLoginForm : Form
    {

        string _initialNewLoginBoxText = "Введите новое имя пользователя";
        public Users User { get; set; }

        public ChangeLoginForm(Users user)
        {
            User = user;
            InitializeComponent();
        }

        private void ChangeNameForm_Load(object sender, EventArgs e)
        {
            NewLoginBox.Text = _initialNewLoginBoxText;
        }

        private void ChangeLoginButton_Click(object sender, EventArgs e)
        {
            if (User.DoesExist(NewLoginBox.Text))
            {
                MessageBox.Show("Пользователь с данным логином существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User.ChangeName(NewLoginBox.Text);

            Close();
        }

        private void NewLoginBox_Enter(object sender, EventArgs e)
        {
            if (NewLoginBox.Text == _initialNewLoginBoxText)
                NewLoginBox.Text = string.Empty;
        }

        private void NewLoginBox_Leave(object sender, EventArgs e)
        {
            if (NewLoginBox.Text == string.Empty)
                NewLoginBox.Text = _initialNewLoginBoxText;
        }
    }
}

