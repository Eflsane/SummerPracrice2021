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
    public class AuthorBLL1 : BLL1, IAuthorLogic
    {
        private IAuthorDAO _dao;

        public AuthorBLL1(IAuthorDAO dao)
        {
            _dao = dao;
        }

        public bool AddAuthor(string secondname, string firstname, DateTime birth_date)
        {
            return _dao.AddAuthor(secondname, firstname, birth_date);
        }

        public bool DeleteAuthor(long authorID)
        {
            return _dao.DeleteAuthor(authorID);
        }

        public List<Author> FindAuthors(string author)
        {
            List<Author> authors = new List<Author>();

            foreach (Author authorItem in _dao.FindAuthors(author))
            {
                authors.Add(authorItem);
            }

            return authors;
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> authors = new List<Author>();

            foreach (Author author in _dao.GetAllAuthors())
            {
                authors.Add(author);
            }

            return authors;
        }

        public Author GetAuthorByID(long authorID)
        {
            return _dao.GetAuthorByID(authorID);
        }

        public bool UpdateAuthor(long ID, string secondname, string firstname, DateTime birthDate)
        {
            return _dao.UpdateAuthor(ID, secondname, firstname, birthDate);
        }
    }
}
