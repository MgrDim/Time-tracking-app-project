using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
        public Users User = new ();

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

            User.Login = LoginBox.Text;
            var password = PassBox.Text;
            var repPassword = RepPassBox.Text;

            if (!PasswordValidation(PassBox.Text)) return;
            if (!DoPasswordsMatch(password, repPassword)) return;
            if (User.DoesExist(User.Login))
            {
                MessageBox.Show("Пользователь с данным логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var salt = GenerateSalt();
            var hashedPassword = GenerateSHA256Hash(password, salt);
            var passwordInDB = $"{ConvertByteArrToHexString(hashedPassword)}${salt}";

            var DB = new DataBase();
            var command = new NpgsqlCommand("INSERT INTO users(user_login, user_password)" +
                " VALUES (@userlogin, @userpass)", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = User.Login;
            command.Parameters.Add("@userpass", NpgsqlTypes.NpgsqlDbType.Varchar).Value = passwordInDB;

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

        private bool DoPasswordsMatch(string pass1, string pass2)
        {
            if (pass1 != pass2)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        private bool IsLoginFieldEmpty()
        {
            if (LoginBox.Text == _initialLoginBoxText)
            {
                MessageBox.Show("Не введен логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private bool IsPasswordFieldEmpty()
        {
            if (PassBox.Text == _initialPassBoxText)
            {
                MessageBox.Show("Не введен пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else
                return false;
        }

        private bool PasswordValidation(string password)
        {
            if (IsPasswordStrong(password))
                return true;
            else if (password.Length < 10)
                MessageBox.Show("Длина пароля должна быть более десяти символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Пароль должен являться сочетанием букв верхнего регистра, " +
                    "букв нижнего регистра и цифр", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        private bool IsPasswordStrong(string password)
        {
            bool digits = false, uppercase = false, lowercase = false;

            foreach (char c in password)
            {
                if (char.IsDigit(c) && digits == false) digits = true;
                else if (char.IsUpper(c) && uppercase == false) uppercase = true;
                else if (char.IsLower(c) && lowercase == false) lowercase = true;
            }

            if (password.Length >= 10 && digits && uppercase && lowercase)
                return true;
            else
                return false;
        }

        private string ConvertByteArrToHexString(byte[] arr)
        {
            return BitConverter.ToString(arr).Replace("-", string.Empty).ToLower();
        }

        private string GenerateSalt()
        {
            var rand = new Random();
            var salt = new byte[rand.Next(10, 24)];

            rand.NextBytes(salt);

            return string.Concat(ConvertByteArrToHexString(salt));
        }

        private byte[] GenerateSHA256Hash(string password, string salt)
        {
            var saltedPassword = string.Concat(password, salt);
            var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            var sha256 = SHA256.Create();

            return sha256.ComputeHash(saltedPasswordBytes);
        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if (LoginBox.Text == _initialLoginBoxText)
                LoginBox.Text = string.Empty;
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if (LoginBox.Text == string.Empty)
                LoginBox.Text = _initialLoginBoxText;
        }

        private void PassBox_Enter(object sender, EventArgs e)
        {
            if (PassBox.Text == _initialPassBoxText)
            {
                PassBox.Text = string.Empty;
                PassBox.UseSystemPasswordChar = true;
            }
        }

        private void PassBox_Leave(object sender, EventArgs e)
        {
            if (PassBox.Text == string.Empty)
            {
                PassBox.Text = _initialPassBoxText;
                PassBox.UseSystemPasswordChar = false;
            }
        }

        private void RepPassBox_Enter(object sender, EventArgs e)
        {
            if (RepPassBox.Text == _initialRepPassBoxText)
            {
                RepPassBox.Text = string.Empty;
                RepPassBox.UseSystemPasswordChar = true;
            }
        }

        private void RepPassBox_Leave(object sender, EventArgs e)
        {
            if (RepPassBox.Text == string.Empty)
            {
                RepPassBox.Text = _initialRepPassBoxText;
                RepPassBox.UseSystemPasswordChar = false;
            }
        }
    }
}
