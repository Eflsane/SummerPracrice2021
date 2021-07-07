using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface IAuthorDAO
    {
        bool AddAuthor(string secondname, string firstname, DateTime birth_date);

        bool DeleteAuthor(long authorID);

        IEnumerable<Author> FindAuthors(string author);

        IEnumerable<Author> GetAllAuthors();

        Author GetAuthorByID(long authorID);

        bool UpdateAuthor(long ID, string secondname, string firstname, DateTime birthDate);
    }
}
