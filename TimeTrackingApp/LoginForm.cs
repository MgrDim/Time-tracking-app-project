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
    public partial class LoginForm : Form
    {
        int _numberOfAttempts = 5;
        string _initialLoginBoxText = "Пользователь";
        string _initialPassBoxText = "********";
        public User User = new();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoginBox.Text = _initialLoginBoxText;
            PassBox.Text = _initialPassBoxText;
        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            string login = LoginBox.Text;
            string password = PassBox.Text;

            var DB = new DataBase();

            var adapter = new NpgsqlDataAdapter();
            var table = new DataTable();
            var command = new NpgsqlCommand("SELECT * FROM users" +
                " WHERE user_login = @userlogin AND user_password = @userpass", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = login;
            command.Parameters.Add("@userpass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                DialogResult = DialogResult.OK;
            else
            {
                _numberOfAttempts -= 1;
                MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WarnBox.ForeColor = Color.Red;
                WarnBox.Text = $"Осталось попыток {_numberOfAttempts}";
            }


            if (_numberOfAttempts == 0)
                DialogResult = DialogResult.Cancel;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();

            registerForm.ShowDialog();
        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if (LoginBox.Text == _initialLoginBoxText)
                LoginBox.Text = String.Empty;
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if (LoginBox.Text == String.Empty)
                LoginBox.Text = _initialLoginBoxText;
        }

        private void PassBox_Enter(object sender, EventArgs e)
        {
            if (PassBox.Text == _initialPassBoxText)
            {
                PassBox.Text = String.Empty;
                PassBox.UseSystemPasswordChar = true;
            }

        }

        private void PassBox_Leave(object sender, EventArgs e)
        {
            if (PassBox.Text == String.Empty)
            {
                PassBox.Text = _initialPassBoxText;
                PassBox.UseSystemPasswordChar = false;
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            User.Name = LoginBox.Text;
            User.Id = GetUserId(LoginBox.Text);
        }

        private int GetUserId(string username)
        {
            var DB = new DataBase();
            int result = 0;

            var command = new NpgsqlCommand("SELECT user_id FROM users" +
                " WHERE user_login = @userlogin", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = username;

            DB.OpenConnection();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                result = reader.GetInt32(0);
            DB.CloseConnection();

            return result;
        }
    }
}
