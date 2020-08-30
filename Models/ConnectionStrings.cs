using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUD_Car_Rental.Models
{
    public class ConnectionStrings : IDisposable
    {
        public MySqlConnection Connection;

        public ConnectionStrings(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }

        public void Dispose()
        {
            Connection.Close();
        }

    }
}
