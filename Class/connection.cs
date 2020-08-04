using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RealEstateManagement.Class;

namespace RealEstateManagement.Class
{
    class connection
    {
        public MySqlConnection connectDB;
        public connection() 
        {
            string host = "localhost";
            string db = "rems";
            string port = "3306";
            string user = "admin_alex";
            string pass = "pass123";
            string constring = "datasource=" + host + ";database=" + db + ";port=" + port + ";username=" + user + ";password=" + pass + "; SslMode=none";
            connectDB = new MySqlConnection(constring);
        }
    }

}
