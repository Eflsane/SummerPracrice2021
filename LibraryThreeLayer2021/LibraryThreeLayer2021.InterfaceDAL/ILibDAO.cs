using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryThreeLayer2021.Common.Entities;


namespace LibraryThreeLayer2021.DAL.InterfaceDAL
{
    public interface ILibDAO
    {
        bool AddAuthor(string secondname, string firstname, DateTime birth_date);

        bool AddBook(string name, string desc, DateTime publicationDate, string addedByUsername, long authorID, string text = null, byte[] bookItself = null, string fileName = null);

        bool AddBookToFavorite(string username, long bookID);

        bool AddGenre(string name, string desc);

        bool AddGenreToBook(long bookID, long genreID);

        bool AddUser(string username, string password, bool sex, string customName = null, bool isAdmin = false);

        bool CheckAdminPass(string password);

        bool DeleteAllFavBooksFromUser(string username);

        bool DeleteAllGenresFromBook(long bookID);

        bool DeleteAuthor(long authorID);

        bool DeleteBookByID(long bookID);

        bool DeleteConnectionFavBookWithUsers(long bookID);

        bool DeleteConnectionOfGenreWithBooks(long genreID);

        bool DeleteFavBookFromUser(string username, long bookID);

        bool DeleteGenre(long genreID);

        bool DeleteGenreFromBook(long bookID, long genreID);

        bool DeleteUser(string username);

        IEnumerable<Author> FindAuthors(string author);

        IEnumerable<Book> FindBooksByAuthor(string author);

        IEnumerable<Book> FindBooksByGenre(string genre);

        IEnumerable<Book> FindBooksByName(string name);

        IEnumerable<Book> FindBooksByYear(long year);

        IEnumerable<Book> FindBooksByYearMultiple(long year1, long year2);

        IEnumerable<Author> GetAllAuthors();

        IEnumerable<Book> GetAllBooks();

        IEnumerable<Genre> GetAllGenres();

        IEnumerable<User> GetAllUsers();

        Author GetAuthorByID(long authorID);

        Book GetBookByID(long bookID);

        BookFileContainer GetBookFile(long bookID);

        IEnumerable<Book> GetBooksByAuthorID(long authorID);

        IEnumerable<Book> GetBooksByGenreID(long genreID);

        IEnumerable<Book> GetFavBooksOfUser(string username);

        Genre GetGenreByID(long genreID);

        IEnumerable<Genre> GetGenresOfBookById(long bookID);

        string GetTextOfBook(long bookID);

        User GetUserByName(string username);

        bool GetUserByNameAndPass(string username, string pass);

        bool UpdateAuthor(long ID, string secondname, string firstname, DateTime birthDate);

        bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID);

        bool UpdateBookFie(long ID, byte[] bookItself, string fileName);

        bool UpdateBookText(long ID, string text);

        bool UpdateGenre(long ID, string name, string desc);

        bool UpdateUser(string username, byte sex, string customName = null);

        bool UpdateUserPass(string username, string newPass);

    }
}
