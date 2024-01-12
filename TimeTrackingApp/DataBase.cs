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
        NpgsqlConnection _connection = new NpgsqlConnection("Host=78.153.5.230;Port=8595;Username=dbekbulatov;Password=XNSQTXcGHk;Database=timetrackingapp");
        
        public NpgsqlConnection Connection { get { return _connection; } }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при соединении с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Произошла ошибка при соединении с сервером", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
