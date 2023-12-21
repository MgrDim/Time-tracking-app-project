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
    public partial class ChooseCategory : Form
    {
        Category _category { get; set; }
        User _user { get; set; }
        Activity _activity { get; set; }

        public ChooseCategory(Category category, User user, Activity activity)
        {
            _category = category;
            _user = user;
            _activity = activity;
            InitializeComponent();
        }

        private void categoryNameBox_Enter(object sender, EventArgs e)
        {
            var categories = GetCategoryNames();
            foreach (var category in categories)
            {
                categoryNameBox.Items.Add(category);
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            _category.Name = categoryNameBox.Text;

            if (_category.Name != null)
            {
                _category.Id = GetCategoryId(_category.Name);

                var DB = new DataBase();

                var command = new NpgsqlCommand("CALL add_category_id(@categoryid, @activityid); " +
                    "CALL insert_users_categories(@userid, @categoryid)", DB.Connection);

                command.Parameters.Add("@categoryid", NpgsqlTypes.NpgsqlDbType.Integer).Value = _category.Id;
                command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = _user.Id;
                command.Parameters.Add("@activityid", NpgsqlTypes.NpgsqlDbType.Integer).Value = _activity.Id;

                DB.OpenConnection();

                command.ExecuteNonQuery();

                DB.CloseConnection();

                Close();
            }
        }

        private List<string> GetCategoryNames()
        {
            var categories = new List<string>();
            var DB = new DataBase();

            var command = new NpgsqlCommand("SELECT category_name FROM categories", DB.Connection);

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    categories.Add(reader.GetString(0));
                }
            }

            DB.CloseConnection();
            return categories;
        }

        private int GetCategoryId(string categoryName)
        {
            var DB = new DataBase();
            int result = 0;

            var command = new NpgsqlCommand("SELECT category_id FROM categories" +
                " WHERE category_name = @categoryname", DB.Connection);

            command.Parameters.Add("@categoryname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = categoryName;

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows && reader.Read())
            {
                result = reader.GetInt32(0);
            }

            DB.CloseConnection();

            return result;
        }

        private void ChooseCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_category.Name == null)
            {
                MessageBox.Show("Выберите категорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
