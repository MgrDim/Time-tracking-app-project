using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingApp
{
    public class Activity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public void SetId()
        {
            var DB = new DataBase();
            int id = 0;

            var command = new NpgsqlCommand("SELECT activity_id FROM activities" +
                " WHERE activity_name = @activityname ORDER BY activity_id DESC LIMIT 1", DB.Connection);

            command.Parameters.Add("@activityname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Name;

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                id = reader.GetInt32(0);

            DB.CloseConnection();

            Id = id;
        }
    }
}
