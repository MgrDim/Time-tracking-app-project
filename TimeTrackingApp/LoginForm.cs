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
    public partial class LoginForm : Form
    {
        int _numberOfAttempts = 5;
        string _initialLoginBoxText = "Пользователь";
        string _initialPassBoxText = "*************";
        public User User { get; set; }

        public LoginForm(User user)
        {
            User = user;
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            LoginBox.Text = _initialLoginBoxText;
            PassBox.Text = _initialPassBoxText;
        }

        private void AuthButton_Click(object sender, EventArgs e)
        {
            User.Name = LoginBox.Text;
            var enteredPassword = PassBox.Text;

            if (!User.DoesExist(User.Name))
            {
                MessageBox.Show("Пользователя с таким именем не существует",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginFail();
                return;
            }

            var DB = new DataBase();

            var command = new NpgsqlCommand("SELECT user_password FROM users" +
                " WHERE user_login = @userlogin", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = User.Name;

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            var dbData = reader.GetString(0).Split("$");

            DB.CloseConnection();

            var passwordHash = dbData[0];
            var salt = dbData[1];

            if (CheckPassword(enteredPassword, salt, passwordHash))
                DialogResult = DialogResult.OK;
            else
            {
                LoginFail();
                MessageBox.Show("Неверный пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (_numberOfAttempts == 0)
                DialogResult = DialogResult.Cancel;
        }

        private void LoginFail()
        {
            LoginBox.Text = _initialLoginBoxText;
            PassBox.Text = _initialPassBoxText;
            PassBox.UseSystemPasswordChar = false;
            _numberOfAttempts -= 1;
            WarnMessage.Text = $"Осталось попыток {_numberOfAttempts}";
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerForm = new RegisterForm();

            registerForm.ShowDialog();
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

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (User.Name != null)
                User.SetId();
        }

        private static byte[] GenerateSHA256Hash(string password, string salt)
        {
            var saltedPassword = string.Concat(password, salt);
            var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            var sha256 = SHA256.Create();

            return sha256.ComputeHash(saltedPasswordBytes);
        }

        private static bool CheckPassword(string enteredPassword, string salt, string passwordHash)
        {
            var enteredPasswordHash = GenerateSHA256Hash(enteredPassword, salt);
            var hashInString = BitConverter.ToString(enteredPasswordHash).Replace("-", String.Empty).ToLower();
            if (hashInString.SequenceEqual(passwordHash))
                return true;
            else
                return false;
        }
    }
}
