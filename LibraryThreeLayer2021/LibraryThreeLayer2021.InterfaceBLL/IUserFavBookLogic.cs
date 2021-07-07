using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.BLL.InterfaceBLL
{
    public interface IUserFavBookLogic
    {
        bool AddBookToFavorite(string username, long bookID);

        bool DeleteAllFavBooksFromUser(string username);

        bool DeleteConnectionFavBookWithUsers(long bookID);

        bool DeleteFavBookFromUser(string username, long bookID);

        List<Book> GetFavBooksOfUser(string username);
    }
}
