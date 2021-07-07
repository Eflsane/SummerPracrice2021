using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface IGenreDAO
    {
        bool AddGenre(string name, string desc);       

        bool DeleteGenre(long genreID);

        IEnumerable<Genre> GetAllGenres();

        Genre GetGenreByID(long genreID);

        IEnumerable<Genre> GetGenresOfBookById(long bookID);

        bool UpdateGenre(long ID, string name, string desc);
    }
}
