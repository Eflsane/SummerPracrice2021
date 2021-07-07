using LibraryThreeLayer2021.BLL.InterfaceBLL;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.BLL.Real1BLL
{
    public class BookGenresBLL1 : BLL1, IBookGenresLogic
    {
        private IBookGenresDAO _dao;

        public BookGenresBLL1(IBookGenresDAO dao)
        {
            _dao = dao;
        }

        public bool AddGenreToBook(long bookID, long genreID)
        {
            return _dao.AddGenreToBook(bookID, genreID);
        }

        public bool DeleteAllGenresFromBook(long bookID)
        {
            return _dao.DeleteAllGenresFromBook(bookID);
        }

        public bool DeleteConnectionOfGenreWithBooks(long genreID)
        {
            return _dao.DeleteConnectionOfGenreWithBooks(genreID);
        }

        public bool DeleteGenreFromBook(long bookID, long genreID)
        {
            return _dao.DeleteGenreFromBook(bookID, genreID);
        }
    }
}
