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

            if (_activity.Name != null || _activity.Name != string.Empty)
            {
                var DB = new DataBase();

                var command = new NpgsqlCommand("CALL insert_activities(@activityname, @datetime)", DB.Connection);

                command.Parameters.Add("@activityname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = _activity.Name;
                command.Parameters.Add("@datetime", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = _activity.Start;

                DB.OpenConnection();

                command.ExecuteNonQuery();

                DB.CloseConnection();

                _activity.SetId();
                Close();
            }
            else
                MessageBox.Show("Сформулируйте задачу", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
