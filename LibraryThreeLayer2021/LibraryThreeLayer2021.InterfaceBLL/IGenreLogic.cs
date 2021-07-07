using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.BLL.InterfaceBLL
{
    public interface IGenreLogic
    {
        bool AddGenre(string name, string desc);

        bool DeleteGenre(long genreID);

        List<Genre> GetAllGenres();

        Genre GetGenreByID(long genreID);

        List<Genre> GetGenresOfBookById(long bookID);

        bool UpdateGenre(long ID, string name, string desc);
    }
}
