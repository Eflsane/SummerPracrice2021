using LibraryThreeLayer2021.BLL.InterfaceBLL;
using LibraryThreeLayer2021.Common.Entities;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.BLL.Real1BLL
{
    public class UserBLL1 : BLL1, IUserLogic
    {
        private IUserDAO _dao;

        public UserBLL1(IUserDAO dao)
        {
            _dao = dao;
        }

        public bool AddUser(string username, string password, bool sex, string customName = null, bool isAdmin = false)
        {
            return _dao.AddUser(username, password, sex, customName, isAdmin);
        }

        public bool CheckAdminPass(string password)
        {
            return _dao.CheckAdminPass(password);
        }

        public bool DeleteUser(string username)
        {
            return _dao.DeleteUser(username);
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            foreach (User user in _dao.GetAllUsers())
            {
                users.Add(user);
            }

            return users;
        }

        public User GetUserByName(string username)
        {
            return _dao.GetUserByName(username);
        }

        public bool GetUserByNameAndPass(string username, string pass)
        {
            return _dao.GetUserByNameAndPass(username, pass);
        }

        public bool UpdateUser(string username, bool sex, string customName = null)
        {
            return _dao.UpdateUser(username, sex, customName);
        }

        public bool UpdateUserPass(string username, string newPass)
        {
            return _dao.UpdateUserPass(username, newPass);
        }
    }

}
