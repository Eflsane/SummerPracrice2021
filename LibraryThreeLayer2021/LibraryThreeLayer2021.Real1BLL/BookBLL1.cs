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
    public class BookBLL1 : BLL1, IBookLogic
    {
        private IBookDAO _dao;

        public BookBLL1(IBookDAO dao)
        {
            _dao = dao;
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

        public bool DeleteBookByID(long bookID)
        {
            return _dao.DeleteBookByID(bookID);
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

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            foreach (Book book in _dao.GetAllBooks())
            {
                books.Add(book);
            }

            return books;
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

        public string GetTextOfBook(long bookID)
        {
            return _dao.GetTextOfBook(bookID);
        }

        public bool UpdateBook(long ID, string name, string desc, DateTime publicationDate, long authorID)
        {
            return _dao.UpdateBook(ID, name, desc, publicationDate, authorID);
        }

        public bool UpdateBookFie(long ID, string fileName)
        {
            BookFileContainer fileContainer = null;
            if (fileName != null)
            {
                fileContainer = ConvertFileToByteArch(fileName);
            }

            return _dao.UpdateBookFie(ID, fileContainer?.BookFile, fileContainer?.FileName);
        }

        public bool UpdateBookText(long ID, string text)
        {
            return _dao.UpdateBookText(ID, text);
        }
    }
}
