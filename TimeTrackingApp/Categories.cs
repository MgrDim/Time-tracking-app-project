using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingApp
{
    public class Categories
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public void SetId()
        {
            var DB = new DataBase();
            int id = 0;

            var command = new NpgsqlCommand("SELECT category_id FROM categories" +
                " WHERE category_name = @categoryname", DB.Connection);

            command.Parameters.Add("@categoryname", NpgsqlTypes.NpgsqlDbType.Varchar).Value = Name;

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                id = reader.GetInt32(0);

            DB.CloseConnection();

            Id = id;
        }

        public List<string> GetAllNames()
        {
            var categories = new List<string>();
            var DB = new DataBase();

            var command = new NpgsqlCommand("SELECT category_name FROM categories", DB.Connection);

            DB.OpenConnection();

            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                categories.Add(reader.GetString(0));
            }

            DB.CloseConnection();

            return categories;
        }
    }
}
