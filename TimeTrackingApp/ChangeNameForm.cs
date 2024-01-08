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
    public partial class ChangeNameForm : Form
    {

        string _initialNewLoginBoxText = "Введите новое имя пользователя";
        User _user { get; set; }

        public ChangeNameForm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void ChangeNameForm_Load(object sender, EventArgs e)
        {
            NewLoginBox.Text = _initialNewLoginBoxText;
        }

        private void ChangeLoginButton_Click(object sender, EventArgs e)
        {
            if (_user.DoesExist(NewLoginBox.Text))
            {
                MessageBox.Show("Пользователь с данным логином существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.ChangeName(NewLoginBox.Text);

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

