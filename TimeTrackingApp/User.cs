﻿using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingApp
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Activity[]? Activities { get; set; }

        public void ChangeName()
        {
            var DB = new DataBase();

            var command = new NpgsqlCommand("UPDATE users SET user_login = @newlogin" +
            " WHERE user_id = @userid", DB.Connection);

            command.Parameters.Add("@userid", NpgsqlTypes.NpgsqlDbType.Integer).Value = Id;
            command.Parameters.Add("@newlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Name;

            DB.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Имя пользователя успешно изменено", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Произошла ошибка при смене имени пользователя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            DB.CloseConnection();
        }

        public bool DoesExist()
        {
            var DB = new DataBase();

            var table = new DataTable();
            var adapter = new NpgsqlDataAdapter();
            var command = new NpgsqlCommand("SELECT * FROM users" +
                " WHERE user_login = @userlogin", DB.Connection);

            command.Parameters.Add("@userlogin", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Name;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
                return true;
            else
                return false;
        }
    }
}
