using LibraryThreeLayer2021.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryThreeLayer2021.BLL.InterfaceBLL
{
    public interface IBookLogic
    {
        bool AddBook(string name, string desc, DateTime publicationDate, string addedByUsername, long authorID, string text = null, string fileName = null);

        bool DeleteBookByID(long bookID);

        List<Book> FindBooksByAuthor(string author);

        List<Book> FindBooksByGenre(string genre);

        List<Book> FindBooksByName(string name);

        List<Book> FindBooksByYear(long year);

        List<Book> FindBooksByYearMultiple(long year1, long year2);

        List<Book> GetAllBooks();

        Book GetBookByID(long bookID);

        BookFileContainer GetBookFile(long bookID);

        List<Book> GetBooksByAuthorID(long authorID);

        List<Book> GetBooksByGenreID(long genreID);

        string GetTextOfBook(long bookID);

        bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID);

        bool UpdateBookFie(long ID, string fileName);

        bool UpdateBookText(long ID, string text);
    }
}
