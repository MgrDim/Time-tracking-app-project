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
    public partial class NameActivityForm : Form
    {
        public Activities Activity { get; set; }
        public NameActivityForm(Activities activity)
        {
            Activity = activity;
            InitializeComponent();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            Activity.Start = DateTime.Now;
            Activity.Name = ActivityNameBox.Text;

            if (Activity.Name != null || Activity.Name != string.Empty)
            {
                var DB = new DataBase();
                var command = new NpgsqlCommand("CALL insert_activities(@activityname, @datetime)", DB.Connection);

                command.Parameters.Add("@activityname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Activity.Name;
                command.Parameters.Add("@datetime", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Activity.Start;

                DB.OpenConnection();

                command.ExecuteNonQuery();

                DB.CloseConnection();

                Activity.SetId();
                Close();
            }
            else
                MessageBox.Show("Сформулируйте задачу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void NameActivityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Activity.Name == null)
            {
                MessageBox.Show("Введите название задачи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
