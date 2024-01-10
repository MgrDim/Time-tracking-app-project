﻿using Aspose.Cells;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTrackingApp
{
    public partial class MainForm : Form
    {
        int _ticks;
        public Users User { get; set; }
        public Categories Category = new();
        public Activities Activity = new();

        public MainForm(Users user)
        {
            User = user;
            InitializeComponent();
        }

        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == false)
            {
                _ticks = 0;
                TimerLabel.Text = "00:00:00";
                var nameActivityForm = new NameActivityForm(Activity);
                nameActivityForm.ShowDialog();
            }
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _ticks++;
            Activity.End = Activity.Start;
            Activity.End = Activity.End.AddSeconds(_ticks);
            var difference = Activity.End.TimeOfDay - Activity.Start.TimeOfDay;
            TimerLabel.Text = string.Format("{0:00}:{1:00}:{2:00}", difference.Hours, difference.Minutes, difference.Seconds);
        }

        private void StopTimerButton_Click(object sender, EventArgs e)
        {
            if (timer.Enabled == true)
            {
                timer.Stop();

                var DB = new DataBase();
                if (!DB.ConnectionCheck()) return;

                var command = new NpgsqlCommand("CALL update_activities(@activityid, @datetime); " +
                    "CALL insert_users_activities(@userid, @activityid)", DB.Connection);

                command.Parameters.Add("@activityid", NpgsqlTypes.NpgsqlDbType.Integer).Value = Activity.Id;
                command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = User.Id;
                command.Parameters.Add("@datetime", NpgsqlTypes.NpgsqlDbType.Timestamp).Value = Activity.End;

                DB.OpenConnection();

                command.ExecuteNonQuery();

                DB.CloseConnection();

                var chooseCategory = new ChooseCategoryForm(Category, User, Activity);
                chooseCategory.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView.DataSource = GetActivitiesInfo();
            dataGridView.AllowUserToAddRows = false;
        }

        private DataTable GetActivitiesInfo()
        {
            var DB = new DataBase();
            var firstColumnName = "Задача";
            var secondColumnName = "Категория";
            var thirdColumnName = "Время выполнения";

            var command = new NpgsqlCommand("SELECT * FROM get_activities_info(@userid)", DB.Connection);
            command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = User.Id;
            var adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = command;

            var table = new DataTable();

            adapter.Fill(table);

            table.Columns[0].ColumnName = firstColumnName;
            table.Columns[1].ColumnName = secondColumnName;
            table.Columns[2].ColumnName = thirdColumnName;

            return table;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            InitializeDataGridView();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var exportForm = new ExportForm(User);
            exportForm.ShowDialog();
        }

        private void ChangeLogin_Click(object sender, EventArgs e)
        {
            var changeNameForm = new ChangeLoginForm(User);
            changeNameForm.ShowDialog();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            var loginForm = new LoginForm(User);
            loginForm.ShowDialog();
            InitializeDataGridView();
            TimerLabel.Text = "00:00:00";
        }
    }
}
