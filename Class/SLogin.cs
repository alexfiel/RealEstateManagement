using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RealEstateManagement.Class;

namespace RealEstateManagement.Class
{
    class SLogin:connection
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        public bool Validate_User()
        {
            bool check = false;
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "Select * from `user` where username=@user and password=@pass";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;

                //parameters
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = Username;
                cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = Password;

                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    check = true;
                    UserRole = rd.GetString("role");
                }
                connectDB.Close();
            }

            return check;
        }

    }
}
