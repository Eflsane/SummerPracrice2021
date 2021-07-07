using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface IUserFavBookDAO
    {
        bool AddBookToFavorite(string username, long bookID);

        bool DeleteAllFavBooksFromUser(string username);

        bool DeleteConnectionFavBookWithUsers(long bookID);

        bool DeleteFavBookFromUser(string username, long bookID);

        IEnumerable<Book> GetFavBooksOfUser(string username);
    }
}
