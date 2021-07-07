using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryThreeLayer2021.Common.Entities;


namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface ILibDAO
    {
        SqlConnection GetNewSqlConnection();
    }
}
