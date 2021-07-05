using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryThreeLayer2021.Common.Entities;
using LibraryThreeLayer2021.BLL.InterfaceBLL;
using LibraryThreeLayer2021.DAL.InterfaceDAL;
using System.IO;

namespace LibraryThreeLayer2021.BLL.Real1BLL
{
    public class BLL1 : ILogic
    {
        private ILibDAO _dao;

        public BLL1(ILibDAO dao)
        {
            _dao = dao;
        }

        public bool AddAuthor(string secondname, string firstname, DateTime birth_date)
        {
            return _dao.AddAuthor(secondname, firstname, birth_date);
        }

        public bool AddBook(string name, string desc, DateTime publicationDate, string addedByUsername, long authorID, string text = null, string fileName = null)
        {
            BookFileContainer fileContainer = null;
            if (fileName != null)
            {
                fileContainer = ConvertFileToByteArch(fileName);
            }

            return _dao.AddBook(name, desc, publicationDate, addedByUsername, authorID, text, fileContainer?.BookFile, fileContainer?.FileName);
        }

        public bool AddBookToFavorite(string username, long bookID)
        {
            return _dao.AddBookToFavorite(username, bookID);
        }

        public bool AddGenre(string name, string desc)
        {
            return _dao.AddGenre(name, desc);
        }

        public bool AddGenreToBook(long bookID, long genreID)
        {
            return _dao.AddGenreToBook(bookID, genreID);
        }

        public bool AddUser(string username, string password, bool sex, string customName = null, bool isAdmin = false)
        {
            return _dao.AddUser(username, password, sex, customName, isAdmin);
        }

        public bool CheckAdminPass(string password)
        {
            return _dao.CheckAdminPass(password);
        }

        public bool ConvertByteArchToFileAndSave(BookFileContainer fileContainer)
        {
            if (fileContainer?.FileName == null || fileContainer?.FileName == "") throw new InvalidOperationException("File path is invalid");


            using(FileStream fs = new FileStream(fileContainer.FileName, FileMode.OpenOrCreate))
            {
                fs.Write(fileContainer.BookFile, 0, fileContainer.BookFile.Length);
            }

            return true;
        }

        public BookFileContainer ConvertFileToByteArch(string fileNameAndPath)
        {
            string shortFileName = fileNameAndPath.Substring(fileNameAndPath.LastIndexOf('\\')+1);

            byte[] fileData;

            using(FileStream fs = new FileStream(fileNameAndPath, FileMode.Open))
            {
                fileData = new byte[fs.Length];

                fs.Read(fileData, 0, fileData.Length);
            }

            return new BookFileContainer(shortFileName, fileData);
        }

        public bool DeleteAllFavBooksFromUser(string username)
        {
            return _dao.DeleteAllFavBooksFromUser(username);
        }

        public bool DeleteAllGenresFromBook(long bookID)
        {
            return _dao.DeleteAllGenresFromBook(bookID);
        }

        public bool DeleteAuthor(long authorID)
        {
            return _dao.DeleteAuthor(authorID);
        }

        public bool DeleteBookByID(long bookID)
        {
            return _dao.DeleteBookByID(bookID);
        }

        public bool DeleteConnectionFavBookWithUsers(long bookID)
        {
            return _dao.DeleteConnectionFavBookWithUsers(bookID);
        }

        public bool DeleteConnectionOfGenreWithBooks(long genreID)
        {
            return _dao.DeleteConnectionOfGenreWithBooks(genreID);
        }

        public bool DeleteFavBookFromUser(string username, long bookID)
        {
            return _dao.DeleteFavBookFromUser(username, bookID);
        }

        public bool DeleteGenre(long genreID)
        {
            return _dao.DeleteGenre(genreID);
        }

        public bool DeleteGenreFromBook(long bookID, long genreID)
        {
            return _dao.DeleteGenreFromBook(bookID, genreID);
        }

        public bool DeleteUser(string username)
        {
            return _dao.DeleteUser(username);
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

        public List<Book> FindBooksByAuthor(string author)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.FindBooksByAuthor(author))
            {
                books.Add(book);
            }

            return books;
        }

        public List<Book> FindBooksByGenre(string genre)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.FindBooksByGenre(genre))
            {
                books.Add(book);
            }

            return books;
        }

        public List<Book> FindBooksByName(string name)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.FindBooksByName(name))
            {
                books.Add(book);
            }

            return books;
        }

        public List<Book> FindBooksByYear(long year)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.FindBooksByYear(year))
            {
                books.Add(book);
            }

            return books;
        }

        public List<Book> FindBooksByYearMultiple(long year1, long year2)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.FindBooksByYearMultiple(year1, year2))
            {
                books.Add(book);
            }

            return books;
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

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.GetAllBooks())
            {
                books.Add(book);
            }

            return books;
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

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            foreach(User user in _dao.GetAllUsers())
            {
                users.Add(user);
            }

            return users;
        }

        public Author GetAuthorByID(long authorID)
        {
            return _dao.GetAuthorByID(authorID);
        }

        public Book GetBookByID(long bookID)
        {
            return _dao.GetBookByID(bookID);
        }

        public BookFileContainer GetBookFile(long bookID)
        {
            return _dao.GetBookFile(bookID);
        }

        public List<Book> GetBooksByAuthorID(long authorID)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.GetBooksByAuthorID(authorID))
            {
                books.Add(book);
            }

            return books;
        }

        public List<Book> GetBooksByGenreID(long genreID)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.GetBooksByGenreID(genreID))
            {
                books.Add(book);
            }

            return books;
        }

        public List<Book> GetFavBooksOfUser(string username)
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.GetFavBooksOfUser(username))
            {
                books.Add(book);
            }

            return books;
        }

        public Genre GetGenreByID(long genreID)
        {
            return _dao.GetGenreByID(genreID);
        }

        public string GetTextOfBook(long bookID)
        {
            return _dao.GetTextOfBook(bookID);
        }

        public User GetUserByName(string username)
        {
            return _dao.GetUserByName(username);
        }

        public bool GetUserByNameAndPass(string username, string pass)
        {
            return _dao.GetUserByNameAndPass(username, pass);
        }

        public bool UpdateAuthor(long ID, string secondname, string firstname, DateTime birthDate)
        {
            return _dao.UpdateAuthor(ID, secondname, firstname, birthDate);
        }

        public bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID)
        {
            return _dao.UpdateBook(ID, name, desc, publicationDate, authorID);
        }

        public bool UpdateBookFie(long ID, byte[] bookItself, string fileName)
        {
            return _dao.UpdateBookFie(ID, bookItself, fileName);
        }

        public bool UpdateBookText(long ID, string text)
        {
            return _dao.UpdateBookText(ID, text);
        }

        public bool UpdateGenre(long ID, string name, string desc)
        {
            return _dao.UpdateGenre(ID, name, desc);
        }

        public bool UpdateUser(string username, byte sex, string customName = null)
        {
            return _dao.UpdateUser(username, sex, customName);
        }

        public bool UpdateUserPass(string username, string newPass)
        {
            return _dao.UpdateUserPass(username, newPass);
        }
    }
}
