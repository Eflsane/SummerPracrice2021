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

        private ILibDAO DAO => new SqlDAO();
        public ILogic BLL => new BLL1();

        private IAuthorDAO AuthorDAO => new SqlAuthorDAO();
        public IAuthorLogic AuthorBLL => new AuthorBLL1(AuthorDAO);

        private IBookDAO BookDAO => new SqlBookDAO();
        public IBookLogic BookBLL => new BookBLL1(BookDAO);

        private IBookGenresDAO BookGenresDAO => new SqlBookGenresDAO();
        public IBookGenresLogic BookGenresBLL => new BookGenresBLL1(BookGenresDAO);

        private IGenreDAO GenreDAO => new SqlGenreDAO();
        public IGenreLogic GenreBLL => new GenreBLL1(GenreDAO);

        private IUserDAO UserDAO => new SqlUserDAO();
        public IUserLogic UserBLL => new UserBLL1(UserDAO);

        private IUserFavBookDAO UserFavBookDAO => new SqlUserFavBookDAO();
        public IUserFavBookLogic UserFavBookBLL => new UserFavBookBLL1(UserFavBookDAO);
    }
}
