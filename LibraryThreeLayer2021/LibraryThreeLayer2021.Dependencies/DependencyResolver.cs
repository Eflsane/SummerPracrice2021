using LibraryThreeLayer2021.BLL.InterfaceBLL;
using LibraryThreeLayer2021.BLL.Real1BLL;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using LibraryThreeLayer2021.DAL.SqlDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.Common.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null) _instance = new DependencyResolver();
                return _instance;
            }
        }

        public ILibDAO DAO => new SqlDAO();
        public ILogic BLL => new BLL1(DAO);
    }
}
