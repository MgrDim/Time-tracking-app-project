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
        Activity _activity { get; set; }
        public NameActivityForm(Activity activity)
        {
            _activity = activity;
            InitializeComponent();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            _activity.Name = ActivityNameBox.Text;

            if (_activity.Name != null)
            {
                var DB = new DataBase();

                var command = new NpgsqlCommand("CALL insert_activities(@activityname, @datetime)", DB.Connection);

                command.Parameters.Add("@activityname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = _activity.Name;
                command.Parameters.Add("@datetime", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = _activity.Start;

                DB.OpenConnection();

                command.ExecuteNonQuery();

                DB.CloseConnection();

                _activity.Id = GetActivityId(_activity.Name);
                Close();
            }
        }

        private int GetActivityId(string activityName)
        {
            var DB = new DataBase();
            int result = 0;

            var command = new NpgsqlCommand("SELECT activity_id FROM activities" +
                " WHERE activity_name = @activityname", DB.Connection);

            command.Parameters.Add("@activityname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = activityName;

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                result = reader.GetInt32(0);

            DB.CloseConnection();

            return result;
        }

        private void NameActivityForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_activity.Name == null)
            {
                MessageBox.Show("Введите название задачи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }
    }
}
