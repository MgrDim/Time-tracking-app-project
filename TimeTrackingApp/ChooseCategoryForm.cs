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
    public partial class ChooseCategoryForm : Form
    {
        Category _category { get; set; }
        User _user { get; set; }
        Activity _activity { get; set; }

        public ChooseCategoryForm(Category category, User user, Activity activity)
        {
            _category = category;
            _user = user;
            _activity = activity;
            InitializeComponent();
        }

        private void categoryNameBox_Enter(object sender, EventArgs e)
        {
            var categories = _category.GetAllNames();
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
                _category.SetId();

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
