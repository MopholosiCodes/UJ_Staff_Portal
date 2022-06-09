using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace DataLayer
{
    public class DatabaseStorage
    {
        private string _connection_string = @"server=localhost;userid=root;password=;database=uj_staff_portal";
        private List<StaffMember> StaffMembers = new List<StaffMember>();

        // Store Data to database
        public void StoreData(string name, string surname, string email, int age)
        {
            using (var _connection = new MySqlConnection(_connection_string))
            {
                try
                {
                    _connection.Open();

                    string query = $@"
                    INSERT INTO `staff_member`(`FirstName`, `LastName`, `Email`, `Age`) 
                    VALUES ('{name}','{surname}','{email}','{age}')";

                    var command = new MySqlCommand(query, _connection);
                    command.ExecuteNonQuery();

                    _connection.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Read data from Database
        public List<StaffMember> ReadData()
        {
            using (var _connection = new MySqlConnection(_connection_string))
            {
                try
                {
                    _connection.Open();

                    string query = $@"SELECT * FROM `staff_member`";

                    MySqlCommand command = new MySqlCommand(query,_connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        StaffMembers.Add(new StaffMember
                        {
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(4),
                            Age = reader.GetInt32(5)
                        });
                    }

                    _connection.Close();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return StaffMembers;
            }
        }
    }
}
