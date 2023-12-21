using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingApp
{
    public class DataBase
    {
        NpgsqlConnection _connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=123;Database=timetrackingapp");
        
        public NpgsqlConnection Connection { get { return _connection; } }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseConnection()
        {
            try
            {
                _connection.Close();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
