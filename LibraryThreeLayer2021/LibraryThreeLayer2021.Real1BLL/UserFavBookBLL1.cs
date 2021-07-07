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
    public class UserFavBookBLL1 : BLL1, IUserFavBookLogic
    {
        private IUserFavBookDAO _dao;

        public UserFavBookBLL1(IUserFavBookDAO dao)
        {
            _dao = dao;
        }

        public bool AddBookToFavorite(string username, long bookID)
        {
            return _dao.AddBookToFavorite(username, bookID);
        }

        public bool DeleteAllFavBooksFromUser(string username)
        {
            return _dao.DeleteAllFavBooksFromUser(username);
        }

        public bool DeleteConnectionFavBookWithUsers(long bookID)
        {
            return _dao.DeleteConnectionFavBookWithUsers(bookID);
        }

        public bool DeleteFavBookFromUser(string username, long bookID)
        {
            return _dao.DeleteFavBookFromUser(username, bookID);
        }

        public List<Book> GetFavBooksOfUser(string username)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.GetFavBooksOfUser(username))
            {
                books.Add(book);
            }

            return books;
        }
    }
}
