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
        User _user {  get; set; }

        public ChangeNameForm(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void ChangeLoginButton_Click(object sender, EventArgs e)
        {
            _user.Name = NewLoginBox.Text;

            if (_user.DoesExist())
            {
                MessageBox.Show("Пользователь с данным логином существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _user.ChangeName();

            Close();
        }
    }
}
