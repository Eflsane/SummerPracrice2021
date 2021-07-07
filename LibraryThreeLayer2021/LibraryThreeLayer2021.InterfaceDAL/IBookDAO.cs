using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface IBookDAO
    {
        bool AddBook(string name, string desc, DateTime publicationDate, string addedByUsername, long authorID, string text = null, byte[] bookItself = null, string fileName = null);

        bool DeleteBookByID(long bookID);

        IEnumerable<Book> FindBooksByAuthor(string author);

        IEnumerable<Book> FindBooksByGenre(string genre);

        IEnumerable<Book> FindBooksByName(string name);

        IEnumerable<Book> FindBooksByYear(long year);

        IEnumerable<Book> FindBooksByYearMultiple(long year1, long year2);

        IEnumerable<Book> GetAllBooks();

        Book GetBookByID(long bookID);

        BookFileContainer GetBookFile(long bookID);

        IEnumerable<Book> GetBooksByAuthorID(long authorID);

        IEnumerable<Book> GetBooksByGenreID(long genreID);

        string GetTextOfBook(long bookID);

        bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID);

        bool UpdateBookFie(long ID, byte[] bookItself, string fileName);

        bool UpdateBookText(long ID, string text);
    }
}
