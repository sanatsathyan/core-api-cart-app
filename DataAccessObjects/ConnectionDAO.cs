using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessObjects
{
    class ConnectionDAO
    {
        private IConfiguration Configuration;
        SqlConnection objSqlConnection;

        public ConnectionDAO(IConfiguration _configuration)
        {
            Configuration = _configuration;
            objSqlConnection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
        }

        public SqlConnection OpenConnection()
        {
            objSqlConnection.Open();
            return objSqlConnection;
        }

        public void CloseConnection()
        {
            if (objSqlConnection != null && objSqlConnection.State == ConnectionState.Open)
                objSqlConnection.Close();
        }
    }
}
