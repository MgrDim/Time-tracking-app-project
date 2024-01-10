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
        public Categories Category { get; set; }
        public Users User { get; set; }
        public Activities Activity { get; set; }

        public ChooseCategoryForm(Categories category, Users user, Activities activity)
        {
            Category = category;
            User = user;
            Activity = activity;
            InitializeComponent();
        }

        private void ChooseCategoryForm_Load(object sender, EventArgs e)
        {
            var categories = Category.GetAllNames();
            foreach (var category in categories)
            {
                categoryBox.Items.Add(category);
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            Category.Name = categoryBox.Text;

            if (Category.Name != null)
            {
                Category.SetId();

                var DB = new DataBase();
                var command = new NpgsqlCommand("CALL add_category_id(@categoryid, @activityid); " +
                    "CALL insert_users_categories(@userid, @categoryid)", DB.Connection);

                command.Parameters.Add("@categoryid", NpgsqlTypes.NpgsqlDbType.Integer).Value = Category.Id;
                command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = User.Id;
                command.Parameters.Add("@activityid", NpgsqlTypes.NpgsqlDbType.Integer).Value = Activity.Id;

                DB.OpenConnection();

                command.ExecuteNonQuery();

                DB.CloseConnection();

                Close();
            }
        }

        private void ChooseCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Category.Name == null)
            {
                MessageBox.Show("Выберите категорию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
