using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface IBookGenresDAO
    {
        bool AddGenreToBook(long bookID, long genreID);

        bool DeleteAllGenresFromBook(long bookID);

        bool DeleteConnectionOfGenreWithBooks(long genreID);

        bool DeleteGenreFromBook(long bookID, long genreID);
    }
}
