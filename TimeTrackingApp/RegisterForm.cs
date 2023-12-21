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
    public partial class RegisterForm : Form
    {
        string _initialLoginBoxText = "Введите логин";
        string _initialPassBoxText = "Придумайте пароль";
        string _initialRepPassBoxText = "Повторите введенный пароль";

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            LoginBox.Text = _initialLoginBoxText;
            PassBox.Text = _initialPassBoxText;
            RepPassBox.Text = _initialRepPassBoxText;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (IsLoginFieldEmpty()) return;
            if (IsPasswordFieldEmpty()) return;

            string login = LoginBox.Text;
            string password = PassBox.Text;
            string repPassword = RepPassBox.Text;

            if (!PasswordValidation(PassBox.Text)) return;
            if (!DoPasswordsMatch(password, repPassword)) return;
            if (DoesUserExist(login)) return;

            var DB = new DataBase();

            var command = new NpgsqlCommand("INSERT INTO users(user_login, user_password)" +
                " VALUES (@userlogin, @userpass)", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = login;
            command.Parameters.Add("@userpass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = password;

            DB.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Аккаунт не был создан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DB.CloseConnection();
        }

        private Boolean DoesUserExist(string UserLogin)
        {
            var DB = new DataBase();

            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("SELECT * FROM users" +
                " WHERE user_login = @userlogin", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = UserLogin;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с данным логином существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private Boolean DoPasswordsMatch(string pass1, string pass2)
        {
            if (pass1 != pass2)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private Boolean IsLoginFieldEmpty()
        {
            if (LoginBox.Text == _initialLoginBoxText)
            {
                MessageBox.Show("Не введен логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private Boolean IsPasswordFieldEmpty()
        {
            if (PassBox.Text == _initialPassBoxText)
            {
                MessageBox.Show("Не введен пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private Boolean PasswordValidation(string password)
        {
            if (password.Length >= 10 && password.All(c => !char.IsDigit(c)))
                return true;
            else if (password.Length < 10)
                MessageBox.Show("Длина пароля должна быть более десяти символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (password.All(c => char.IsDigit(c)))
                MessageBox.Show("Пароль не должен содержать цифры", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
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

        private void RepPassBox_Enter(object sender, EventArgs e)
        {
            if (RepPassBox.Text == _initialRepPassBoxText)
            {
                RepPassBox.Text = String.Empty;
                RepPassBox.UseSystemPasswordChar = true;
            }
        }

        private void RepPassBox_Leave(object sender, EventArgs e)
        {
            if (RepPassBox.Text == String.Empty)
            {
                RepPassBox.Text = _initialRepPassBoxText;
                RepPassBox.UseSystemPasswordChar = false;
            }
        }
    }
}
