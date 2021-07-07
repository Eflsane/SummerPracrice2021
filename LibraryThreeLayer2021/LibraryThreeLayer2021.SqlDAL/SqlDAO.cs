using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using LibraryThreeLayer2021.Common.Entities;
using System.Configuration;
using System.Data.SqlClient;

namespace LibraryThreeLayer2021.DAL.SqlDAL
{
    public class SqlDAO : ILibDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        protected static SqlConnection _connection;

        public SqlConnection GetNewSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        

        

        

        

        

        

        

        

        

        

        

        

        

        

        

        

        

        

        

       

        
        
        

        

        

        

        

        

        

        
    }
}
