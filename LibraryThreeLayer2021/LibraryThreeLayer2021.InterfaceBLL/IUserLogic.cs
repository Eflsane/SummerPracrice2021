using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.BLL.InterfaceBLL
{
    public interface IUserLogic
    {
        bool AddUser(string username, string password, bool sex, string customName = null, bool isAdmin = false);

        bool CheckAdminPass(string password);

        bool DeleteUser(string username);

        List<User> GetAllUsers();

        User GetUserByName(string username);

        bool GetUserByNameAndPass(string username, string pass);

        bool UpdateUser(string username, bool sex, string customName = null);

        bool UpdateUserPass(string username, string newPass);
    }
}
