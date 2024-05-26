using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace test1
{
    class DataBase
    {
        SqlConnection conn = new SqlConnection(@"Data Source=PCHEL228\SQLSERVER;Initial Catalog=Statements_from_citizens;Integrated Security=True");

        public void openConnection()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }
    }
}
