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
    public class GenreBLL1 : BLL1, IGenreLogic
    {
        private IGenreDAO _dao;

        public GenreBLL1(IGenreDAO dao)
        {
            _dao = dao;
        }

        public bool AddGenre(string name, string desc)
        {
            return _dao.AddGenre(name, desc);
        }

        public bool DeleteGenre(long genreID)
        {
            return _dao.DeleteGenre(genreID);
        }

        public List<Genre> GetAllGenres()
        {
            List<Genre> genres = new List<Genre>();

            foreach (Genre genre in _dao.GetAllGenres())
            {
                genres.Add(genre);
            }

            return genres;
        }

        public Genre GetGenreByID(long genreID)
        {
            return _dao.GetGenreByID(genreID);
        }

        public List<Genre> GetGenresOfBookById(long bookID)
        {
            List<Genre> genres = new List<Genre>();

            foreach (Genre genre in _dao.GetGenresOfBookById(bookID))
            {
                genres.Add(genre);
            }

            return genres;
        }

        public bool UpdateGenre(long ID, string name, string desc)
        {
            return _dao.UpdateGenre(ID, name, desc);
        }
    }
}
